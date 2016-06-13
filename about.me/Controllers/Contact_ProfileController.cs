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
    public class Contact_ProfileController : Controller
    {
        private ProfileContext db = new ProfileContext();

        // GET: Contact_Profile
        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.Profile);
            return View(contacts.ToList());
        }

        // GET: Contact_Profile/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Contact_Profile contact_Profile = db.Contacts.Find(id);
            if (contact_Profile == null)            
                return HttpNotFound();
            
            return View(contact_Profile);
        }

        // GET: Contact_Profile/Create
        public ActionResult Create()
        {
            ViewBag.ProfileID = new SelectList(db.Profiles, "ProfileID", "FirstName");
            return View();
        }

        // POST: Contact_Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Contact_ProfileID,ProfileID,Direction,Phone,Email,Website,Facebook,Twitter,Linkedin")] Contact_Profile contact_Profile)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact_Profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileID = new SelectList(db.Profiles, "ProfileID", "FirstName", contact_Profile.ProfileID);
            return View(contact_Profile);
        }

        // GET: Contact_Profile/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
	  Contact_Profile contact_Profile = db.Contacts.Find(id);
            
	  if (contact_Profile == null)
                return HttpNotFound();
            
	  ViewBag.ProfileID = new SelectList(db.Profiles, "ProfileID", "FirstName", contact_Profile.ProfileID);
            return View(contact_Profile);
        }

        // POST: Contact_Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Contact_ProfileID,ProfileID,Direction,Phone,Email,Website,Facebook,Twitter,Linkedin")] Contact_Profile contact_Profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact_Profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfileID = new SelectList(db.Profiles, "ProfileID", "FirstName", contact_Profile.ProfileID);
            return View(contact_Profile);
        }

        // GET: Contact_Profile/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
	  Contact_Profile contact_Profile = db.Contacts.Find(id);
            if (contact_Profile == null)
                return HttpNotFound();
            
	  return View(contact_Profile);
        }

        // POST: Contact_Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Contact_Profile contact_Profile = db.Contacts.Find(id);
            db.Contacts.Remove(contact_Profile);
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
