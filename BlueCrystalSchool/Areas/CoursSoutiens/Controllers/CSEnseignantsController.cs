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

namespace BlueCrystalSchool.Areas.CoursSoutiens.Controllers
{
    public class CSEnseignantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CoursSoutiens/CSEnseignants
        public ActionResult Index()
        {
            var csEnseignants = db.CsEnseignants.Include(c => c.Palier);
            return View(csEnseignants.ToList());
        }

        // GET: CoursSoutiens/CSEnseignants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          //  CSEnseignant cSEnseignant = db.CsEnseignants.Find(id);
            CSEnseignant cSEnseignant = db.CsEnseignants.Include(a => a.CSMatieres).FirstOrDefault(t => t.Id == id);

            if (cSEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(cSEnseignant);
        }

        // GET: CoursSoutiens/CSEnseignants/Create
        public ActionResult Create()
        {
            var model = new CSEnseignant();
            ViewBag.Matieres = new MultiSelectList(db.CsMatieres.ToList(), "Id", "NomMatiere", model.CSMatieres);//db.CsMatieres.ToList();

            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier");
            return View();
        }

        // POST: CoursSoutiens/CSEnseignants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,DateNaissance,CommuneNaissance,Telephone,Adresse,PalierId,CoursSoutien,CoursParticuliers")] CSEnseignant cSEnseignant, int[] matieresids)
        {
            if (ModelState.IsValid)
            {
             
              //  db.SaveChanges();

                List<CSMatiere> mats = new List<CSMatiere>();
                foreach (var item in matieresids)
                {
                 //   var tt = db.CsMatieres.Include(c => c.Id == item);
                    CSMatiere tt = db.CsMatieres.Find(item);
                   mats.Add(tt);
                    //CSMatiereCSEleves dd = new CSMatiereCSEleves();
                    //dd.CSEleveId = cSEnseignant.Id;
                    //dd.CSMatiereId = item;
                    ////      dd.Particulier = false;
                    //dd.DateInscription = DateTime.Today;
                    //db.CsMatiereCsEleves.Add(dd);

                }

                cSEnseignant.CSMatieres = mats;
                db.CsEnseignants.Add(cSEnseignant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", cSEnseignant.PalierId);
            return View(cSEnseignant);
        }

        // GET: CoursSoutiens/CSEnseignants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSEnseignant cSEnseignant = db.CsEnseignants.Find(id);
            if (cSEnseignant == null)
            {
                return HttpNotFound();
            }
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", cSEnseignant.PalierId);
            return View(cSEnseignant);
        }

        // POST: CoursSoutiens/CSEnseignants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,DateNaissance,CommuneNaissance,Telephone,Adresse,PalierId,CoursSoutien,CoursParticuliers")] CSEnseignant cSEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSEnseignant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PalierId = new SelectList(db.Paliers, "Id", "NomPalier", cSEnseignant.PalierId);
            return View(cSEnseignant);
        }

        // GET: CoursSoutiens/CSEnseignants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSEnseignant cSEnseignant = db.CsEnseignants.Find(id);
            if (cSEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(cSEnseignant);
        }

        // POST: CoursSoutiens/CSEnseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSEnseignant cSEnseignant = db.CsEnseignants.Find(id);
            db.CsEnseignants.Remove(cSEnseignant);
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
