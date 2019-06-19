using EventHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventHub.Controllers.Api
{
    [Authorize]
    public class EventsController : ApiController
    {
        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var evnt = _context.Events.Single(g => g.Id == id && g.OrganizerId == userId);
            if (evnt.IsCanceled)
                return NotFound();

            evnt.IsCanceled = true;

            var notification = new Notification
            {
                DateTime = DateTime.Now,
                Event = evnt,
                Type = NotificationType.EventCanceled
            };

            var attendees = _context.Attendances
                .Where(a => a.EventId == evnt.Id)
                .Select(a => a.Attendee)
                .ToList();
            foreach (var attendee in attendees)
            {
                var userNotifcation = new UserNotification
                {
                    User = attendee,
                    Notification = notification
                };
                _context.UserNotifications.Add(userNotifcation);

            }

            _context.SaveChanges();

            return Ok();

        }
    }
}
