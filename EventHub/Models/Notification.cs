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
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalValue { get; set; }

        [Required]
        public Event Event { get; private set; }

        public Notification()
        {

        }

        public Notification(NotificationType type, Event evnt)
        {
            if (evnt == null)
                throw new Exception("event");
            Type = type;
            Event = evnt;
            DateTime = DateTime.Now;
        }

       
    }
}