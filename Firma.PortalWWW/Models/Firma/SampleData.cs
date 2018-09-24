using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Firma.PortalWWW.Models.Sklep;

namespace Firma.PortalWWW.Models.Firma
{
    public class SampleData : DropCreateDatabaseIfModelChanges<PortalWWWContext>
    {
        protected override void Seed(PortalWWWContext context)
        {
            var rodzaje = new List<Rodzaj>
            {
                new Rodzaj{ Nazwa="Rodzaj 1", Opis="Opis rodzaj 1"},
                new Rodzaj{ Nazwa="Rodzaj 2",Opis="Opis rodzaj 2"},
                new Rodzaj{ Nazwa="Rodzaj 3",Opis="Opis rodzaj 3"},
                new Rodzaj{ Nazwa="Rodzaj 4",Opis="Opis rodzaj 4"},
                new Rodzaj{ Nazwa="Rodzaj 5",Opis="Opis rodzaj 5"}
            };
            foreach (var item in rodzaje)
                context.Rodzaje.Add(item);

            var towary = new List<Towar>
            {
                new Towar{ Nazwa="Towar 1", Kod="1", Opis="Opis towar 1", Cena=1, FotoUrl="/Content/Images/image1.jpg", IdRodzaju=1, OfertaSpecjalna=true},
                new Towar{ Nazwa="Towar 2", Kod="2", Opis="Opis towar 2", Cena=2, FotoUrl="/Content/Images/image2.jpg", IdRodzaju=2, OfertaSpecjalna=true},
                new Towar{ Nazwa="Towar 3", Kod="3", Opis="Opis towar 3", Cena=3, FotoUrl="/Content/Images/image3.jpg", IdRodzaju=3, OfertaSpecjalna=true},
                new Towar{ Nazwa="Towar 4", Kod="4", Opis="Opis towar 4", Cena=4, FotoUrl="/Content/Images/image4.jpg", IdRodzaju=4, OfertaSpecjalna=true},
                new Towar{ Nazwa="Towar 5", Kod="5", Opis="Opis towar 5", Cena=5, FotoUrl="/Content/Images/image5.jpg", IdRodzaju=5, OfertaSpecjalna=true},
                new Towar{ Nazwa="Towar 6", Kod="6", Opis="Opis towar 6", Cena=6, FotoUrl="/Content/Images/image1.jpg", IdRodzaju=6, OfertaSpecjalna=true},
                new Towar{ Nazwa="Towar 7", Kod="7", Opis="Opis towar 7", Cena=7, FotoUrl="/Content/Images/image2.jpg", IdRodzaju=7, OfertaSpecjalna=true},
                new Towar{ Nazwa="Towar 8", Kod="8", Opis="Opis towar 8", Cena=8, FotoUrl="/Content/Images/image3.jpg", IdRodzaju=8, OfertaSpecjalna=true},

            };
            foreach (var item in towary)
                context.Towary.Add(item);

        }
    }
}
