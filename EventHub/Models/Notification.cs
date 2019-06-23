using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalValue { get; private set; }

        [Required]
        public Event Event { get; private set; }

        protected Notification()
        {

        }

        private Notification(NotificationType type, Event evnt)
        {
            if (evnt == null)
                throw new Exception("event");
            Type = type;
            Event = evnt;
            DateTime = DateTime.Now;
        }

        public static Notification EventCreated(Event evnt)
        {
            return new Notification(NotificationType.EventCreated, evnt);
        }


        public static Notification EventUpdated(Event newEvnt, DateTime originalDateTime, string originalVanue)
        {
            var notification =  new Notification(NotificationType.EventUpdated, newEvnt);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalValue = originalVanue;

            return notification;
        }


        public static Notification EventCancel(Event evnt)
        {
            return new Notification(NotificationType.EventCanceled, evnt);
        }

    }
}