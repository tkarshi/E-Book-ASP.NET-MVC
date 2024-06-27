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
    public class orderStatusController : Controller
    {
        private ebookOrderDBEntities db = new ebookOrderDBEntities();

        // GET: orderStatus
        public ActionResult Index()
        {
            return View(db.orderStatusTables.ToList());
        }

        // GET: orderStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderStatusTable orderStatusTable = db.orderStatusTables.Find(id);
            if (orderStatusTable == null)
            {
                return HttpNotFound();
            }
            return View(orderStatusTable);
        }

        // GET: orderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: orderStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,statusName")] orderStatusTable orderStatusTable)
        {
            if (ModelState.IsValid)
            {
                db.orderStatusTables.Add(orderStatusTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderStatusTable);
        }

        // GET: orderStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderStatusTable orderStatusTable = db.orderStatusTables.Find(id);
            if (orderStatusTable == null)
            {
                return HttpNotFound();
            }
            return View(orderStatusTable);
        }

        // POST: orderStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,statusName")] orderStatusTable orderStatusTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderStatusTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderStatusTable);
        }

        // GET: orderStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderStatusTable orderStatusTable = db.orderStatusTables.Find(id);
            if (orderStatusTable == null)
            {
                return HttpNotFound();
            }
            return View(orderStatusTable);
        }

        // POST: orderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderStatusTable orderStatusTable = db.orderStatusTables.Find(id);
            db.orderStatusTables.Remove(orderStatusTable);
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
