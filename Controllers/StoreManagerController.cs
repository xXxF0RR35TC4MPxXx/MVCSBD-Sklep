using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSBD_Sklep.Models;

namespace MVCSBD_Sklep.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoreManagerController : Controller
    {
        private XmoreltronikEntities db = new XmoreltronikEntities();

        // GET: StoreManager
        public string Nazwa(Product it)
        {
            string temp = db.Producents.FirstOrDefault(p => p.Id == it.Producent_Id).Name;
            return temp;
        }

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            var prod = db.Producents.FirstOrDefault(p => p.Id == product.Producent_Id).Name;
            ViewBag.prod = prod;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.Producenci = new SelectList(db.Producents, "Id", "Name", "Country_Id");
            ViewBag.Kategorie = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Kolory = new SelectList(db.Colors, "Id", "Name");
            ViewBag.Switche = new SelectList(db.SwitchTypes, "Id", "Name");
            return View();
        }

        // POST: StoreManager/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Producent_Id,Color_Id,Kategoria_Id,Name,ReleaseDate,Description,CzyRGB,MaxDPI,ButtonCount,IsWireless,Cena,SwitchType_Id")] Product product)
        {
            ViewBag.Producenci = new SelectList(db.Producents, "Id", "Name", "Country_Id");
            ViewBag.Kategorie = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Kolory = new SelectList(db.Colors, "Id", "Name");
            ViewBag.Switche = new SelectList(db.SwitchTypes, "Id", "Name");
            Product czyIstnieje = db.Products.FirstOrDefault(p => p.Name.ToLower() == product.Name.ToLower());
            if (czyIstnieje != null)
            {
                ViewBag.Message = "Produkt o podanej nazwie już istnieje!";
                return View(product);
            }
            product.SetReleaseDate();
            if (ModelState.IsValid)
            {
                
                product.Producent = db.Producents.FirstOrDefault(p => p.Id == product.Producent_Id);
                product.Color = db.Colors.FirstOrDefault(p => p.Id == product.Color_Id);
                product.SwitchType = db.SwitchTypes.FirstOrDefault(p => p.Id == product.SwitchType_Id);
                product.Kategoria = db.Categories.FirstOrDefault(p => p.Id == product.Kategoria_Id);

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Producenci = new SelectList(db.Producents, "Id", "Name", "Country_Id");
            ViewBag.Kategorie = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Kolory = new SelectList(db.Colors, "Id", "Name");

            ViewBag.Switche = new SelectList(db.SwitchTypes, "Id", "Name");
            //var prod = db.Products.First(i => i.Id == id);
            //TempData["KategoriaID"] = db.Categories.FirstOrDefault(g => g.Id == prod.Kategoria_Id).Id;
            //TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: StoreManager/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            
            ViewBag.Producenci = new SelectList(db.Producents, "Id", "Name", "Country_Id");
            ViewBag.Kategorie = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Kolory = new SelectList(db.Colors, "Id", "Name");
            ViewBag.Switche = new SelectList(db.SwitchTypes, "Id", "Name");
            
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCSBD_Sklep.Models.XmoreltronikEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    string queryString = "UPDATE dbo.Products SET Kategoria_Id1 = Kategoria_Id WHERE Id = @id;";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@id", SqlDbType.Int);
                    command.Parameters["@id"].Value = product.Id;

                    string queryString2 = "UPDATE dbo.Products SET Producent_Id1 = Producent_Id WHERE Id = @id;";
                    SqlCommand command2 = new SqlCommand(queryString2, connection);
                    command2.Parameters.Add("@id", SqlDbType.Int);
                    command2.Parameters["@id"].Value = product.Id;

                    string queryString3 = "UPDATE dbo.Products SET Color_Id1 = Color_Id WHERE Id = @id;";
                    SqlCommand command3 = new SqlCommand(queryString3, connection);
                    command3.Parameters.Add("@id", SqlDbType.Int);
                    command3.Parameters["@id"].Value = product.Id;

                    string queryString4 = "UPDATE dbo.Products SET SwitchType_Id1 = SwitchType_Id WHERE Id = @id;";
                    SqlCommand command4 = new SqlCommand(queryString4, connection);
                    command4.Parameters.Add("@id", SqlDbType.Int);
                    command4.Parameters["@id"].Value = product.Id;

                    connection.Open();
                    command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command4.ExecuteNonQuery();
                    connection.Close();
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            var prod = db.Producents.FirstOrDefault(p => p.Id == product.Producent_Id).Name;
            ViewBag.prod = prod;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
