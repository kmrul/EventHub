using EventHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventHub.Dtos
{
    public class NotificationDto
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalValue { get; set; }

        [Required]
        public EventDto Event { get; set; }
    }
}