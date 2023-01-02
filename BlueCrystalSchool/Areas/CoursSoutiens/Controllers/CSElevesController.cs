using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueCrystalSchool.Areas.CoursSoutiens.Models;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.CoursSoutiens.Controllers
{
    public class CSElevesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CoursSoutiens/CSEleves
        public ActionResult Index()
        {
            var csEleves = db.CsEleves.Include(c => c.CSNiveauScolaire).Include(c => c.Gender).Include(c => c.ListeEcole);
            return View(csEleves.ToList());
        }

        // GET: CoursSoutiens/CSEleves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSEleve cSEleve = db.CsEleves.Find(id);
            if (cSEleve == null)
            {
                return HttpNotFound();
            }
            return View(cSEleve);
        }

        // GET: CoursSoutiens/CSEleves/Create
        public ActionResult Create()
        {


            var model = new CSEleve();
            ViewBag.Matieres = new MultiSelectList(db.CsMatieres.ToList(), "Id", "NomMatiere", model.CSMatieres);//db.CsMatieres.ToList();


            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "StudentGender");
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt");
            return View();
        }

        // POST: CoursSoutiens/CSEleves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,GenderId,DateNaissance,CommuneNaissance,Reduction,Observation,CSNiveauScolaireId,ListeEcoleId,Solde")] CSEleve cSEleve, int[] matieresids)
        {
            if (ModelState.IsValid)
            {
                //string fileName = Path.Combine(Server.MapPath("~/ImagesCS/"), image1.FileName);
                //image1.SaveAs(fileName);
                //cSEleve.ImagePath = fileName;
                cSEleve.NombreMatieres = matieresids.Length;


                List<CSMatiere> mats = new List<CSMatiere>();
                foreach (var item in matieresids)
                {

                    CSMatiere tt = db.CsMatieres.Find(item);
                    mats.Add(tt);


                }

                cSEleve.CSMatieres = mats;

                db.CsEleves.Add(cSEleve);
                db.SaveChanges();
                //return RedirectToAction("AffectGroupe",new {id = cSEleve.Id});
                return RedirectToAction("Index");
            }

            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSEleve.CSNiveauScolaireId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "StudentGender", cSEleve.GenderId);
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt", cSEleve.ListeEcoleId);
            return View(cSEleve);
        }

        // GET: CoursSoutiens/CSEleves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSEleve cSEleve = db.CsEleves.Find(id);
            if (cSEleve == null)
            {
                return HttpNotFound();
            }
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSEleve.CSNiveauScolaireId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "StudentGender", cSEleve.GenderId);
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt", cSEleve.ListeEcoleId);
            return View(cSEleve);
        }

        // POST: CoursSoutiens/CSEleves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricule,Nom,Prenom,GenderId,DateNaissance,CommuneNaissance,Reduction,Observation,CSNiveauScolaireId,ListeEcoleId,Solde")] CSEleve cSEleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSEleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSEleve.CSNiveauScolaireId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "StudentGender", cSEleve.GenderId);
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt", cSEleve.ListeEcoleId);
            return View(cSEleve);
        }

        // GET: CoursSoutiens/CSEleves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSEleve cSEleve = db.CsEleves.Find(id);
            if (cSEleve == null)
            {
                return HttpNotFound();
            }
            return View(cSEleve);
        }

        // POST: CoursSoutiens/CSEleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSEleve cSEleve = db.CsEleves.Find(id);
            db.CsEleves.Remove(cSEleve);
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




        public ActionResult PaiementCoursSoutien(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSEleve cSEleve = db.CsEleves.Find(id);
            if (cSEleve == null)
            {
                return HttpNotFound();
            }
            return View(cSEleve);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaiementCoursSoutien([Bind(Include = "Id,Nom,Prenom,GenderId,DateNaissance,CommuneNaissance,Reduction,Observation,CSNiveauScolaireId,ListeEcoleId,Solde,ImagePath")] CSEleve cSEleve, int montant)
        {
            if (ModelState.IsValid)
            {
                cSEleve.Solde += montant;
                db.Entry(cSEleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSEleve.CSNiveauScolaireId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "StudentGender", cSEleve.GenderId);
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt", cSEleve.ListeEcoleId);
            return View(cSEleve);
        }




        public ActionResult AffectGroupe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CSEleve cSEleve = db.CsEleves.Include(m => m.CSMatieres).FirstOrDefault(d => d.Id == id);//db.CsEleves.Find(id);
            ViewBag.Groupes = db.CSGroupes.ToList();
            if (cSEleve == null)
            {
                return HttpNotFound();
            }
            return View(cSEleve);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AffectGroupe([Bind(Include = "Id,Matricule,Nom,Prenom,GenderId,DateNaissance,CommuneNaissance,Reduction,Observation,CSNiveauScolaireId,ListeEcoleId,Solde,ImagePath")] CSEleve cSEleve, int montant)
        {
            if (ModelState.IsValid)
            {
                cSEleve.Solde += montant;
                db.Entry(cSEleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSEleve.CSNiveauScolaireId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "StudentGender", cSEleve.GenderId);
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt", cSEleve.ListeEcoleId);
            return View(cSEleve);
        }


        public ActionResult PointageCoursSoutien(int? id)
        {
            CSEleve tt = db.CsEleves.Find(id);
            CSTarifCoursSoutien TarifMois = db.CsTarifCoursSoutiens
                    .Where(t => t.CSNombreMatiereID == tt.NombreMatieres)
            .First(p => p.CSNiveauScolaireId == tt.CSNiveauScolaireId);

            int fatifMois = TarifMois.Tarif;
            tt.Solde = tt.Solde - (fatifMois / (4 * tt.NombreMatieres));
            db.Entry(tt).State = EntityState.Modified;
            db.SaveChanges();
            int dd = TarifMois.Tarif;
           return RedirectToAction("Index");
        }





    }
}
