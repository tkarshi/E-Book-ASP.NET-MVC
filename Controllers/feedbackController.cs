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
    public class feedbackController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: feedback
        public ActionResult Index()
        {
            var feedbackTables = db.feedbackTables.Include(f => f.bookOrderTable);
            return View(feedbackTables.ToList());
        }

        // GET: feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedbackTable feedbackTable = db.feedbackTables.Find(id);
            if (feedbackTable == null)
            {
                return HttpNotFound();
            }
            return View(feedbackTable);
        }

        // GET: feedback/Create
        public ActionResult Create()
        {
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id");
            return View();
        }

        // POST: feedback/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,rating,comment,bookOrderIdFk")] feedbackTable feedbackTable)
        {
            if (ModelState.IsValid)
            {
                db.feedbackTables.Add(feedbackTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", feedbackTable.bookOrderIdFk);
            return View(feedbackTable);
        }

        // GET: feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedbackTable feedbackTable = db.feedbackTables.Find(id);
            if (feedbackTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", feedbackTable.bookOrderIdFk);
            return View(feedbackTable);
        }

        // POST: feedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,rating,comment,bookOrderIdFk")] feedbackTable feedbackTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", feedbackTable.bookOrderIdFk);
            return View(feedbackTable);
        }

        // GET: feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedbackTable feedbackTable = db.feedbackTables.Find(id);
            if (feedbackTable == null)
            {
                return HttpNotFound();
            }
            return View(feedbackTable);
        }

        // POST: feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feedbackTable feedbackTable = db.feedbackTables.Find(id);
            db.feedbackTables.Remove(feedbackTable);
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
