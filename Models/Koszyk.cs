using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class Koszyk
    {
        [Key]
        public int RecordId { get; set; }
        public string KoszykId { get; set; }
        public int ProduktId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Product produkt { get; set; }

    }
}