using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelByKathy.Models;
using PersonelByKathy.ViewModels;
using PersonelByKathy.Abstract;
using PersonelByKathy.Concrete;



namespace PersonelByKathy.Concrete
{
    public class JobRepository : IJobRepository
    {
        private PersonelByKathyContext db = new PersonelByKathyContext();
        public JobViewModel GetJobsByUser(string UserloggedIn)
        {
            User verified = (from un in db.Users where (un.UserName == UserloggedIn) select un).FirstOrDefault();
            JobViewModel jobsProfile = new JobViewModel();
            jobsProfile.FirstName = verified.FirstName;
            jobsProfile.LastName = verified.LastName;
            jobsProfile.Email = verified.Email;
            jobsProfile.Jobs = db.Jobs.ToList();
            return jobsProfile;             
        }
    }
}      
        
    