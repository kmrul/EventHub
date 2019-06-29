using EventHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventHub.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcommingEvents { get; set; }

        public bool ShowingActions { get; set; }

        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public Event Event { get; internal set; }
        public bool IsAttending { get; internal set; }
        public bool IsFollowing { get; internal set; }
        public ILookup<int, Attendance> Attendances { get; set; }
    }
}