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
    public class orderDetailsController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: orderDetails
        public ActionResult Index()
        {
            var orderDetailsTables = db.orderDetailsTables.Include(o => o.bookOrderTable).Include(o => o.bookTable);
            return View(orderDetailsTables.ToList());
        }

        // GET: orderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetailsTable orderDetailsTable = db.orderDetailsTables.Find(id);
            if (orderDetailsTable == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailsTable);
        }

        // GET: orderDetails/Create
        public ActionResult Create()
        {
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id");
            ViewBag.bookIdFk = new SelectList(db.bookTables, "Id", "title");
            return View();
        }

        // POST: orderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,bookIdFk,bookOrderIdFk,qty,price,totalAmount")] orderDetailsTable orderDetailsTable)
        {
            if (ModelState.IsValid)
            {
                db.orderDetailsTables.Add(orderDetailsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", orderDetailsTable.bookOrderIdFk);
            ViewBag.bookIdFk = new SelectList(db.bookTables, "Id", "title", orderDetailsTable.bookIdFk);
            return View(orderDetailsTable);
        }

        // GET: orderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetailsTable orderDetailsTable = db.orderDetailsTables.Find(id);
            if (orderDetailsTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", orderDetailsTable.bookOrderIdFk);
            ViewBag.bookIdFk = new SelectList(db.bookTables, "Id", "title", orderDetailsTable.bookIdFk);
            return View(orderDetailsTable);
        }

        // POST: orderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,bookIdFk,bookOrderIdFk,qty,price,totalAmount")] orderDetailsTable orderDetailsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetailsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookOrderIdFk = new SelectList(db.bookOrderTables, "Id", "Id", orderDetailsTable.bookOrderIdFk);
            ViewBag.bookIdFk = new SelectList(db.bookTables, "Id", "title", orderDetailsTable.bookIdFk);
            return View(orderDetailsTable);
        }

        // GET: orderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetailsTable orderDetailsTable = db.orderDetailsTables.Find(id);
            if (orderDetailsTable == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailsTable);
        }

        // POST: orderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderDetailsTable orderDetailsTable = db.orderDetailsTables.Find(id);
            db.orderDetailsTables.Remove(orderDetailsTable);
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
