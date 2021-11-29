using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class SzczegółyZamówienia
    {
        public int SzczegółyZamówieniaId { get; set; }
        public int OrderId { get; set; }
        public int ProduktId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Product produkt { get; set; }
        public virtual Zamówienie zamowienie { get; set; }
    }
}