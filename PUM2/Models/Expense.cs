using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PUM2.Models
{
    public class Expense
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double value { get; set; }
        public DateTime date { get; set; }
        public int repeatValue { get; set; }
        public int category { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public long sourceId { get; set; }
    }
}