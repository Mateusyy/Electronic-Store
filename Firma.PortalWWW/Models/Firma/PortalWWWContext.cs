using System.Data.Entity;
using Firma.PortalWWW.Models.Sklep;

namespace Firma.PortalWWW.Models.Firma
{
    public class PortalWWWContext : DbContext
    {
        public DbSet<Rodzaj> Rodzaje { get; set; }
        public DbSet<Towar> Towary { get; set; }
        public DbSet<ElementKoszyka> ElementyKoszyka { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }
    }
}