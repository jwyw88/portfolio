using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PersonelByKathy.Models;

namespace PersonelByKathy.Concrete
{
    public class PersonelByKathyDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
    }
}