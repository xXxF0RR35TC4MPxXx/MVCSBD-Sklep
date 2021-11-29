using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSBD_Sklep.Models;
using Rotativa;
namespace MVCSBD_Sklep.Controllers
{
    public class StoreController : Controller
    {
        
        XmoreltronikEntities storeDB = new XmoreltronikEntities();
        // GET: Store
        public ActionResult Index()
        {
            var kategorie = storeDB.Categories.ToList();
            return View(kategorie);
        }
        [ValidateInput(false)]
        public ActionResult Browse(string kategoria)
        {
            var kategoriaModel = storeDB.Categories.Include("Products")
        .Single(g => g.Name == kategoria);
            return View(kategoriaModel);
        }

        [ValidateInput(false)]
        public ActionResult ProductsToPDF(string name)
        {
            var list = new ActionAsPdf("Browse", new { kategoria = name })
            {
                FileName = name + " - cennik - X-moreltronik.pdf"
            };
            return list;
        }
        public ActionResult Details(int id)
        {
            var produkt = storeDB.Products.Find(id);

            //ViewBag.Producent = storeDB.Producents.Find(produkt.producent.Id).Name;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopConnection"].ConnectionString))
            {
                connection.Open();
                string commandText = "SELECT Prod.Name from dbo.Producents as Prod, dbo.Products as P WHERE P.Producent_Id = Prod.Id AND P.Id = @idproduktu";
                string commandText2 = "SELECT Cat.Name from dbo.Kategorias as Cat, dbo.Products as P WHERE P.Kategoria_Id1 = Cat.Id AND P.Id = @idproduktu";
                string commandText3 = "SELECT Col.Name from dbo.Colors as Col, dbo.Products as P WHERE P.Color_Id1 = Col.Id AND P.Id = @idproduktu";
                string commandText4 = "SELECT Sw.Name from dbo.SwitchTypes as Sw, dbo.Products as P WHERE P.SwitchType_Id1 = Sw.Id AND P.Id = @idproduktu";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.Add("@idproduktu", SqlDbType.Int);
                    command.Parameters["@idproduktu"].Value = produkt.Id;
                    ViewBag.Producent = command.ExecuteScalar().ToString();

                }
                using (SqlCommand command2 = new SqlCommand(commandText2, connection))
                {
                    command2.Parameters.Add("@idproduktu", SqlDbType.Int);
                    command2.Parameters["@idproduktu"].Value = produkt.Id;
                    ViewBag.Kategoria = command2.ExecuteScalar().ToString();
                }
                using (SqlCommand command3 = new SqlCommand(commandText3, connection))
                {
                    command3.Parameters.Add("@idproduktu", SqlDbType.Int);
                    command3.Parameters["@idproduktu"].Value = produkt.Id;
                    ViewBag.Kolor = command3.ExecuteScalar().ToString();
                    //Console.WriteLine("ViewBag.Kolor = " + ViewBag.Kolor);
                }
                using (SqlCommand command4 = new SqlCommand(commandText4, connection))
                {
                    command4.Parameters.Add("@idproduktu", SqlDbType.Int);
                    command4.Parameters["@idproduktu"].Value = produkt.Id;
                    try
                    {
                        ViewBag.SwitchType = command4.ExecuteScalar().ToString();
                    }catch(NullReferenceException) { connection.Close(); return View(produkt); }
                    //Console.WriteLine("ViewBag.Kolor = " + ViewBag.Kolor);

                }
                connection.Close();
            }
            return View(produkt);
        }

    }
}