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
    public class EPMatieresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/EPMatieres
        public ActionResult Index()
        {
            return View(db.EpMatieres.ToList());
        }

        // GET: Administration/EPMatieres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPMatiere ePMatiere = db.EpMatieres.Find(id);
            if (ePMatiere == null)
            {
                return HttpNotFound();
            }
            return View(ePMatiere);
        }

        // GET: Administration/EPMatieres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/EPMatieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomMatiere")] EPMatiere ePMatiere)
        {
            if (ModelState.IsValid)
            {
                db.EpMatieres.Add(ePMatiere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ePMatiere);
        }

        // GET: Administration/EPMatieres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPMatiere ePMatiere = db.EpMatieres.Find(id);
            if (ePMatiere == null)
            {
                return HttpNotFound();
            }
            return View(ePMatiere);
        }

        // POST: Administration/EPMatieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomMatiere")] EPMatiere ePMatiere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePMatiere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ePMatiere);
        }

        // GET: Administration/EPMatieres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPMatiere ePMatiere = db.EpMatieres.Find(id);
            if (ePMatiere == null)
            {
                return HttpNotFound();
            }
            return View(ePMatiere);
        }

        // POST: Administration/EPMatieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EPMatiere ePMatiere = db.EpMatieres.Find(id);
            db.EpMatieres.Remove(ePMatiere);
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
