using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Firma.PortalWWW.Models.Firma;

namespace Firma.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        // GET: Sklep
        private PortalWWWContext db = new PortalWWWContext();

        public ActionResult Search(string search, int? _prize, int? prize_, string sort) {

            if(search.Count() != 0) {
                if(sort == "asc") {
                    if (_prize >= 0 && prize_ >= 0) {
                        return View(db.Towary.Where(x => x.Nazwa.StartsWith(search) && ((x.Cena > _prize) && (x.Cena < prize_))).OrderBy(x => x.Cena).ToList());
                    } else if (_prize >= 0) {
                        return View(db.Towary.Where(x => x.Nazwa.StartsWith(search) && ((x.Cena > _prize))).OrderBy(x => x.Cena).ToList());
                    } else if (prize_ >= 0) {
                        return View(db.Towary.Where(x => x.Nazwa.StartsWith(search) && ((x.Cena < prize_))).OrderBy(x => x.Cena).ToList());
                    } else {
                        return View(db.Towary.Where(x => x.Nazwa.StartsWith(search)).OrderBy(x => x.Cena).ToList());
                    }
                } else {
                    if (_prize >= 0 && prize_ >= 0) {
                        return View(db.Towary.Where(x => x.Nazwa.StartsWith(search) && ((x.Cena > _prize) && (x.Cena < prize_))).OrderByDescending(x => x.Cena).ToList());
                    } else if (_prize >= 0) {
                        return View(db.Towary.Where(x => x.Nazwa.StartsWith(search) && ((x.Cena > _prize))).OrderByDescending(x => x.Cena).ToList());
                    } else if (prize_ >= 0) {
                        return View(db.Towary.Where(x => x.Nazwa.StartsWith(search) && ((x.Cena < prize_))).OrderByDescending(x => x.Cena).ToList());
                    } else {
                        return View(db.Towary.Where(x => x.Nazwa.StartsWith(search)).OrderByDescending(x => x.Cena).ToList());
                    }
                }                
            } else {
                if(sort == "asc") {
                    if (_prize >= 0 && prize_ >= 0) {
                        return View(db.Towary.Where(x => ((x.Cena > _prize) && (x.Cena < prize_))).OrderBy(x => x.Cena).ToList());
                    } else if (_prize >= 0) {
                        return View(db.Towary.Where(x => ((x.Cena > _prize))).OrderBy(x => x.Cena).ToList());
                    } else if (prize_ >= 0) {
                        return View(db.Towary.Where(x => ((x.Cena < prize_))).OrderBy(x => x.Cena).ToList());
                    } else {
                        return View(db.Towary.OrderBy(x => x.Cena).ToList());
                    }
                } else {
                    if (_prize >= 0 && prize_ >= 0) {
                        return View(db.Towary.Where(x => ((x.Cena > _prize) && (x.Cena < prize_))).OrderByDescending(x => x.Cena).ToList());
                    } else if (_prize >= 0) {
                        return View(db.Towary.Where(x => ((x.Cena > _prize))).OrderByDescending(x => x.Cena).ToList());
                    } else if (prize_ >= 0) {
                        return View(db.Towary.Where(x => ((x.Cena < prize_))).OrderByDescending(x => x.Cena).ToList());
                    } else {
                        return View(db.Towary.OrderByDescending(x => x.Cena).ToList());
                    }
                }
            }
        }

        public ActionResult OfertySpecjalne()
        {
            var towaryPromocyjne =
                (
                    from towar in db.Towary
                    where towar.OfertaSpecjalna == true
                    orderby towar.Cena
                    select towar
                ).ToList();
            return View(towaryPromocyjne);
        }


        public ActionResult Index(int? id)
        {
            if (id == null)
                id = db.Rodzaje.First().IdRodzaju;

            var rodzaj = db.Rodzaje.Single(r => r.IdRodzaju == id); 
            return View(rodzaj);
        }

        [ChildActionOnly]
        public ActionResult RodzajeMenu()
        {
            //var rodzaje = db.Rodzaje.ToList();
            var rodzaje =
                (
                    from r in db.Rodzaje
                    orderby r.Nazwa
                    select r
                ).ToList();

            return PartialView(rodzaje);
        }

        public ActionResult Szczegoly(int id)
        {
            var wybranyTowar =
                (
                    from towar in db.Towary
                    where towar.IdTowaru == id
                    select towar
                ).First();
            return View(wybranyTowar);
        }

    }
}