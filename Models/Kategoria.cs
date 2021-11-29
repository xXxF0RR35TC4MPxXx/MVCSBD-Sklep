using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class Kategoria
    {
        [Key]
        [Required(ErrorMessage ="Pole jest wymagane!")]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}