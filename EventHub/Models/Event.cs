using System;
using System.ComponentModel.DataAnnotations;

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

        public bool IsCanceled { get; set; }
    }
}