using EventHub.Models;
using EventHub.ViewModels;
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



        public ActionResult Index()
        {
            var upcommingEvents = _context.Events
                .Include(e => e.Organizer)
                .Include(e => e.Category)
                .Where(e => e.DateTime > DateTime.Now);

            var viewModel = new EventsViewModel
            {
                UpcommingEvents = upcommingEvents,
                ShowingActions = User.Identity.IsAuthenticated,
                Heading = "Show Upcomming Events"
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