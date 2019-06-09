using EventHub.Dtos;
using EventHub.Models;
using EventHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EventHub.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Events
                .Where(g => g.OrganizerId == userId && g.DateTime > DateTime.Now)
                .Include(g => g.Category)
                .Include(g => g.Organizer)
                .ToList();

            return View(gigs);
        }


        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventForViewModel
            {
                Categories = _context.Categories.ToList(),
                Heading = "Add A New Event"
            };
            return View("EventForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventForViewModel dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    dto.Categories = _context.Categories.ToList();
                    return RedirectToAction("EventForm");
                }

                var evnt = new Event
                {
                    OrganizerId = User.Identity.GetUserId(),
                    DateTime = dto.GetDateTime(),
                    CategoryId = dto.Category,
                    Vanue = dto.Vanue,
                    Name = dto.Name
                };

                _context.Events.Add(evnt);
                _context.SaveChanges();

                return RedirectToAction("mine", "events");
            }
            catch
            {
                return View();
            }
        }




        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Event)
                .Include(g => g.Category)
                .Include(g => g.Organizer)
                .ToList();

            var viewModel = new EventsViewModel
            {
                UpcommingEvents = gigs,
                ShowingActions = User.Identity.IsAuthenticated,
                Heading = "My Attending Events"
            };

            return View("Events", viewModel);
        }


        // GET: Events
        public ActionResult Index()
        {
            return View();
        }

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Events.Single(g => g.Id == id && g.OrganizerId == userId);



            var viewModel = new EventForViewModel
            {
                Categories = _context.Categories.ToList(),
                Id = gig.Id,
                Name = gig.Name,
                Vanue = gig.Vanue,
                Date = gig.DateTime.ToString("dd MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Category = gig.CategoryId,
                Heading = "Edit A Event"
            };

            return View("EventForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EventForViewModel dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    dto.Categories = _context.Categories.ToList();
                    return RedirectToAction("EventForm");
                }
                var userId = User.Identity.GetUserId();
                var gig = _context.Events.Single(g => g.Id == dto.Id && g.OrganizerId == userId);
                gig.Name = dto.Name;
                gig.Vanue = dto.Vanue;
                gig.DateTime = dto.GetDateTime();

                gig.CategoryId = dto.Category;

                _context.SaveChanges();

                return RedirectToAction("mine", "events");
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Events/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
