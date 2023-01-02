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
    public class EPClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/EPClasses
        public ActionResult Index()
        {
            var epClasses = db.EpClasses.Include(e => e.EPNiveauScolaire);
            return View(epClasses.ToList());
        }

        // GET: Administration/EPClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPClasse ePClasse = db.EpClasses.Find(id);
            if (ePClasse == null)
            {
                return HttpNotFound();
            }
            return View(ePClasse);
        }

        // GET: Administration/EPClasses/Create
        public ActionResult Create()
        {
            ViewBag.EPNiveauScolaireId = new SelectList(db.EpNiveauScolaires, "Id", "Niveau");
            return View();
        }

        // POST: Administration/EPClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EPNiveauScolaireId,NomClasse,NomSalle,NombreMaxEleves,NombrePlacesDisponibles")] EPClasse ePClasse)
        {
            if (ModelState.IsValid)
            {
                db.EpClasses.Add(ePClasse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EPNiveauScolaireId = new SelectList(db.EpNiveauScolaires, "Id", "Niveau", ePClasse.EPNiveauScolaireId);
            return View(ePClasse);
        }

        // GET: Administration/EPClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPClasse ePClasse = db.EpClasses.Find(id);
            if (ePClasse == null)
            {
                return HttpNotFound();
            }
            ViewBag.EPNiveauScolaireId = new SelectList(db.EpNiveauScolaires, "Id", "Niveau", ePClasse.EPNiveauScolaireId);
            return View(ePClasse);
        }

        // POST: Administration/EPClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EPNiveauScolaireId,NomClasse,NomSalle,NombreMaxEleves,NombrePlacesDisponibles")] EPClasse ePClasse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePClasse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EPNiveauScolaireId = new SelectList(db.EpNiveauScolaires, "Id", "Niveau", ePClasse.EPNiveauScolaireId);
            return View(ePClasse);
        }

        // GET: Administration/EPClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPClasse ePClasse = db.EpClasses.Find(id);
            if (ePClasse == null)
            {
                return HttpNotFound();
            }
            return View(ePClasse);
        }

        // POST: Administration/EPClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EPClasse ePClasse = db.EpClasses.Find(id);
            db.EpClasses.Remove(ePClasse);
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
