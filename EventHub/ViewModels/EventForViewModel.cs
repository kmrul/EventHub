using EventHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventHub.ViewModels
{
    public class EventForViewModel
    {
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



        public DateTime GetDateTime()
        {
            return DateTime.Parse(String.Format("{0} {1}", Date, Time));
        }
    }
}