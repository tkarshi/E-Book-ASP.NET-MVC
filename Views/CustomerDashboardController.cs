﻿using System;
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
    public class CustomerDashboardController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: CustomerDashboard
        public ActionResult Index(string search)
        {
            var bookTables = db.bookTables.Include(b => b.bookTypeTable);
            if (!String.IsNullOrEmpty(search))
            {
                bookTables = bookTables.Where(b => b.title.Contains(search));
            }
            return View(bookTables.ToList());
        }

        // GET: CustomerDashboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTable bookTable = db.bookTables.Find(id);
            if (bookTable == null)
            {
                return HttpNotFound();
            }
            return View(bookTable);
        }

        // GET: CustomerDashboard/Create
        public ActionResult Create()
        {
            ViewBag.bookTypeIdFk = new SelectList(db.bookTypeTables, "Id", "name");
            return View();
        }

        // POST: CustomerDashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,bookTypeIdFk,title,description,imageUrl")] bookTable bookTable)
        {
            if (ModelState.IsValid)
            {
                db.bookTables.Add(bookTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookTypeIdFk = new SelectList(db.bookTypeTables, "Id", "name", bookTable.bookTypeIdFk);
            return View(bookTable);
        }

        // GET: CustomerDashboard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTable bookTable = db.bookTables.Find(id);
            if (bookTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookTypeIdFk = new SelectList(db.bookTypeTables, "Id", "name", bookTable.bookTypeIdFk);
            return View(bookTable);
        }

        // POST: CustomerDashboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,bookTypeIdFk,title,description,imageUrl")] bookTable bookTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookTypeIdFk = new SelectList(db.bookTypeTables, "Id", "name", bookTable.bookTypeIdFk);
            return View(bookTable);
        }

        // GET: CustomerDashboard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTable bookTable = db.bookTables.Find(id);
            if (bookTable == null)
            {
                return HttpNotFound();
            }
            return View(bookTable);
        }

        // POST: CustomerDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookTable bookTable = db.bookTables.Find(id);
            db.bookTables.Remove(bookTable);
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
