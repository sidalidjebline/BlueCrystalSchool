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
    public class EPTarifTransportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/EPTarifTransports
        public ActionResult Index()
        {
            return View(db.EpTarifTransports.ToList());
        }

        // GET: Administration/EPTarifTransports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPTarifTransport ePTarifTransport = db.EpTarifTransports.Find(id);
            if (ePTarifTransport == null)
            {
                return HttpNotFound();
            }
            return View(ePTarifTransport);
        }

        // GET: Administration/EPTarifTransports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/EPTarifTransports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Interval,Tarif")] EPTarifTransport ePTarifTransport)
        {
            if (ModelState.IsValid)
            {
                db.EpTarifTransports.Add(ePTarifTransport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ePTarifTransport);
        }

        // GET: Administration/EPTarifTransports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPTarifTransport ePTarifTransport = db.EpTarifTransports.Find(id);
            if (ePTarifTransport == null)
            {
                return HttpNotFound();
            }
            return View(ePTarifTransport);
        }

        // POST: Administration/EPTarifTransports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Interval,Tarif")] EPTarifTransport ePTarifTransport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ePTarifTransport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ePTarifTransport);
        }

        // GET: Administration/EPTarifTransports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EPTarifTransport ePTarifTransport = db.EpTarifTransports.Find(id);
            if (ePTarifTransport == null)
            {
                return HttpNotFound();
            }
            return View(ePTarifTransport);
        }

        // POST: Administration/EPTarifTransports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EPTarifTransport ePTarifTransport = db.EpTarifTransports.Find(id);
            db.EpTarifTransports.Remove(ePTarifTransport);
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
