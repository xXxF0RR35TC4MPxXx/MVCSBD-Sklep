using MVCSBD_Sklep.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSBD_Sklep.Controllers
{
    public class HomeController : Controller
    {
        XmoreltronikEntities storeDB = new XmoreltronikEntities();
        public ActionResult Index()
        {
            List<Product> topSellingProdukty = storeDB.Products.OrderByDescending(d => d.OrderCount).Take(10).ToList();
            ViewBag.TopSellingProducts = topSellingProdukty;

            List<Product> topProdukty = storeDB.Products.OrderByDescending(d => d.ReleaseDate).Take(10).ToList();
            ViewBag.Produkty = topProdukty;
            if (User.Identity.IsAuthenticated) { 
                DiscountCode twójKodRabatowy = storeDB.DiscountCodes.FirstOrDefault(
                    c => c.DlaKtóregoUżytkownika.ToLower() == User.Identity.Name.ToLower()
                    && c.ValidUntil > DateTime.Now);
                if (twójKodRabatowy != null)
                    ViewBag.Promocja = twójKodRabatowy;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public FileResult FileDownload(string path)
        {
            return new FileStreamResult(new FileStream(path, FileMode.Open), "image");
        }
    }
}
