using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCSBD_Sklep.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Producent: ")]
        public int Producent_Id { get; set; }
        public virtual Producent Producent { get; set; }

        [Display(Name = "Model: ")]
        public string Name { get; set; }

        public void SetReleaseDate() { this.ReleaseDate = DateTime.Now; }
        public string GetFullProductName() { return Name; }

        [Display(Name = "Data wydania: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Kategoria: ")]
        [Required(ErrorMessage ="Pole jest wymagane!")]
        public int Kategoria_Id { get; set; }
        public virtual Kategoria Kategoria{ get; set; }

        [Display(Name = "Opis: ")]
        public string Description { get; set; }

        [Display(Name = "RGB: ")]
        public bool? CzyRGB { get; set; }

        [Display(Name = "Max DPI: ")]
        public int? MaxDPI { get; set; }

        [Display(Name = "Ilość przycisków: ")]
        public int? ButtonCount { get; set; }

        [Display(Name = "Rodzaj przełączników: ")]
        public int? SwitchType_Id { get; set; }
        public virtual SwitchType SwitchType{ get; set; }

        [Display(Name = "Kolor obudowy: ")]
        public int? Color_Id { get; set; }
        public virtual Color Color{ get; set; }

        [Display(Name = "Bezprzewodowa: ")]
        public bool? IsWireless { get; set; }

        [Display(Name = "Cena (PLN): ")]
        public decimal Cena { get; set; }

        [Display(Name = "Pliki dodatkowe: ")]
        public virtual ICollection<ExtraFile> PlikiDodatkowe { get; set; }

        public int OrderCount { get; set; } = 0;


    }
}