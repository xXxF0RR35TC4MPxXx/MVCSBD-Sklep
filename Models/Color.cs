using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}