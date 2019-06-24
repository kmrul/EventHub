using AutoMapper;
using EventHub.App_Start;
using EventHub.Dtos;
using EventHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Event.Organizer).ToList();

            //return notifications.Select(Mapper.Map<Notification, NotificationDto>);

            return notifications.Select(n => new NotificationDto()
            {
                DateTime = n.DateTime,
                Event = new EventDto
                {
                    Organizer = new UserDto
                    {
                        Id = n.Event.Id,
                        Name = n.Event.Organizer.Name
                    },
                    DateTime = n.Event.DateTime,
                    Id = n.Event.Id,
                    IsCanceled = n.Event.IsCanceled,
                    Vanue = n.Event.Vanue
                },
                OriginalDateTime = n.OriginalDateTime,
                OriginalValue = n.OriginalValue,
                Type = n.Type
            });
        }

    }
}
