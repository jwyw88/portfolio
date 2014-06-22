using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelByKathy.Models;
using PersonelByKathy.ViewModels;

namespace PersonelByKathy.Controllers
{
    public class HomeController : Controller
    {
        private PersonelByKathyContext db = new PersonelByKathyContext();

        //
        // GET: /Home/
        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            //on submit of login form
            //select user whose username matches the login form
            // hint - use "kawesome" as username and "aweso" as password
            User verified = (from un in db.Users where (un.UserName == user.UserName) select un).FirstOrDefault();
            //if username is not found  null will be returned to verified
            //in this case we assume it's not null since it's kathy awesome logging in!
            if (verified != null)
            {
                //store the person who is logging in in session
                //for further session help go here: 
                //http://stackoverflow.com/questions/14138872/how-to-use-sessions-in-an-asp-net-mvc-4-application
                Session["UserLoggedIn"] = verified.UserName;

                //since this person is now logged in go to the index page
                return RedirectToAction("Index");
            }
            //clearly if null was returned then the user was not found so send person back to login page
            return View();
        }
    }
}
