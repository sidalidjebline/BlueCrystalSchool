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
    public class EPNiveauScolairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/EPNiveauScolaires
        public ActionResult Index()
        {
            var epNiveauScolaires = db.EpNiveauScolaires.Include(e => e.Filiere).Include(e => e.Palier);
            return View(epNiveauScolaires.ToList());
        }

        // GET: Administration/EPNiveauScolaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPNiveauScolaire ePNiveauScolaire = db.EpNiveauScolaires.Find(id);
            if (ePNiveauScolaire == null)
            {
                return HttpNotFound();
            }
            return View(ePNiveauScolaire);
        }

        // GET: Administration/EPNiveauScolaires/Create
        public ActionResult Create()
        {
            ViewBag.FiliereId = new SelectList(db.Filieres, "Id", "NomFiliere");
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier");
            return View();
        }

        // POST: Administration/EPNiveauScolaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Niveau,PalierId,FiliereId,FraisInscription,TarifPaiementAnnuel,TarifPaiementTroisTranches,TarifPaiementMensuel")] EPNiveauScolaire ePNiveauScolaire)
        {
            if (ModelState.IsValid)
            {
                db.EpNiveauScolaires.Add(ePNiveauScolaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FiliereId = new SelectList(db.Filieres, "Id", "NomFiliere", ePNiveauScolaire.FiliereId);
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePNiveauScolaire.PalierId);
            return View(ePNiveauScolaire);
        }

        // GET: Administration/EPNiveauScolaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPNiveauScolaire ePNiveauScolaire = db.EpNiveauScolaires.Find(id);
            if (ePNiveauScolaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.FiliereId = new SelectList(db.Filieres, "Id", "NomFiliere", ePNiveauScolaire.FiliereId);
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePNiveauScolaire.PalierId);
            return View(ePNiveauScolaire);
        }

        // POST: Administration/EPNiveauScolaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Niveau,PalierId,FiliereId,FraisInscription,TarifPaiementAnnuel,TarifPaiementTroisTranches,TarifPaiementMensuel")] EPNiveauScolaire ePNiveauScolaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePNiveauScolaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FiliereId = new SelectList(db.Filieres, "Id", "NomFiliere", ePNiveauScolaire.FiliereId);
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePNiveauScolaire.PalierId);
            return View(ePNiveauScolaire);
        }

        // GET: Administration/EPNiveauScolaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPNiveauScolaire ePNiveauScolaire = db.EpNiveauScolaires.Find(id);
            if (ePNiveauScolaire == null)
            {
                return HttpNotFound();
            }
            return View(ePNiveauScolaire);
        }

        // POST: Administration/EPNiveauScolaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EPNiveauScolaire ePNiveauScolaire = db.EpNiveauScolaires.Find(id);
            db.EpNiveauScolaires.Remove(ePNiveauScolaire);
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
