using EventHub.Models;
using System.Data.Entity;
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
            var evnt = _context.Events
                .Include(g=>g.Attendaces.Select(a=>a.Attendee))
                .Single(g => g.Id == id && g.OrganizerId == userId);

            if (evnt.IsCanceled)
                return NotFound();

            evnt.Cancel();
            _context.SaveChanges();

            return Ok();

        }
    }
}
