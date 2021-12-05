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
    public class SwitchTypesController : Controller
    {
        private XmoreltronikEntities db = new XmoreltronikEntities();

        // GET: SwitchTypes
        public ActionResult Index()
        {
            return View(db.SwitchTypes.ToList());
        }

        // GET: SwitchTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SwitchType switchType = db.SwitchTypes.Find(id);
            if (switchType == null)
            {
                return HttpNotFound();
            }
            return View(switchType);
        }

        // GET: SwitchTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SwitchTypes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] SwitchType switchType)
        {
            SwitchType czyIstnieje = db.SwitchTypes.FirstOrDefault(p => p.Name.ToLower() == switchType.Name.ToLower());
            if (czyIstnieje != null)
            {
                ViewBag.Message = "Typ przełącznika o podanej nazwie już istnieje!";
                return View(switchType);
            }
            if (ModelState.IsValid)
            {
                db.SwitchTypes.Add(switchType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(switchType);
        }

        // GET: SwitchTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SwitchType switchType = db.SwitchTypes.Find(id);
            if (switchType == null)
            {
                return HttpNotFound();
            }
            return View(switchType);
        }

        // POST: SwitchTypes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SwitchType switchType)
        {
            SwitchType czyIstnieje = db.SwitchTypes.FirstOrDefault(p => p.Name.ToLower() == switchType.Name.ToLower());
            if (czyIstnieje != null)
            {
                ViewBag.Message = "Typ przełącznika o podanej nazwie już istnieje!";
                return View(switchType);
            }
            if (ModelState.IsValid)
            {
                db.Entry(switchType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(switchType);
        }

        // GET: SwitchTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SwitchType switchType = db.SwitchTypes.Find(id);
            if (switchType == null)
            {
                return HttpNotFound();
            }
            return View(switchType);
        }

        // POST: SwitchTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SwitchType switchType = db.SwitchTypes.Find(id);
            db.SwitchTypes.Remove(switchType);
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
