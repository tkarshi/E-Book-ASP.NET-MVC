﻿using System;
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
    public class customerController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: customer
        public ActionResult Index()
        {
            return View(db.customerTables.ToList());
        }

        // GET: customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerTable customerTable = db.customerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            return View(customerTable);
        }

        // GET: customer/Create
        public ActionResult Create()
        {
          return View();
            
        }

        // POST: customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,cusName,cusEmail,cusAddress,cusPhone,cusUsername,cusPassword")] customerTable customerTable)
        {
            if (ModelState.IsValid)
            {
                db.customerTables.Add(customerTable);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Customer successfully registered!";
                return RedirectToAction("Index","CustomerDashboard");
            }

            return View(customerTable);
        }

        // GET: customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerTable customerTable = db.customerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            return View(customerTable);
        }

        // POST: customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cusName,cusEmail,cusAddress,cusPhone,cusUsername,cusPassword")] customerTable customerTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerTable);
        }

        // GET: customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerTable customerTable = db.customerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            return View(customerTable);
        }

        // POST: customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customerTable customerTable = db.customerTables.Find(id);
            db.customerTables.Remove(customerTable);
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
