using EventHub.Dtos;
using EventHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.EventId == dto.EventId))
                return BadRequest("Attendance already exits");

            var attendance = new Attendance
            {
                EventId = dto.EventId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
