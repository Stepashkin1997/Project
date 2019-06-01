using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Filter
    {
        public string name { get; set; }
        public string customer { get; set; }
        public string executor { get; set; }
        public string manager { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int priority { get; set; }
    }
}