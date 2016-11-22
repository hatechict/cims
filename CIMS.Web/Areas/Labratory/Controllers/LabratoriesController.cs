using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIMS.Data.Infrastructure;
using CIMS.Model.Models;

namespace CIMS.Web.Areas.Patient.Controllers
{
    public class LabratoriesController : Controller
    {
        private CimsContext db = new CimsContext();

        // GET: Patient/Labratories
        public ActionResult Index()
        {
            return View(db.Labratories.ToList());
        }

        // GET: Patient/Labratories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labratory labratory = db.Labratories.Find(id);
            if (labratory == null)
            {
                return HttpNotFound();
            }
            return View(labratory);
        }

        // GET: Patient/Labratories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Labratories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LabratoryID,Name,Description,NStartingValue,NEndingValue,LabCategoryID")] Labratory labratory)
        {
            if (ModelState.IsValid)
            {
                db.Labratories.Add(labratory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labratory);
        }

        // GET: Patient/Labratories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labratory labratory = db.Labratories.Find(id);
            if (labratory == null)
            {
                return HttpNotFound();
            }
            return View(labratory);
        }

        // POST: Patient/Labratories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LabratoryID,Name,Description,NStartingValue,NEndingValue,LabCategoryID")] Labratory labratory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labratory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labratory);
        }

        // GET: Patient/Labratories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labratory labratory = db.Labratories.Find(id);
            if (labratory == null)
            {
                return HttpNotFound();
            }
            return View(labratory);
        }

        // POST: Patient/Labratories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Labratory labratory = db.Labratories.Find(id);
            db.Labratories.Remove(labratory);
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
