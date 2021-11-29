using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class PaymentType
    {
        [Display(Name = "Sposób płatności")]
        public int Id { get; set; }

        [Display(Name = "Sposób płatności")]
        public string Name { get; set; }
        public virtual ICollection<Zamówienie> Zamówienia { get; set; }
    }
}