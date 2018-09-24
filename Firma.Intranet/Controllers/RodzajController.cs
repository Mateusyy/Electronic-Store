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

namespace Firma.Intranet.Controllers
{
    public class RodzajController : Controller
    {
        private FirmaIntranetContext db = new FirmaIntranetContext();

        // GET: Rodzaj
        public ActionResult Index()
        {
            return View(db.Rodzaje.ToList());
        }

        // GET: Rodzaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rodzaj rodzaj = db.Rodzaje.Find(id);
            if (rodzaj == null)
            {
                return HttpNotFound();
            }
            return View(rodzaj);
        }

        // GET: Rodzaj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rodzaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRodzaju,Nazwa,Opis")] Rodzaj rodzaj)
        {
            if (ModelState.IsValid)
            {
                db.Rodzaje.Add(rodzaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rodzaj);
        }

        // GET: Rodzaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rodzaj rodzaj = db.Rodzaje.Find(id);
            if (rodzaj == null)
            {
                return HttpNotFound();
            }
            return View(rodzaj);
        }

        // POST: Rodzaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRodzaju,Nazwa,Opis")] Rodzaj rodzaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rodzaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rodzaj);
        }

        // GET: Rodzaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rodzaj rodzaj = db.Rodzaje.Find(id);
            if (rodzaj == null)
            {
                return HttpNotFound();
            }
            return View(rodzaj);
        }

        // POST: Rodzaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rodzaj rodzaj = db.Rodzaje.Find(id);
            db.Rodzaje.Remove(rodzaj);
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
