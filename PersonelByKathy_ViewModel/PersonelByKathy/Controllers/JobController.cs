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


namespace PersonelByKathy.Controllers
{
    public class JobController : Controller
    {
        //create a reference to the repository interface
        private IJobRepository _JobRepository;
        private PersonelByKathyContext db = new PersonelByKathyContext();

        //constructor loads respository into controller
        public JobController(IJobRepository jobRepository)
        {
            _JobRepository = jobRepository;
        
        }
            
        //
        // GET: /Job/

        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        //
        // GET: /Job/Details/5

        public ActionResult Details(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // GET: /Job/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Job/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        //
        // GET: /Job/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // POST: /Job/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        //
        // GET: /Job/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // POST: /Job/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //used for index -  returns json results of list of articles to display in UI
        public JsonResult FillIndex()
        {
            string loggedIn = Session["UserLoggedIn"].ToString();
            JobViewModel jobsProfile = new JobViewModel();
            jobsProfile = _JobRepository.GetJobsByUser(loggedIn);
            return Json(jobsProfile, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}