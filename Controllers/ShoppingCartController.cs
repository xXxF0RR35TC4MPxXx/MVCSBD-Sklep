using MVCSBD_Sklep.Models;
using MVCSBD_Sklep.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
namespace ProjektMVCPodejscie4.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        XmoreltronikEntities storeDB = new XmoreltronikEntities();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart();

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            List<Producent> producentList = new List<Producent>();
            foreach (var p in viewModel.CartItems)
            {
                Producent producent = null;
                Product produkt = storeDB.Products.First(x => x.Id == p.ProduktId); //lista produktów z tego zamówienia
                if (produkt != null)
                {
                    producent = storeDB.Producents.First(x => x.Id == produkt.Producent_Id);
                }
                else RedirectToAction("Index", "Home");
                producentList.Add(producent);
            }
            ViewBag.Producenci = producentList;


            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedProduct = storeDB.Products
                .Single(prod => prod.Id == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedProduct);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the product to display confirmation
            string productName = storeDB.Koszyki
                .Single(item => item.RecordId == id).produkt.Name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                    " został usunięty z twojego koszyka.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}