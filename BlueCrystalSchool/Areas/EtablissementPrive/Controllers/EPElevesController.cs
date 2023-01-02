using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueCrystalSchool.Areas.EtablissementPrive.Models;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.EtablissementPrive.Controllers
{
    public class EPElevesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EtablissementPrive/EPEleves
        public ActionResult Index()
        {
            var epEleves = db.EpEleves.Include(e => e.EPClasse).Include(e => e.EpTarifTransport).Include(e => e.GroupesSanguin).Include(e => e.ListeEcole);
            return View(epEleves.ToList());
        }

        // GET: EtablissementPrive/EPEleves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPEleve ePEleve = db.EpEleves.Find(id);
            if (ePEleve == null)
            {
                return HttpNotFound();
            }
            return View(ePEleve);
        }

        // GET: EtablissementPrive/EPEleves/Create
        public ActionResult Create()
        {
            ViewBag.EPClasseId = new SelectList(db.EpClasses, "Id", "NomClasse");
            ViewBag.EpTarifTransportId = new SelectList(db.EpTarifTransports, "Id", "Interval");
            ViewBag.GroupesSanguinId = new SelectList(db.GroupesSanguins, "Id", "GroupeSanguin");
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt");
            return View();
        }




        // POST: EtablissementPrive/EPEleves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Matricule,Nom,Prenom,SexeEleve,DateNaissance,CommuneNaissance,Adresse,PrenomPere,ProfessionPere,PereVivant,NomMere,PrenomMere,ProfessionMere,MereVivante,ParentsDivorces,NomTuteur,PrenomTuteur,TelephoneTuteur,EmailTuteur,NombreFreres,NombreSoeurs,NomEnArabe,PrenomEnArabe,MaladiesChroniques,ListMaladies,Medicaments,TransporterAHopital,AcuiteVisuelle,GroupesSanguinId,DispenseSport,EPClasseId,ListeEcoleId,DateInscription,ModeDePaiement,EpTarifTransportId,Reduction,Observation,ImagePath")] EPEleve ePEleve, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
              
                db.EpEleves.Add(ePEleve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EPClasseId = new SelectList(db.EpClasses, "Id", "NomClasse", ePEleve.EPClasseId);
            ViewBag.EpTarifTransportId = new SelectList(db.EpTarifTransports, "Id", "Interval", ePEleve.EpTarifTransportId);
            ViewBag.GroupesSanguinId = new SelectList(db.GroupesSanguins, "Id", "GroupeSanguin", ePEleve.GroupesSanguinId);
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt", ePEleve.ListeEcoleId);
            return View(ePEleve);
        }

        // GET: EtablissementPrive/EPEleves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPEleve ePEleve = db.EpEleves.Find(id);
            if (ePEleve == null)
            {
                return HttpNotFound();
            }
            ViewBag.EPClasseId = new SelectList(db.EpClasses, "Id", "NomClasse", ePEleve.EPClasseId);
            ViewBag.EpTarifTransportId = new SelectList(db.EpTarifTransports, "Id", "Interval", ePEleve.EpTarifTransportId);
            ViewBag.GroupesSanguinId = new SelectList(db.GroupesSanguins, "Id", "GroupeSanguin", ePEleve.GroupesSanguinId);
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt", ePEleve.ListeEcoleId);
            return View(ePEleve);
        }

        // POST: EtablissementPrive/EPEleves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricule,Nom,Prenom,SexeEleve,DateNaissance,CommuneNaissance,Adresse,PrenomPere,ProfessionPere,PereVivant,NomMere,PrenomMere,ProfessionMere,MereVivante,ParentsDivorces,NomTuteur,PrenomTuteur,TelephoneTuteur,EmailTuteur,NombreFreres,NombreSoeurs,NomEnArabe,PrenomEnArabe,MaladiesChroniques,ListMaladies,Medicaments,TransporterAHopital,AcuiteVisuelle,GroupesSanguinId,DispenseSport,EPClasseId,ListeEcoleId,DateInscription,ModeDePaiement,EpTarifTransportId,Reduction,Observation")] EPEleve ePEleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePEleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EPClasseId = new SelectList(db.EpClasses, "Id", "NomClasse", ePEleve.EPClasseId);
            ViewBag.EpTarifTransportId = new SelectList(db.EpTarifTransports, "Id", "Interval", ePEleve.EpTarifTransportId);
            ViewBag.GroupesSanguinId = new SelectList(db.GroupesSanguins, "Id", "GroupeSanguin", ePEleve.GroupesSanguinId);
            ViewBag.ListeEcoleId = new SelectList(db.ListeEcoles, "Id", "NomEtablissemnt", ePEleve.ListeEcoleId);
            return View(ePEleve);
        }

        // GET: EtablissementPrive/EPEleves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPEleve ePEleve = db.EpEleves.Find(id);
            if (ePEleve == null)
            {
                return HttpNotFound();
            }
            return View(ePEleve);
        }

        // POST: EtablissementPrive/EPEleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EPEleve ePEleve = db.EpEleves.Find(id);
            db.EpEleves.Remove(ePEleve);
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
