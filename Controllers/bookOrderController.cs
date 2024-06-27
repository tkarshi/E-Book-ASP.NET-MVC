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
    public class bookOrderController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: bookOrder
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var bookOrderTables = db.bookOrderTables.Include(b => b.customerTable).Include(b => b.orderStatusTable);

            if (startDate.HasValue && endDate.HasValue)
            {
                bookOrderTables = bookOrderTables.Where(b => b.orderDate >= startDate && b.orderDate <= endDate);
            }
            return View(bookOrderTables.ToList());
        }

        // GET: bookOrder/MonthlyReport
        public ActionResult MonthlyReport(string month)
        {
            if (!string.IsNullOrEmpty(month) && DateTime.TryParse(month, out DateTime selectedMonth))
            {
                var startDate = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var bookOrderTables = db.bookOrderTables.Include(b => b.customerTable).Include(b => b.orderStatusTable)
                                                        .Where(b => b.orderDate >= startDate && b.orderDate <= endDate)
                                                        .ToList();
                return View("Index", bookOrderTables);
            }
            else
            {
                // Handle invalid month format or empty input
                return View("Index", new List<bookOrderTable>());
            }
        }

        // GET: bookOrder/YearlyReport
        public ActionResult YearlyReport(int? year)
        {
            if (year.HasValue)
            {
                var startDate = new DateTime(year.Value, 1, 1);
                var endDate = startDate.AddYears(1).AddDays(-1);

                var bookOrderTables = db.bookOrderTables.Include(b => b.customerTable).Include(b => b.orderStatusTable)
                                                        .Where(b => b.orderDate >= startDate && b.orderDate <= endDate)
                                                        .ToList();
                return View("Index", bookOrderTables);
            }
            else
            {
                // Handle invalid year input
                return View("Index", new List<bookOrderTable>());
            }
        }



        // GET: bookOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookOrderTable bookOrderTable = db.bookOrderTables.Find(id);
            if (bookOrderTable == null)
            {
                return HttpNotFound();
            }
            return View(bookOrderTable);
        }

        // GET: bookOrder/Create
        public ActionResult Create()
        {
            ViewBag.cusIdFk = new SelectList(db.customerTables, "Id", "cusName");
            ViewBag.orderStatusIdFk = new SelectList(db.orderStatusTables, "id", "statusName");
            return View();
        }

        // POST: bookOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,cusIdFk,orderDate,deliveryDate,totalAmount,orderStatusIdFk")] bookOrderTable bookOrderTable)
        {
            if (ModelState.IsValid)
            {
                db.bookOrderTables.Add(bookOrderTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cusIdFk = new SelectList(db.customerTables, "Id", "cusName", bookOrderTable.cusIdFk);
            ViewBag.orderStatusIdFk = new SelectList(db.orderStatusTables, "id", "statusName", bookOrderTable.orderStatusIdFk);
            return View(bookOrderTable);
        }

        // GET: bookOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookOrderTable bookOrderTable = db.bookOrderTables.Find(id);
            if (bookOrderTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.cusIdFk = new SelectList(db.customerTables, "Id", "cusName", bookOrderTable.cusIdFk);
            ViewBag.orderStatusIdFk = new SelectList(db.orderStatusTables, "id", "statusName", bookOrderTable.orderStatusIdFk);
            return View(bookOrderTable);
        }

        // POST: bookOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cusIdFk,orderDate,deliveryDate,totalAmount,orderStatusIdFk")] bookOrderTable bookOrderTable)
        {
            if (ModelState.IsValid)
            {
                var existingOrder = db.bookOrderTables.Find(bookOrderTable.Id);
                if (existingOrder == null)
                {
                    return HttpNotFound();
                }

                // Only update the orderStatusIdFk
                existingOrder.orderStatusIdFk = bookOrderTable.orderStatusIdFk;
                db.Entry(existingOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cusIdFk = new SelectList(db.customerTables, "Id", "cusName", bookOrderTable.cusIdFk);
            ViewBag.orderStatusIdFk = new SelectList(db.orderStatusTables, "id", "statusName", bookOrderTable.orderStatusIdFk);
            return View(bookOrderTable);
        }

        // GET: bookOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookOrderTable bookOrderTable = db.bookOrderTables.Find(id);
            if (bookOrderTable == null)
            {
                return HttpNotFound();
            }
            return View(bookOrderTable);
        }

        // POST: bookOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookOrderTable bookOrderTable = db.bookOrderTables.Find(id);
            db.bookOrderTables.Remove(bookOrderTable);
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
