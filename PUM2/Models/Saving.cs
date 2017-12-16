using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PUM2.Models
{
    public class Saving
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double value { get; set; }
        public DateTime date { get; set; }
        public string image { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
    }
}