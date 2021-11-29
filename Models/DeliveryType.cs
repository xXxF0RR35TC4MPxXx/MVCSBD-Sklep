using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSBD_Sklep.Models
{
    public class DeliveryType
    {
        [Display(Name = "Sposób dostawy")]
        public int Id { get; set; }
        [Display(Name="Sposób dostawy")]
        public string Name { get; set; }
        public virtual ICollection<Zamówienie> Zamówienia { get; set; }

    }
}