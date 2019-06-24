using EventHub.Controllers;
using EventHub.Models;
using EventHub.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace EventHub.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public UserDto Organizer { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string Vanue { get; set; }
        public CategoryDto Category { get; set; }
        
        public ICollection<Attendance> Attendaces { get; internal set; }
    }
}