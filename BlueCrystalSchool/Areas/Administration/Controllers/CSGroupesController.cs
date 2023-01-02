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
    public class CSGroupesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/CSGroupes
        public ActionResult Index()
        {
            var cSGroupes = db.CSGroupes.Include(c => c.CSEnseignant).Include(c => c.CSMatiere).Include(c => c.CsNiveauScolaire);
            return View(cSGroupes.ToList());
        }

        // GET: Administration/CSGroupes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSGroupe cSGroupe = db.CSGroupes
                .Include(m => m.CSMatiere)
                .Include(m =>m.CSEnseignant)
                .Include(m => m.CsNiveauScolaire)
                .FirstOrDefault( d => d.Id == id);

            if (cSGroupe == null)
            {
                return HttpNotFound();
            }
            return View(cSGroupe);
        }

        // GET: Administration/CSGroupes/Create
        public ActionResult Create()
        {
            ViewBag.CSEnseignantId = new SelectList(db.CsEnseignants, "Id", "Nom");
            ViewBag.CSMatiereId = new SelectList(db.CsMatieres, "Id", "NomMatiere");
            ViewBag.CsNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau");
            return View();
        }

        // POST: Administration/CSGroupes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomGroupe,CSMatiereId,CSEnseignantId,CsNiveauScolaireId")] CSGroupe cSGroupe)
        {
            if (ModelState.IsValid)
            {
                db.CSGroupes.Add(cSGroupe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CSEnseignantId = new SelectList(db.CsEnseignants, "Id", "Nom", cSGroupe.CSEnseignantId);
            ViewBag.CSMatiereId = new SelectList(db.CsMatieres, "Id", "NomMatiere", cSGroupe.CSMatiereId);
            ViewBag.CsNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSGroupe.CsNiveauScolaireId);
            return View(cSGroupe);
        }

        // GET: Administration/CSGroupes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSGroupe cSGroupe = db.CSGroupes.Find(id);
            if (cSGroupe == null)
            {
                return HttpNotFound();
            }
            ViewBag.CSEnseignantId = new SelectList(db.CsEnseignants, "Id", "Nom", cSGroupe.CSEnseignantId);
            ViewBag.CSMatiereId = new SelectList(db.CsMatieres, "Id", "NomMatiere", cSGroupe.CSMatiereId);
            ViewBag.CsNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSGroupe.CsNiveauScolaireId);
            return View(cSGroupe);
        }

        // POST: Administration/CSGroupes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomGroupe,CSMatiereId,CSEnseignantId,CsNiveauScolaireId")] CSGroupe cSGroupe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSGroupe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CSEnseignantId = new SelectList(db.CsEnseignants, "Id", "Nom", cSGroupe.CSEnseignantId);
            ViewBag.CSMatiereId = new SelectList(db.CsMatieres, "Id", "NomMatiere", cSGroupe.CSMatiereId);
            ViewBag.CsNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSGroupe.CsNiveauScolaireId);
            return View(cSGroupe);
        }

        // GET: Administration/CSGroupes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSGroupe cSGroupe = db.CSGroupes.Find(id);
            if (cSGroupe == null)
            {
                return HttpNotFound();
            }
            return View(cSGroupe);
        }

        // POST: Administration/CSGroupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSGroupe cSGroupe = db.CSGroupes.Find(id);
            db.CSGroupes.Remove(cSGroupe);
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
