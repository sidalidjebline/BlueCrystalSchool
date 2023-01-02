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
    public class CSTarifCoursParticuliersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/CSTarifCoursParticuliers
        public ActionResult Index()
        {
            var csTarifCoursParticuliers = db.CsTarifCoursParticuliers.Include(c => c.CSNiveauScolaire);
            return View(csTarifCoursParticuliers.ToList());
        }

        // GET: Administration/CSTarifCoursParticuliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarifCoursParticulier cSTarifCoursParticulier = db.CsTarifCoursParticuliers.Find(id);
            if (cSTarifCoursParticulier == null)
            {
                return HttpNotFound();
            }
            return View(cSTarifCoursParticulier);
        }

        // GET: Administration/CSTarifCoursParticuliers/Create
        public ActionResult Create()
        {
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau");
            return View();
        }

        // POST: Administration/CSTarifCoursParticuliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CSNiveauScolaireId,Tarif")] CSTarifCoursParticulier cSTarifCoursParticulier)
        {
            if (ModelState.IsValid)
            {
                db.CsTarifCoursParticuliers.Add(cSTarifCoursParticulier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSTarifCoursParticulier.CSNiveauScolaireId);
            return View(cSTarifCoursParticulier);
        }

        // GET: Administration/CSTarifCoursParticuliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarifCoursParticulier cSTarifCoursParticulier = db.CsTarifCoursParticuliers.Find(id);
            if (cSTarifCoursParticulier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSTarifCoursParticulier.CSNiveauScolaireId);
            return View(cSTarifCoursParticulier);
        }

        // POST: Administration/CSTarifCoursParticuliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CSNiveauScolaireId,Tarif")] CSTarifCoursParticulier cSTarifCoursParticulier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSTarifCoursParticulier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSTarifCoursParticulier.CSNiveauScolaireId);
            return View(cSTarifCoursParticulier);
        }

        // GET: Administration/CSTarifCoursParticuliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarifCoursParticulier cSTarifCoursParticulier = db.CsTarifCoursParticuliers.Find(id);
            if (cSTarifCoursParticulier == null)
            {
                return HttpNotFound();
            }
            return View(cSTarifCoursParticulier);
        }

        // POST: Administration/CSTarifCoursParticuliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSTarifCoursParticulier cSTarifCoursParticulier = db.CsTarifCoursParticuliers.Find(id);
            db.CsTarifCoursParticuliers.Remove(cSTarifCoursParticulier);
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
