﻿using System.Data.Entity;
using Firma.Intranet.Models.CMS;

namespace Firma.Intranet.Models
{
    public class FirmaIntranetContext : DbContext
    {
        public DbSet<Rodzaj> Rodzaje { get; set; }
        public DbSet<Towar> Towary { get; set; }
        public DbSet<ElementKoszyka> ElementyKoszyka { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }
    }
}
