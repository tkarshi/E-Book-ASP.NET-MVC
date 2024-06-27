using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EBookPvt.Models;

namespace EBookPvt.Views
{
    public class AdminController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();


        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "username,password")] userTable user)
        {
            if (ModelState.IsValid)
            {
                var adminUser = db.userTables.FirstOrDefault(u => u.username == user.username && u.password == user.password);
                if (adminUser != null)
                {
                    
                    return RedirectToAction("Create","Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(user);
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.userTables.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTable userTable = db.userTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,username,password")] userTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.userTables.Add(userTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTable);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTable userTable = db.userTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,username,password")] userTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTable);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTable userTable = db.userTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userTable userTable = db.userTables.Find(id);
            db.userTables.Remove(userTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
