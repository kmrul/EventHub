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

        [Required]
        public string Name { get; set; }

        public byte Category { get; set; }

        [Required]
        public string Vanue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }


        [Required]
        [ValidTime]
        public string Time { get; set; }
        

        public IEnumerable<Category> Categories { get; set; }

        public string Heading { get; set; }

       

        public DateTime GetDateTime()
        {
            return DateTime.Parse(String.Format("{0} {1}", Date, Time));
        }
    }
}