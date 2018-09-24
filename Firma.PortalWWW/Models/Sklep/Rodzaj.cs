using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Firma.PortalWWW.Models.Sklep
{
    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }
        [Required(ErrorMessage = "Wpisz nazwę")]
        [MaxLength(20, ErrorMessage = "Nazwa powinna zawierać max 20 znaków")]
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public virtual ICollection<Towar> Towar { get; set; }
    }

}