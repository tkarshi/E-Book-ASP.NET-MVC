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
    public class bookTypeController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: bookType
        public ActionResult Index()
        {
            return View(db.bookTypeTables.ToList());
        }

        // GET: bookType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTypeTable bookTypeTable = db.bookTypeTables.Find(id);
            if (bookTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(bookTypeTable);
        }

        // GET: bookType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bookType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,available,storeLocation")] bookTypeTable bookTypeTable)
        {
            if (ModelState.IsValid)
            {
                db.bookTypeTables.Add(bookTypeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookTypeTable);
        }

        // GET: bookType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTypeTable bookTypeTable = db.bookTypeTables.Find(id);
            if (bookTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(bookTypeTable);
        }

        // POST: bookType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,available,storeLocation")] bookTypeTable bookTypeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTypeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookTypeTable);
        }

        // GET: bookType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTypeTable bookTypeTable = db.bookTypeTables.Find(id);
            if (bookTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(bookTypeTable);
        }

        // POST: bookType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookTypeTable bookTypeTable = db.bookTypeTables.Find(id);
            db.bookTypeTables.Remove(bookTypeTable);
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
