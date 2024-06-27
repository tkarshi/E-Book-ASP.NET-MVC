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
    public class customerPaymentController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: customerPayment
        public ActionResult Index()
        {
            var customerPaymentTables = db.customerPaymentTables.Include(c => c.bookOrderTable).Include(c => c.customerTable);
            return View(customerPaymentTables.ToList());
        }

        // GET: customerPayment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerPaymentTable customerPaymentTable = db.customerPaymentTables.Find(id);
            if (customerPaymentTable == null)
            {
                return HttpNotFound();
            }
            return View(customerPaymentTable);
        }

        // GET: customerPayment/Create
        public ActionResult Create()
        {
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id");
            ViewBag.cusIdFk = new SelectList(db.customerTables, "Id", "cusName");
            return View();
        }

        // POST: customerPayment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,cusIdFk,bookOrderIdFk,totalAmount,date")] customerPaymentTable customerPaymentTable)
        {
            if (ModelState.IsValid)
            {
                db.customerPaymentTables.Add(customerPaymentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", customerPaymentTable.bookOrderIdFk);
            ViewBag.cusIdFk = new SelectList(db.customerTables, "Id", "cusName", customerPaymentTable.cusIdFk);
            return View(customerPaymentTable);
        }

        // GET: customerPayment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerPaymentTable customerPaymentTable = db.customerPaymentTables.Find(id);
            if (customerPaymentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", customerPaymentTable.bookOrderIdFk);
            ViewBag.cusIdFk = new SelectList(db.customerTables, "Id", "cusName", customerPaymentTable.cusIdFk);
            return View(customerPaymentTable);
        }

        // POST: customerPayment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cusIdFk,bookOrderIdFk,totalAmount,date")] customerPaymentTable customerPaymentTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerPaymentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", customerPaymentTable.bookOrderIdFk);
            ViewBag.cusIdFk = new SelectList(db.customerTables, "Id", "cusName", customerPaymentTable.cusIdFk);
            return View(customerPaymentTable);
        }

        // GET: customerPayment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerPaymentTable customerPaymentTable = db.customerPaymentTables.Find(id);
            if (customerPaymentTable == null)
            {
                return HttpNotFound();
            }
            return View(customerPaymentTable);
        }

        // POST: customerPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customerPaymentTable customerPaymentTable = db.customerPaymentTables.Find(id);
            db.customerPaymentTables.Remove(customerPaymentTable);
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
