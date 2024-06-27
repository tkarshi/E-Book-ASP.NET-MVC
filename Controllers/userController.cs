using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EBookPvt.Models;

namespace EBookPvt.Controllers
{
    public class userController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: user
        public ActionResult Index()
        {
            return View(db.userTables.ToList());
        }

        // GET: user/Details/5
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

        // GET: user/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user/Create
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

        // GET: user/Edit/5
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

        // POST: user/Edit/5
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

        // GET: user/Delete/5
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

        // POST: user/Delete/5
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
