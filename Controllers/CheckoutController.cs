using MVCSBD_Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSBD_Sklep.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        // GET: Checkout
        XmoreltronikEntities storeDB = new XmoreltronikEntities();
        public ActionResult AddressAndPayment()
        {
            ViewBag.DeliveryTypes = new SelectList(storeDB.DeliveryTypes, "Id", "Name");
            ViewBag.PaymentTypes = new SelectList(storeDB.PaymentTypes, "Id", "Name");
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            ViewBag.DeliveryTypes = new SelectList(storeDB.DeliveryTypes, "Id", "Name");
            ViewBag.PaymentTypes = new SelectList(storeDB.PaymentTypes, "Id", "Name");

            var order = new Zamówienie();
            TryUpdateModel(order);

            var valuesKod = values["PromoCode"].ToLower();
            DiscountCode kod = storeDB.DiscountCodes.Where(
                d => d.Code.ToLower() == valuesKod && 
                d.ValidUntil > DateTime.Now && 
                d.DlaKtóregoUżytkownika.ToLower() == User.Identity.Name.ToLower())
                    .FirstOrDefault();
            try
            {
                if (kod == null) //jeżeli nie ma ważnego kodu o podanej nazwie
                {
                    if (!String.IsNullOrEmpty(valuesKod)) //jeśli podano nieważny kod
                    {
                        ViewData["promoInvalid"] = "Nie ma takiego kodu rabatowego lub został już wykorzystany!";
                        return View(order);
                    }
                    //jeżeli nie podano żadnego kodu
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    order.Email = User.Identity.Name;
                    order.Total = cart.GetTotal();

                    //Save Order
                    storeDB.Zamówienia.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    cart.CreateOrder(order);

                    

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
                else //jeśli znaleziono ważny kod o podanej nazwie
                {
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    order.Email = User.Identity.Name;
                    order.Total = (cart.GetTotal() * (decimal)((float)(100 - kod.Discount) / 100.00));

                    //Save Order
                    storeDB.Zamówienia.Add(order);
                    //dezaktywacja kodu rabatowego - zakładamy, że są jednorazowe
                    kod.ValidUntil = DateTime.Now.AddDays(-7);
                    storeDB.SaveChanges();
                    //Process the order
                    cart.CreateOrder(order);

                    
                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }

        }


        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Zamówienia.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                Zamówienie xd = storeDB.Zamówienia.FirstOrDefault(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

                List<SzczegółyZamówienia> details = new List<SzczegółyZamówienia>(); //nowa lista szczegółów dodawanego zamówienia
                details = storeDB.OrderDetails.Where(o => o.OrderId == xd.OrderId).ToList();
                foreach(SzczegółyZamówienia x in details) //przechodzę po konkretnych pozycjach z danego zamówienia
                {
                    Product tempProd = storeDB.Products.First(p => p.Id == x.ProduktId); //do każdego zamawianego produktu
                    tempProd.OrderCount += x.Quantity; //dopisuję zamówioną ilość
                    storeDB.SaveChanges();
                }

                return View(xd);
            }
            else
            {
                return View("Error");
            }
        }

    }
}