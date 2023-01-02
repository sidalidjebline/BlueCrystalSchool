using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlueCrystalSchool.Models;

namespace BlueCrystalSchool.Areas.Administration.Controllers
{
    public class AnneeScolairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/AnneeScolaires
        public ActionResult Index()
        {
            return View(db.AnneeScolaires.ToList());
        }

        // GET: Administration/AnneeScolaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnneeScolaire anneeScolaire = db.AnneeScolaires.Find(id);
            if (anneeScolaire == null)
            {
                return HttpNotFound();
            }
            return View(anneeScolaire);
        }

        // GET: Administration/AnneeScolaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/AnneeScolaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Intitule,DateDebut,DateFin")] AnneeScolaire anneeScolaire)
        {
            if (ModelState.IsValid)
            {
                db.AnneeScolaires.Add(anneeScolaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anneeScolaire);
        }

        // GET: Administration/AnneeScolaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnneeScolaire anneeScolaire = db.AnneeScolaires.Find(id);
            if (anneeScolaire == null)
            {
                return HttpNotFound();
            }
            return View(anneeScolaire);
        }

        // POST: Administration/AnneeScolaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Intitule,DateDebut,DateFin")] AnneeScolaire anneeScolaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anneeScolaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anneeScolaire);
        }

        // GET: Administration/AnneeScolaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnneeScolaire anneeScolaire = db.AnneeScolaires.Find(id);
            if (anneeScolaire == null)
            {
                return HttpNotFound();
            }
            return View(anneeScolaire);
        }

        // POST: Administration/AnneeScolaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnneeScolaire anneeScolaire = db.AnneeScolaires.Find(id);
            db.AnneeScolaires.Remove(anneeScolaire);
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
