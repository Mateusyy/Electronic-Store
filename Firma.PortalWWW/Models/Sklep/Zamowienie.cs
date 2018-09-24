using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Firma.PortalWWW.Models.Sklep
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }
        public System.DateTime DataZamowienia { get; set; }
        public string Login { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Imię")]
        [StringLength(160)]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [Display(Name = "Nazwisko")]
        [StringLength(160)]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(70)]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(70)]
        public string Miasto { get; set; }

        [Required(ErrorMessage = "Province is required")]
        [StringLength(70)]
        [Display(Name = "Województwo")]
        public string Wojewodztwo { get; set; }

        [Required(ErrorMessage = "Address Code is required")]
        [Display(Name = "Kod Pocztowy")]
        [StringLength(10)]
        public string KodPocztowy { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(70)]
        [Display(Name = "Państwo")]
        public string Panstwo { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(24)]
        [Display(Name = "Numer telefonu")]
        public string NumerTelefonu { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "Adres email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email nie jest prawidzłowy.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public decimal Total { get; set; }

        public virtual ICollection<PozycjaZamowienia> PozycjaZamowienia { get; set; }
    }
}
