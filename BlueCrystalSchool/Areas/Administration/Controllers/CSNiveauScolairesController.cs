using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueCrystalSchool.Areas.CoursSoutiens.Models;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.Administration.Controllers
{
    public class CSNiveauScolairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/CSNiveauScolaires
        public ActionResult Index()
        {
            var csNiveauScolaires = db.CsNiveauScolaires.Include(c => c.Filiere).Include(c => c.Palier);
            return View(csNiveauScolaires.ToList());
        }

        // GET: Administration/CSNiveauScolaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSNiveauScolaire cSNiveauScolaire = db.CsNiveauScolaires.Find(id);
            if (cSNiveauScolaire == null)
            {
                return HttpNotFound();
            }
            return View(cSNiveauScolaire);
        }

        // GET: Administration/CSNiveauScolaires/Create
        public ActionResult Create()
        {
            ViewBag.FiliereId = new SelectList(db.Filieres, "Id", "Abreviation");
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier");
            return View();
        }

        // POST: Administration/CSNiveauScolaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Niveau,PalierId,FiliereId")] CSNiveauScolaire cSNiveauScolaire)
        {
            if (ModelState.IsValid)
            {
                db.CsNiveauScolaires.Add(cSNiveauScolaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FiliereId = new SelectList(db.Filieres, "Id", "Abreviation", cSNiveauScolaire.FiliereId);
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", cSNiveauScolaire.PalierId);
            return View(cSNiveauScolaire);
        }

        // GET: Administration/CSNiveauScolaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSNiveauScolaire cSNiveauScolaire = db.CsNiveauScolaires.Find(id);
            if (cSNiveauScolaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.FiliereId = new SelectList(db.Filieres, "Id", "Abreviation", cSNiveauScolaire.FiliereId);
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", cSNiveauScolaire.PalierId);
            return View(cSNiveauScolaire);
        }

        // POST: Administration/CSNiveauScolaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Niveau,PalierId,FiliereId")] CSNiveauScolaire cSNiveauScolaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSNiveauScolaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FiliereId = new SelectList(db.Filieres, "Id", "Abreviation", cSNiveauScolaire.FiliereId);
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", cSNiveauScolaire.PalierId);
            return View(cSNiveauScolaire);
        }

        // GET: Administration/CSNiveauScolaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSNiveauScolaire cSNiveauScolaire = db.CsNiveauScolaires.Find(id);
            if (cSNiveauScolaire == null)
            {
                return HttpNotFound();
            }
            return View(cSNiveauScolaire);
        }

        // POST: Administration/CSNiveauScolaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSNiveauScolaire cSNiveauScolaire = db.CsNiveauScolaires.Find(id);
            db.CsNiveauScolaires.Remove(cSNiveauScolaire);
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
