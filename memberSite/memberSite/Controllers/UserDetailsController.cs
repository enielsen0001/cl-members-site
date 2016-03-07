using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using memberSite.Models;

namespace memberSite.Controllers
{
    public class UserDetailsController : Controller
    {
        private MemberSiteDB db = new MemberSiteDB();

        // GET: UserDetailsModels
        public ActionResult Index()
        {
            return View(db.UserDetails.ToList());
        }

        // GET: UserDetailsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailsModel userDetailsModel = db.UserDetails.Find(id);
            if (userDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(userDetailsModel);
        }

        // GET: UserDetailsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetailsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,Email,WebsiteURL,GitHubURL,LinkedinURL,pathToImg,pathToFile,About,FrontEnd,PHP,DotNet,RubyOnRails,iOS,Android")] UserDetailsModel userDetailsModel)
        {
            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetailsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDetailsModel);
        }

        // GET: UserDetailsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailsModel userDetailsModel = db.UserDetails.Find(id);
            if (userDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(userDetailsModel);
        }

        // POST: UserDetailsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber,Email,WebsiteURL,GitHubURL,LinkedinURL,pathToImg,pathToFile,About,FrontEnd,PHP,DotNet,RubyOnRails,iOS,Android")] UserDetailsModel userDetailsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetailsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetailsModel);
        }

        // GET: UserDetailsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetailsModel userDetailsModel = db.UserDetails.Find(id);
            if (userDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(userDetailsModel);
        }

        // POST: UserDetailsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetailsModel userDetailsModel = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetailsModel);
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
