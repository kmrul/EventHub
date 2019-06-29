using EventHub.Models;
using EventHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EventHub.Controllers
{
    public class HomeController : Controller
    {
        public readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }



        public ActionResult Index(string query = null)
        {

            var upcommingEvents = _context.Events
                .Include(e => e.Organizer)
                .Include(e => e.Category)
                .Where(e => e.DateTime > DateTime.Now);
            

            if(!string.IsNullOrWhiteSpace(query))
            {
                upcommingEvents = upcommingEvents.Where(g =>
                                                        g.Organizer.Name.Contains(query) ||
                                                        g.Category.Name.Contains(query) ||
                                                        g.Vanue.Contains(query)||
                                                        g.Name.Contains(query));

            }
            var userId = User.Identity.GetUserId();
            var attendances = _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Event.DateTime > DateTime.Now)
                .ToList()
                .ToLookup(a => a.EventId);

            var viewModel = new EventsViewModel
            {
                UpcommingEvents = upcommingEvents,
                ShowingActions = User.Identity.IsAuthenticated,
                Heading = "Show Upcomming Events",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Events",viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}