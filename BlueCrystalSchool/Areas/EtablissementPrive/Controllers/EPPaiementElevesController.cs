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

namespace BlueCrystalSchool.Areas.EtablissementPrive.Controllers
{
    public class EPPaiementElevesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EtablissementPrive/EPPaiementEleves
        public ActionResult Index()
        {
            var epPaiementEleves = db.EpPaiementEleves.Include(e => e.AnneeScolaire).Include(e => e.EPEleve);
            return View(epPaiementEleves.ToList());
        }

        // GET: EtablissementPrive/EPPaiementEleves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPPaiementEleve ePPaiementEleve = db.EpPaiementEleves.Find(id);
            if (ePPaiementEleve == null)
            {
                return HttpNotFound();
            }
            return View(ePPaiementEleve);
        }

        // GET: EtablissementPrive/EPPaiementEleves/Create
        public ActionResult Create()
        {
            ViewBag.AnneeScolaireId = new SelectList(db.AnneeScolaires, "Id", "Intitule");
            ViewBag.EPEleveId = new SelectList(db.EpEleves, "Id", "NomComplet");
            return View();
        }



        //public ActionResult Create(int? id)
        //{
        //    ViewBag.AnneeScolaireId = new SelectList(db.AnneeScolaires, "Id", "Intitule");
        //    ViewBag.EPEleveId = new SelectList(db.EpEleves, "Id", "NomComplet");
        //    return View();
        //}
        // POST: EtablissementPrive/EPPaiementEleves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EPEleveId,Montant,Reste,AnneeScolaireId,DateVersement,DateProchainPaiement,Observations")] EPPaiementEleve ePPaiementEleve)
        {
            if (ModelState.IsValid)
            {
                db.EpPaiementEleves.Add(ePPaiementEleve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnneeScolaireId = new SelectList(db.AnneeScolaires, "Id", "Intitule", ePPaiementEleve.AnneeScolaireId);
            ViewBag.EPEleveId = new SelectList(db.EpEleves, "Id", "Matricule", ePPaiementEleve.EPEleveId);
            return View(ePPaiementEleve);
        }

        // GET: EtablissementPrive/EPPaiementEleves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPPaiementEleve ePPaiementEleve = db.EpPaiementEleves.Find(id);
            if (ePPaiementEleve == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnneeScolaireId = new SelectList(db.AnneeScolaires, "Id", "Intitule", ePPaiementEleve.AnneeScolaireId);
            ViewBag.EPEleveId = new SelectList(db.EpEleves, "Id", "NomComplet", ePPaiementEleve.EPEleveId);
            return View(ePPaiementEleve);
        }

        // POST: EtablissementPrive/EPPaiementEleves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EPEleveId,Montant,Reste,AnneeScolaireId,DateVersement,DateProchainPaiement,Observations")] EPPaiementEleve ePPaiementEleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePPaiementEleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnneeScolaireId = new SelectList(db.AnneeScolaires, "Id", "Intitule", ePPaiementEleve.AnneeScolaireId);
            ViewBag.EPEleveId = new SelectList(db.EpEleves, "Id", "Matricule", ePPaiementEleve.EPEleveId);
            return View(ePPaiementEleve);
        }

        // GET: EtablissementPrive/EPPaiementEleves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPPaiementEleve ePPaiementEleve = db.EpPaiementEleves.Find(id);
            if (ePPaiementEleve == null)
            {
                return HttpNotFound();
            }
            return View(ePPaiementEleve);
        }

        // POST: EtablissementPrive/EPPaiementEleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EPPaiementEleve ePPaiementEleve = db.EpPaiementEleves.Find(id);
            db.EpPaiementEleves.Remove(ePPaiementEleve);
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
