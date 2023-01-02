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
    public class CSTarificationEnseignantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/CSTarificationEnseignants
        public ActionResult Index()
        {
            return View(db.CsTarificationEnseignants.ToList());
        }

        // GET: Administration/CSTarificationEnseignants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarificationEnseignant cSTarificationEnseignant = db.CsTarificationEnseignants.Find(id);
            if (cSTarificationEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(cSTarificationEnseignant);
        }

        // GET: Administration/CSTarificationEnseignants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/CSTarificationEnseignants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeTarification,Tarif")] CSTarificationEnseignant cSTarificationEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.CsTarificationEnseignants.Add(cSTarificationEnseignant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cSTarificationEnseignant);
        }

        // GET: Administration/CSTarificationEnseignants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarificationEnseignant cSTarificationEnseignant = db.CsTarificationEnseignants.Find(id);
            if (cSTarificationEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(cSTarificationEnseignant);
        }

        // POST: Administration/CSTarificationEnseignants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeTarification,Tarif")] CSTarificationEnseignant cSTarificationEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSTarificationEnseignant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cSTarificationEnseignant);
        }

        // GET: Administration/CSTarificationEnseignants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSTarificationEnseignant cSTarificationEnseignant = db.CsTarificationEnseignants.Find(id);
            if (cSTarificationEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(cSTarificationEnseignant);
        }

        // POST: Administration/CSTarificationEnseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSTarificationEnseignant cSTarificationEnseignant = db.CsTarificationEnseignants.Find(id);
            db.CsTarificationEnseignants.Remove(cSTarificationEnseignant);
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
