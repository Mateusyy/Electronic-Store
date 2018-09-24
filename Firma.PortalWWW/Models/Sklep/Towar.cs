using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Firma.PortalWWW.Models.Sklep
{
    public class Towar
    {
        [Key]
        public int IdTowaru { get; set; }
        [Required(ErrorMessage = "Wpisz nazwę")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Wpisz kod")]
        public string Kod { get; set; }
        [Required(ErrorMessage = "Wpisz cenę")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
        [Display(Name = "Foto URL")]
        [MaxLength(1024, ErrorMessage = "Foto URL powinien zawiuerać max 1024 znaków")]
        public string FotoUrl { get; set; }
        public string KrotkiOpis { get; set; }
        public string Opis { get; set; }
        [Display(Name = "Czy to jest oferta specjalna?")]
        public bool OfertaSpecjalna { get; set; }


        [Required(ErrorMessage = "Wybierz rodzaj")]
        public int IdRodzaju { get; set; }
        public virtual Rodzaj Rodzaj { get; set; }

    }
}