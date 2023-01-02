using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueCrystalSchool.Areas.EtablissementPrive.Models;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.Administration.Controllers
{
    public class EPTarifPalierEnseignantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/EPTarifPalierEnseignants
        public ActionResult Index()
        {
            var epTarifPalierEnseignants = db.EpTarifPalierEnseignants.Include(e => e.Palier);
            return View(epTarifPalierEnseignants.ToList());
        }

        // GET: Administration/EPTarifPalierEnseignants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPTarifPalierEnseignant ePTarifPalierEnseignant = db.EpTarifPalierEnseignants.Find(id);
            if (ePTarifPalierEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(ePTarifPalierEnseignant);
        }

        // GET: Administration/EPTarifPalierEnseignants/Create
        public ActionResult Create()
        {
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier");
            return View();
        }

        // POST: Administration/EPTarifPalierEnseignants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PalierId,TarifParHeure")] EPTarifPalierEnseignant ePTarifPalierEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.EpTarifPalierEnseignants.Add(ePTarifPalierEnseignant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePTarifPalierEnseignant.PalierId);
            return View(ePTarifPalierEnseignant);
        }

        // GET: Administration/EPTarifPalierEnseignants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPTarifPalierEnseignant ePTarifPalierEnseignant = db.EpTarifPalierEnseignants.Find(id);
            if (ePTarifPalierEnseignant == null)
            {
                return HttpNotFound();
            }
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePTarifPalierEnseignant.PalierId);
            return View(ePTarifPalierEnseignant);
        }

        // POST: Administration/EPTarifPalierEnseignants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PalierId,TarifParHeure")] EPTarifPalierEnseignant ePTarifPalierEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePTarifPalierEnseignant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePTarifPalierEnseignant.PalierId);
            return View(ePTarifPalierEnseignant);
        }

        // GET: Administration/EPTarifPalierEnseignants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPTarifPalierEnseignant ePTarifPalierEnseignant = db.EpTarifPalierEnseignants.Find(id);
            if (ePTarifPalierEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(ePTarifPalierEnseignant);
        }

        // POST: Administration/EPTarifPalierEnseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EPTarifPalierEnseignant ePTarifPalierEnseignant = db.EpTarifPalierEnseignants.Find(id);
            db.EpTarifPalierEnseignants.Remove(ePTarifPalierEnseignant);
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
