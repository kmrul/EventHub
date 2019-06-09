using EventHub.Controllers;
using EventHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace EventHub.ViewModels
{
    public class EventForViewModel
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

        public string Heading { get; set; }

        public string Action {
            get
            {
                Expression<Func<EventsController, ActionResult>> update = (c => c.Update(this));

                Expression<Func<EventsController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public IEnumerable<Category> Categories { get; set; }



        public DateTime GetDateTime()
        {
            return DateTime.Parse(String.Format("{0} {1}", Date, Time));
        }
    }
}