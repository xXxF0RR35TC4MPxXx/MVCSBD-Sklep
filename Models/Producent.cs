using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class Producent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Product> Products { get; set; }

    }
}