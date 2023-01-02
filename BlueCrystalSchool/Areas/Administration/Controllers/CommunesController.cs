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
    public class CommunesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/Communes
        public ActionResult Index()
        {
            var communes = db.Communes.Include(c => c.Wilaya);
            return View(communes.ToList());
           
        }

        // GET: Administration/Communes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commune commune = db.Communes.Find(id);
            if (commune == null)
            {
                return HttpNotFound();
            }
            return View(commune);
        }

        // GET: Administration/Communes/Create
        public ActionResult Create()
        {
            ViewBag.WilayaId = new SelectList(db.Wilayas, "Id", "NomWilaya");
            return View();
        }

        // POST: Administration/Communes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomCommune,WilayaId")] Commune commune)
        {
            if (ModelState.IsValid)
            {
                db.Communes.Add(commune);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WilayaId = new SelectList(db.Wilayas, "Id", "NomWilaya", commune.WilayaId);
            return View(commune);
        }

        // GET: Administration/Communes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commune commune = db.Communes.Find(id);
            if (commune == null)
            {
                return HttpNotFound();
            }
            ViewBag.WilayaId = new SelectList(db.Wilayas, "Id", "NomWilaya", commune.WilayaId);
            return View(commune);
        }

        // POST: Administration/Communes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomCommune,WilayaId")] Commune commune)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commune).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WilayaId = new SelectList(db.Wilayas, "Id", "NomWilaya", commune.WilayaId);
            return View(commune);
        }

        // GET: Administration/Communes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commune commune = db.Communes.Find(id);
            if (commune == null)
            {
                return HttpNotFound();
            }
            return View(commune);
        }

        // POST: Administration/Communes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commune commune = db.Communes.Find(id);
            db.Communes.Remove(commune);
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
