using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using about.me.Models;

namespace about.me.Controllers
{
    public class HabilitiesController : Controller
    {
        private ProfileContext db = new ProfileContext();

        // GET: Habilities
        public ActionResult Index()
        {
            var habilities = db.Habilities.Include(h => h.Profile);
            return View(habilities.ToList());
        }

        // GET: Habilities/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
	  Habilities habilities = db.Habilities.Find(id);
            if (habilities == null)
                return HttpNotFound();
            
	  return View(habilities);
        }

        // GET: Habilities/Create
        public ActionResult Create()
        {
            ViewBag.ProfileID = new SelectList(db.Profiles, "ProfileID", "FirstName");
            return View();
        }

        // POST: Habilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HabilitiesID,ProfileID,NameHability,Porcentage")] Habilities habilities)
        {
            if (ModelState.IsValid)
            {
                db.Habilities.Add(habilities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileID = new SelectList(db.Profiles, "ProfileID", "FirstName", habilities.ProfileID);
            return View(habilities);
        }

        // GET: Habilities/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
	  Habilities habilities = db.Habilities.Find(id);
            if (habilities == null)
                return HttpNotFound();
            
	  ViewBag.ProfileID = new SelectList(db.Profiles, "ProfileID", "FirstName", habilities.ProfileID);
            return View(habilities);
        }

        // POST: Habilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HabilitiesID,ProfileID,NameHability,Porcentage")] Habilities habilities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(habilities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
	  ViewBag.ProfileID = new SelectList(db.Profiles, "ProfileID", "FirstName", habilities.ProfileID);
            
	  return View(habilities);
        }

        // GET: Habilities/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
	  Habilities habilities = db.Habilities.Find(id);
            
	  if (habilities == null)
                return HttpNotFound();
            
	  return View(habilities);
        }

        // POST: Habilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Habilities habilities = db.Habilities.Find(id);
            db.Habilities.Remove(habilities);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
