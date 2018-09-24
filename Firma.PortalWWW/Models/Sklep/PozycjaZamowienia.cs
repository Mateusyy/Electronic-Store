using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Firma.PortalWWW.Models.Sklep
{
    public class PozycjaZamowienia
    {
        [Key]
        public int IdPozycjiZamowienia { get; set; }
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }

        public int IdTowaru { get; set; }
        public virtual Towar Towar { get; set; }

        public int IdZamowienia { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}
