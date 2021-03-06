﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Firma.Intranet.Models.CMS
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