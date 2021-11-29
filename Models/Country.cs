using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Producent> Producers { get; set; }
    }
}