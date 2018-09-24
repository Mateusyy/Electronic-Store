using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Firma.PortalWWW.Models.Sklep;
using Firma.PortalWWW.Models.Sklep.BusinessLogic;
using Firma.PortalWWW.Models.Firma;

namespace Firma.PortalWWW.Controllers
{
    public class ZakupController : Controller
    {
        private PortalWWWContext db = new PortalWWWContext();
        public ActionResult Dane()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            ViewData["wartosc"] = koszyk.GetRazem();
            ViewData["ilosc"] = koszyk.GetIlosc();

            return View();
        }
        [HttpPost]
        public ActionResult Dane(FormCollection values)
        {
            var zamowienie = new Zamowienie();
            try
            {
                TryUpdateModel(zamowienie);
                zamowienie.DataZamowienia = DateTime.Now;
                var koszykB = new KoszykB(this.HttpContext);
                int idZamowienia = koszykB.UtworzZamowienie(zamowienie);
                return RedirectToAction("Podsumowanie", new { id = idZamowienia });
            }
            catch
            {
                return View(zamowienie);
            }
        }
        public ActionResult Podsumowanie(int id)
        {
            var noweZamowienie =
                (
                    from zamowienie in db.Zamowienia
                    where zamowienie.IdZamowienia == id
                    select zamowienie
                ).First();

            if (noweZamowienie != null)
            {
                return View(noweZamowienie);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
