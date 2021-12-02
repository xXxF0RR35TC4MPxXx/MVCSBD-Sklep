using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSBD_Sklep.Models;

namespace MVCSBD_Sklep.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeliveryTypesController : Controller
    {
        private XmoreltronikEntities db = new XmoreltronikEntities();

        // GET: DeliveryTypes
        public ActionResult Index()
        {
            return View(db.DeliveryTypes.ToList());
        }

        // GET: DeliveryTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryType deliveryType = db.DeliveryTypes.Find(id);
            if (deliveryType == null)
            {
                return HttpNotFound();
            }
            return View(deliveryType);
        }

        // GET: DeliveryTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryTypes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DeliveryType deliveryType)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryTypes.Add(deliveryType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryType);
        }

        // GET: DeliveryTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryType deliveryType = db.DeliveryTypes.Find(id);
            if (deliveryType == null)
            {
                return HttpNotFound();
            }
            return View(deliveryType);
        }

        // POST: DeliveryTypes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DeliveryType deliveryType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryType);
        }

        // GET: DeliveryTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryType deliveryType = db.DeliveryTypes.Find(id);
            if (deliveryType == null)
            {
                return HttpNotFound();
            }
            return View(deliveryType);
        }

        // POST: DeliveryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryType deliveryType = db.DeliveryTypes.Find(id);
            db.DeliveryTypes.Remove(deliveryType);
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
