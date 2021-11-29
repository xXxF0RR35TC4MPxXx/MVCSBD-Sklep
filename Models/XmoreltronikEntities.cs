using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class XmoreltronikEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Kategoria> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ExtraFile> ExtraFiles { get; set; }
        public DbSet<Producent> Producents { get; set; }
        public DbSet<SwitchType> SwitchTypes { get; set; }

        public DbSet<Koszyk> Koszyki { get; set; }
        public DbSet<Zamówienie> Zamówienia { get; set; }
        public DbSet<SzczegółyZamówienia> OrderDetails { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<DeliveryState> DeliveryStates { get; set; }
        public System.Data.Entity.DbSet<MVCSBD_Sklep.ViewModels.ShoppingCartViewModel> ShoppingCartViewModels { get; set; }
    }
}