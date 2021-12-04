using MVCSBD_Sklep.Models;
using System;
using System.Collections.Generic;
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
            var topSellingProdukty = storeDB.Products.OrderByDescending(d => d.OrderCount).Take(10).ToList();
            ViewBag.TopSellingProducts = topSellingProdukty;

            var topProdukty = storeDB.Products.OrderByDescending(d => d.ReleaseDate).Take(10).ToList();
            ViewBag.Produkty = topProdukty;

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
    }
}