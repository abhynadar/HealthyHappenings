using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthyHappenings.Web.Models
{
    public class HealthEvent
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public string Logo { get; set; }
        public Organizer organizer { get; set; }
        public string StartDate { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
        public Vanue vanue { get; set; }
       

    }

    public class Organizer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

    }
    public class Vanue
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

    }
}