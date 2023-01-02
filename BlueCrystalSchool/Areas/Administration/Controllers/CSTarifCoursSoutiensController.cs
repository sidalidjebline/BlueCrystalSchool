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
    public class CSTarifCoursSoutiensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/CSTarifCoursSoutiens
        public ActionResult Index()
        {
            var csTarifCoursSoutiens = db.CsTarifCoursSoutiens.Include(c => c.CSNiveauScolaire).Include(c => c.CSNombreMatiere);
            return View(csTarifCoursSoutiens.ToList());
        }

        // GET: Administration/CSTarifCoursSoutiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarifCoursSoutien cSTarifCoursSoutien = db.CsTarifCoursSoutiens.Find(id);
            if (cSTarifCoursSoutien == null)
            {
                return HttpNotFound();
            }
            return View(cSTarifCoursSoutien);
        }

        // GET: Administration/CSTarifCoursSoutiens/Create
        public ActionResult Create()
        {
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau");
            ViewBag.CSNombreMatiereID = new SelectList(db.CSNombreMatieres, "Id", "Id");
            return View();
        }

        // POST: Administration/CSTarifCoursSoutiens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CSNiveauScolaireId,CSNombreMatiereID,Tarif")] CSTarifCoursSoutien cSTarifCoursSoutien)
        {
            if (ModelState.IsValid)
            {
                db.CsTarifCoursSoutiens.Add(cSTarifCoursSoutien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSTarifCoursSoutien.CSNiveauScolaireId);
            ViewBag.CSNombreMatiereID = new SelectList(db.CSNombreMatieres, "Id", "Id", cSTarifCoursSoutien.CSNombreMatiereID);
            return View(cSTarifCoursSoutien);
        }

        // GET: Administration/CSTarifCoursSoutiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarifCoursSoutien cSTarifCoursSoutien = db.CsTarifCoursSoutiens.Find(id);
            if (cSTarifCoursSoutien == null)
            {
                return HttpNotFound();
            }
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSTarifCoursSoutien.CSNiveauScolaireId);
            ViewBag.CSNombreMatiereID = new SelectList(db.CSNombreMatieres, "Id", "Id", cSTarifCoursSoutien.CSNombreMatiereID);
            return View(cSTarifCoursSoutien);
        }

        // POST: Administration/CSTarifCoursSoutiens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CSNiveauScolaireId,CSNombreMatiereID,Tarif")] CSTarifCoursSoutien cSTarifCoursSoutien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSTarifCoursSoutien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CSNiveauScolaireId = new SelectList(db.CsNiveauScolaires, "Id", "Niveau", cSTarifCoursSoutien.CSNiveauScolaireId);
            ViewBag.CSNombreMatiereID = new SelectList(db.CSNombreMatieres, "Id", "Id", cSTarifCoursSoutien.CSNombreMatiereID);
            return View(cSTarifCoursSoutien);
        }

        // GET: Administration/CSTarifCoursSoutiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarifCoursSoutien cSTarifCoursSoutien = db.CsTarifCoursSoutiens.Find(id);
            if (cSTarifCoursSoutien == null)
            {
                return HttpNotFound();
            }
            return View(cSTarifCoursSoutien);
        }

        // POST: Administration/CSTarifCoursSoutiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSTarifCoursSoutien cSTarifCoursSoutien = db.CsTarifCoursSoutiens.Find(id);
            db.CsTarifCoursSoutiens.Remove(cSTarifCoursSoutien);
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
