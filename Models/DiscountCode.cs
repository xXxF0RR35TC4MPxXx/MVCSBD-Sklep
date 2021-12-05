using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class DiscountCode
    {

        [Display(Name = "Identyfikator kodu")]
        public int DiscountCodeId { get; set; }

        [Display(Name = "Treść kodu")]
        public string Code { get; set; }

        [Range(0, 100, ErrorMessage = "Procent zniżki musi być między 0 a 100")]
        [Display(Name = "Procent zniżki (od 0 do 100)")]
        public int Discount { get; set; }


        [Display(Name = "Kod ważny do dnia")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ValidUntil { get; set; }

        [Display(Name = "Dla którego usera:")]
        public string DlaKtóregoUżytkownika { get; set; }
    }
}