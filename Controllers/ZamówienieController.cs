using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSBD_Sklep.Models;

namespace MVCSBD_Sklep.Controllers
{
    public class ZamówienieController : Controller
    {
        private XmoreltronikEntities db = new XmoreltronikEntities();

        // GET: Zamówienie
        public ActionResult Index()
        {
            var zamówienia = db.Zamówienia.Include(z => z.deliveryState).Include(z => z.deliveryType).Include(z => z.paymentType);
            return View(zamówienia.ToList());
        }

        // GET: Zamówienie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zamówienie zamówienie = db.Zamówienia.Find(id);
            if (zamówienie == null)
            {
                return HttpNotFound();
            }
            return View(zamówienie);
        }

        // GET: Zamówienie/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryStateId = new SelectList(db.DeliveryStates, "Id", "Name");
            ViewBag.deliveryTypeId = new SelectList(db.DeliveryTypes, "Id", "Name");
            ViewBag.paymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name");
            return View();
        }

        // POST: Zamówienie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Zamówienie zamówienie)
        {
            if (ModelState.IsValid)
            {
                db.Zamówienia.Add(zamówienie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryStateId = new SelectList(db.DeliveryStates, "Id", "Name", zamówienie.DeliveryStateId);
            ViewBag.deliveryTypeId = new SelectList(db.DeliveryTypes, "Id", "Name", zamówienie.deliveryTypeId);
            ViewBag.paymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name", zamówienie.paymentTypeId);
            return View(zamówienie);
        }

        // GET: Zamówienie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zamówienie zamówienie = db.Zamówienia.Find(id);
            if (zamówienie == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryStateId = new SelectList(db.DeliveryStates, "Id", "Name", zamówienie.DeliveryStateId);
            ViewBag.deliveryTypeId = new SelectList(db.DeliveryTypes, "Id", "Name", zamówienie.deliveryTypeId);
            ViewBag.paymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name", zamówienie.paymentTypeId);
            return View(zamówienie);
        }

        // POST: Zamówienie/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "OrderId, Username, FirstName, LastName, Address, City, PostalCode, Country, Phone, Email, Total, OrderDate, deliveryTypeId, paymentTypeId, DeliveryStateId")] Zamówienie zamówienie)
        {
            //NIE DZIAŁA EDYTOWANIE ZAMÓWIEŃ - NIE MAM POJĘCIA CZEMU
            //Wywala, że edytowano 0 rekordów w bazie ciągle
            ViewBag.DeliveryStateId = new SelectList(db.DeliveryStates, "Id", "Name", zamówienie.DeliveryStateId);
            ViewBag.deliveryTypeId = new SelectList(db.DeliveryTypes, "Id", "Name", zamówienie.deliveryTypeId);
            ViewBag.paymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name", zamówienie.paymentTypeId);
            if (zamówienie == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                db.Entry(zamówienie).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(zamówienie);
        }

        // GET: Zamówienie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zamówienie zamówienie = db.Zamówienia.Find(id);
            if (zamówienie == null)
            {
                return HttpNotFound();
            }
            return View(zamówienie);
        }

        // POST: Zamówienie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zamówienie zamówienie = db.Zamówienia.Find(id);
            db.Zamówienia.Remove(zamówienie);
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
