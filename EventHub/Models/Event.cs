using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EventHub.Models
{
    public class Event
    {
        public int Id { get; set; }

        public ApplicationUser Organizer { get; set; }

        [Required]
        public string OrganizerId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Vanue { get; set; }

        public Category Category { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        public bool IsCanceled { get; private set; }

        public ICollection<Attendance> Attendaces { get; internal set; }


        public Event()
        {
            Attendaces = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = new Notification(NotificationType.EventCanceled, this);

            foreach (var attendee in Attendaces.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}