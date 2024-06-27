using EBookPvt.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EBookPvt.Controllers
{
    public class HomeController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(customerTable customer)
        {
            if (ModelState.IsValid)
            {
                var user = db.customerTables.FirstOrDefault(c => c.cusUsername == customer.cusUsername && c.cusPassword == customer.cusPassword);
                if (user != null)
                {
                    // Successful login
                    TempData["LoginMessage"] = "Login Successful!";
                    return RedirectToAction("index", "CustomerDashboard");
                    
                }
                else
                {
                    // Invalid login
                    ModelState.AddModelError("", "Invalid Username or Password.");
                }
            }

            return View(customer);
        }

        // GET: Home/CustomerDashboard
        public ActionResult CustomerDashboard()
        {
            ViewBag.Message = TempData["LoginMessage"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }



    }
}