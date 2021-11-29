using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSBD_Sklep.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Zamówienie
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Adres jest wymagany")]
        [StringLength(70)]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Miasto jest wymagane")]
        [StringLength(60)]
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        [StringLength(7)]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Kraj jest wymagany")]
        [StringLength(40)]
        [Display(Name = "Kraj")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [StringLength(15)]
        [Display(Name = "Numer telefonu")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Numer telefonu nie może zawierać innych znaków niż liczby")]
        public string Phone { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Adres Email nie jest prawidłowy")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        public List<SzczegółyZamówienia> OrderDetails { get; set; }

        [Display(Name = "Sposób dostawy:")]
        [Required(ErrorMessage = "Określenie sposobu dostawy jest wymagane!")]
        public int deliveryTypeId { get; set; }
        public virtual DeliveryType deliveryType { get; set; }
        [Display(Name = "Sposób płatności:")]
        [Required(ErrorMessage = "Określenie sposobu płatności jest wymagane!")]
        public int paymentTypeId { get; set; }
        public virtual PaymentType paymentType { get; set; }
        [Display(Name = "Stan realizacji")]
        public int DeliveryStateId { get; set; } = 1;
        public virtual DeliveryState deliveryState { get; set; }
    }
}