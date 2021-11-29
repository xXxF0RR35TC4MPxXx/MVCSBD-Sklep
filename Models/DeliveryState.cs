using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class DeliveryState
    {
        [Display(Name = "Stan realizacji")]
        public int Id { get; set; }

        [Display(Name = "Stan realizacji zamówienia")]
        public string Name { get; set; }
        public virtual ICollection<Zamówienie> Zamówienia { get; set; }
    }
}