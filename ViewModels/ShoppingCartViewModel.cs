using MVCSBD_Sklep.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.ViewModels
{
    public class ShoppingCartViewModel
    {
        [Key]
        public int ShoppingCartViewModelId { get; set; }
        public List<Koszyk> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}