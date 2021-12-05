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
    public class DeliveryStatesController : Controller
    {
        private XmoreltronikEntities db = new XmoreltronikEntities();

        // GET: DeliveryStates
        public ActionResult Index()
        {
            return View(db.DeliveryStates.ToList());
        }

        // GET: DeliveryStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryState deliveryState = db.DeliveryStates.Find(id);
            if (deliveryState == null)
            {
                return HttpNotFound();
            }
            return View(deliveryState);
        }

        // GET: DeliveryStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryStates/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DeliveryState deliveryState)
        {
            DeliveryState czyIstnieje = db.DeliveryStates.FirstOrDefault(p => p.Name.ToLower() == deliveryState.Name.ToLower());
            if (czyIstnieje != null)
            {
                ViewBag.Message = "Stan realizacji zamówienia o podanej nazwie już istnieje!";
                return View(deliveryState);
            }
            if (ModelState.IsValid)
            {
                db.DeliveryStates.Add(deliveryState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryState);
        }

        // GET: DeliveryStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryState deliveryState = db.DeliveryStates.Find(id);
            if (deliveryState == null)
            {
                return HttpNotFound();
            }
            return View(deliveryState);
        }

        // POST: DeliveryStates/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DeliveryState deliveryState)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(deliveryState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryState);
        }

        // GET: DeliveryStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryState deliveryState = db.DeliveryStates.Find(id);
            if (deliveryState == null)
            {
                return HttpNotFound();
            }
            return View(deliveryState);
        }

        // POST: DeliveryStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryState deliveryState = db.DeliveryStates.Find(id);
            db.DeliveryStates.Remove(deliveryState);
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
