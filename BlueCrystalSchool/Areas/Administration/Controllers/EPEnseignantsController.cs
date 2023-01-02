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
    public class EPEnseignantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/EPEnseignants
        public ActionResult Index()
        {
            var epEnseignants = db.EpEnseignants.Include(e => e.Palier);
            return View(epEnseignants.ToList());
        }

        // GET: Administration/EPEnseignants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ePEnseignant = db.EpEnseignants.Include(e => e.Palier).First(t => t.Id == id);
            if (ePEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(ePEnseignant);
        }

        // GET: Administration/EPEnseignants/Create
        public ActionResult Create()
        {
            var model = new EPEnseignant();
            ViewBag.Matieres = new MultiSelectList(db.CsMatieres.ToList(), "Id", "NomMatiere", model.EPMatieres);//db.CsMatieres.ToList();

            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier");
            return View();
        }

        // POST: Administration/EPEnseignants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,DateNaissance,CommuneNaissance,PalierId,DonneCoursSoutien,DonneCoursParticulier")] EPEnseignant ePEnseignant, int[] matieresids)
        {
            if (ModelState.IsValid)
            {
                List<EPMatiere> mats = new List<EPMatiere>();
                foreach (var item in matieresids)
                {
                    //   var tt = db.CsMatieres.Include(c => c.Id == item);
                    EPMatiere tt = db.EpMatieres.Find(item);
                    mats.Add(tt);
                    //CSMatiereCSEleves dd = new CSMatiereCSEleves();
                    //dd.CSEleveId = cSEnseignant.Id;
                    //dd.CSMatiereId = item;
                    ////      dd.Particulier = false;
                    //dd.DateInscription = DateTime.Today;
                    //db.CsMatiereCsEleves.Add(dd);

                }

                ePEnseignant.EPMatieres = mats;
                db.EpEnseignants.Add(ePEnseignant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePEnseignant.PalierId);
            return View(ePEnseignant);
        }

        // GET: Administration/EPEnseignants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPEnseignant ePEnseignant = db.EpEnseignants.Find(id);
            if (ePEnseignant == null)
            {
                return HttpNotFound();
            }
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePEnseignant.PalierId);
            return View(ePEnseignant);
        }

        // POST: Administration/EPEnseignants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,DateNaissance,CommuneNaissance,PalierId,DonneCoursSoutien,DonneCoursParticulier")] EPEnseignant ePEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePEnseignant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", ePEnseignant.PalierId);
            return View(ePEnseignant);
        }

        // GET: Administration/EPEnseignants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPEnseignant ePEnseignant = db.EpEnseignants.Find(id);
            if (ePEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(ePEnseignant);
        }

        // POST: Administration/EPEnseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EPEnseignant ePEnseignant = db.EpEnseignants.Find(id);
            db.EpEnseignants.Remove(ePEnseignant);
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
