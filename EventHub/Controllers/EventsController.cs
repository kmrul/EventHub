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

        [HttpPost]
        public ActionResult Search(EventsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
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

            var attendances = _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Event.DateTime > DateTime.Now)
                .ToList()
                .ToLookup(a => a.EventId);

            var viewModel = new EventsViewModel
            {
                UpcommingEvents = gigs,
                ShowingActions = User.Identity.IsAuthenticated,
                Heading = "My Attending Events",
                Attendances = attendances
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
            var evnt = _context.Events
                .Include(u => u.Organizer)
                .Include(u=>u.Category)
                .SingleOrDefault(g=>g.Id == id);
            if (evnt == null)
                return HttpNotFound();


            var viewModel = new EventsViewModel { Event = evnt };

            if(User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsAttending = _context.Attendances
                    .Any(a => a.EventId == evnt.Id && a.AttendeeId == userId);
                viewModel.IsFollowing = _context.Followings
                    .Any(f => f.FolloweeId == evnt.OrganizerId && f.FolloweeId == userId);
            }

            return View("Details", viewModel);
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
                var evnt = _context.Events
                    .Include(g => g.Attendaces.Select(a => a.Attendee))
                    .Single(g => g.Id == dto.Id && g.OrganizerId == userId);
                evnt.Name = dto.Name;
                evnt.Vanue = dto.Vanue;
                evnt.DateTime = dto.GetDateTime();
                evnt.CategoryId = dto.Category;

                evnt.Modify(dto.GetDateTime(), dto.Vanue, dto.Category);
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
