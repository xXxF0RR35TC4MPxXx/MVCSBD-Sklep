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
    [Authorize(Roles ="Admin")]
    public class PaymentTypesController : Controller
    {
        private XmoreltronikEntities db = new XmoreltronikEntities();

        // GET: PaymentTypes
        public ActionResult Index()
        {
            return View(db.PaymentTypes.ToList());
        }

        // GET: PaymentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = db.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // GET: PaymentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PaymentType paymentType)
        {
            PaymentType czyIstnieje = db.PaymentTypes.FirstOrDefault(p => p.Name.ToLower() == paymentType.Name.ToLower());
            if (czyIstnieje != null)
            {
                ViewBag.Message = "Metoda płatności o podanej nazwie już istnieje!";
                return View(paymentType);
            }
            if (ModelState.IsValid)
            {
                db.PaymentTypes.Add(paymentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentType);
        }

        // GET: PaymentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = db.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // POST: PaymentTypes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PaymentType paymentType)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(paymentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentType);
        }

        // GET: PaymentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = db.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentType paymentType = db.PaymentTypes.Find(id);
            db.PaymentTypes.Remove(paymentType);
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
