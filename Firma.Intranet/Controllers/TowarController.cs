using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Firma.Intranet.Models;
using Firma.Intranet.Models.CMS;
using System.IO;

namespace Firma.Intranet.Controllers
{
    public class TowarController : Controller
    {
        private FirmaIntranetContext db = new FirmaIntranetContext();

        // GET: Towar
        public ActionResult Index()
        {
            var towars = db.Towary.Include(t => t.Rodzaj);
            return View(towars.ToList());
        }

        // GET: Towar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towary.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // GET: Towar/Create
        public ActionResult Create()
        {
            ViewBag.IdRodzaju = new SelectList(db.Rodzaje, "IdRodzaju", "Nazwa");
            return View();
        }

        // POST: Towar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Towar towar, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file.ContentLength > 0)
            {
                db.Towary.Add(towar);
                db.SaveChanges();
                var fileName = Path.GetFileName(file.FileName);// dodaj using System.IO;
                var path = Path.Combine(Server.MapPath("~/Content/Images"), towar.IdTowaru.ToString() + ".jpg");
                file.SaveAs(path);

                //koniecznie zmien sciezke na swoja
                var path2 = Path.Combine("C:/Users/Artur/Desktop/TM/Firma/Firma.PortalWWW/Content/Images", towar.IdTowaru.ToString() + ".jpg");
                file.SaveAs(path2);

                towar.FotoUrl = "/Content/Images/" + towar.IdTowaru.ToString() + ".jpg";
                db.SaveChanges();



                return RedirectToAction("Index");
            }

            ViewBag.IdRodzaju = new SelectList(db.Rodzaje, "IdRodzaju", "Nazwa", towar.IdRodzaju);

            return View(towar);
        }


        // GET: Towar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towary.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRodzaju = new SelectList(db.Rodzaje, "IdRodzaju", "Nazwa", towar.IdRodzaju);
            return View(towar);
        }

        // POST: Towar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTowaru,Nazwa,Kod,Cena,FotoUrl,KrotkiOpis,Opis,OfertaSpecjalna,IdRodzaju")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(towar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRodzaju = new SelectList(db.Rodzaje, "IdRodzaju", "Nazwa", towar.IdRodzaju);
            return View(towar);
        }

        // GET: Towar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towary.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // POST: Towar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Towar towar = db.Towary.Find(id);
            db.Towary.Remove(towar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
