using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Firma.PortalWWW.Models.Sklep
{
    public class DaneDoKoszyka
    {
        public List<ElementKoszyka> ElementyKoszyka { get; set; }
        public decimal Razem { get; set; }
    }
}
