using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelByKathy.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public bool IsFullTime { get; set; }
    }
}