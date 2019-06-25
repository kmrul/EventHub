using EventHub.Models;
using System.Collections.Generic;

namespace EventHub.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcommingEvents { get; set; }

        public bool ShowingActions { get; set; }

        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}