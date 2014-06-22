using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonelByKathy.Models;

namespace PersonelByKathy.ViewModels
{
    public class JobViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}