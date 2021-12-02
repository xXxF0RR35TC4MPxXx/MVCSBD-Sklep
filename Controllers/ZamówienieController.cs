using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSBD_Sklep.Models;

namespace MVCSBD_Sklep.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public ActionResult Edit(FormCollection values)
        {
           //w podejściu sql-owym edycja zamówień działa idealnie
            
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCSBD_Sklep.Models.XmoreltronikEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string queryString = "UPDATE dbo.Zamówienie SET " +
                    "Username = @username, " +
                    "FirstName = @firstname, " +
                    "LastName = @lastname, " +
                    "Address = @address, " +
                    "City = @city, " + 
                    "PostalCode = @postalcode, " + 
                    "Country = @country, " + 
                    "Phone = @phone, " + 
                    "Email = @email, " + 
                    "Total = @total, " +
                    "OrderDate = @orderdate, " +
                    "deliveryTypeId = @delTypeId, " +
                    "paymentTypeId = @payTypeId, " + 
                    "DeliveryStateId = @delStateId WHERE OrderId = @Id;";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = int.Parse(values[1]);

                command.Parameters.Add("@username", SqlDbType.NVarChar);
                command.Parameters["@username"].Value = values[2];

                command.Parameters.Add("@firstname", SqlDbType.NVarChar);
                command.Parameters["@firstname"].Value = values[3];

                command.Parameters.Add("@lastname", SqlDbType.NVarChar);
                command.Parameters["@lastname"].Value = values[4];

                command.Parameters.Add("@address", SqlDbType.NVarChar);
                command.Parameters["@address"].Value = values[5];

                command.Parameters.Add("@city", SqlDbType.NVarChar);
                command.Parameters["@city"].Value = values[6];

                command.Parameters.Add("@postalcode", SqlDbType.NVarChar);
                command.Parameters["@postalcode"].Value = values[7];

                command.Parameters.Add("@country", SqlDbType.NVarChar);
                command.Parameters["@country"].Value = values[8];

                command.Parameters.Add("@phone", SqlDbType.NVarChar);
                command.Parameters["@phone"].Value = values[9];

                command.Parameters.Add("@email", SqlDbType.NVarChar);
                command.Parameters["@email"].Value = values[10];

                command.Parameters.Add("@total", SqlDbType.Decimal);
                command.Parameters["@total"].Value = decimal.Parse(values[11]);

                command.Parameters.Add("@orderdate", SqlDbType.DateTime2);
                command.Parameters["@orderdate"].Value = DateTime.Now;

                command.Parameters.Add("@delTypeId", SqlDbType.Int);
                command.Parameters["@delTypeId"].Value = int.Parse(values[13]);

                command.Parameters.Add("@payTypeId", SqlDbType.Int);
                command.Parameters["@payTypeId"].Value = int.Parse(values[14]);

                command.Parameters.Add("@delStateId", SqlDbType.Int);
                command.Parameters["@delStateId"].Value = int.Parse(values[15]);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            Zamówienie zam = new Zamówienie();
            ViewBag.DeliveryStateId = new SelectList(db.DeliveryStates, "Id", "Name", zam.DeliveryStateId);
            ViewBag.deliveryTypeId = new SelectList(db.DeliveryTypes, "Id", "Name", zam.deliveryTypeId);
            ViewBag.paymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name", zam.paymentTypeId);

            //Używając poniższego podejścia:
            //NIE DZIAŁA EDYTOWANIE ZAMÓWIEŃ - NIE MAM POJĘCIA CZEMU
            //Wywala, że edytowano 0 rekordów w bazie ciągle

            //if (ModelState.IsValid) //mimo, że ModelState JEST Valid
            //{
            //    db.Entry(stare).State = EntityState.Modified;
            //    db.SaveChanges(); //w tym momencie wywala, jakby nie mógł zapisać do bazy albo jakby dane były złe...tory też były złe. 
            //    
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
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
