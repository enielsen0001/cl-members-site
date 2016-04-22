using memberSite.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace memberSite.Controllers
{
    [Authorize]
    public class UserDetailsController : Controller
    {
        private MemberSiteDB db = new MemberSiteDB();

        // GET: UserDetailsModels
        public ActionResult Index(string currentFilter, int? page, string searchTerm = null)
        {
            ViewBag.Message = TempData["ErrorMessage"];

            //pagination
            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            //query db
            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                //split search strings
                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString)));
                }
            }
            else
            {
                //return alphabetized list if no search term
                searchResults = db.UsersDetails.OrderBy(s => s.LastName).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(searchResults.ToPagedList(pageNumber, pageSize));
        }

        // GET: UserDetailsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetailsModel = db.UsersDetails.Find(id);
            if (userDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(userDetailsModel);
        }

        // GET: UserDetailsModels/Create
        public ActionResult Create()
        {
            ViewBag.Message = TempData["ErrorMessage"];
            return View();
        }

        // POST: UserDetailsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, FirstName,LastName,PhoneNumber,Email,WebsiteURL,GitHubURL,LinkedinURL,pathToImg,pathToFile,About,FrontEnd,PHP,DotNet,RubyOnRails,iOS,Android,MeanJS,Mentor")] UserDetails userDetailsModel)
        {
            if ((ModelState.IsValid) && (!db.UsersDetails.Any(s => s.Email == userDetailsModel.Email)))
            {
                string unhashedEmail = userDetailsModel.Email.Trim().ToLower();

                userDetailsModel.EmailHash = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(unhashedEmail)).Select(s => s.ToString("x2")));
                userDetailsModel.RegisteredUserID = User.Identity.GetUserId();

                db.UsersDetails.Add(userDetailsModel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                if (db.UsersDetails.Any(s => s.Email == userDetailsModel.Email))
                {
                    var existingUserErrorMessage = "A profile with that email already exists, please choose another or edit the original profile";
                    TempData["ErrorMessage"] = existingUserErrorMessage;
                }

                if (!ModelState.IsValid)
                {
                    var invalidModelErrorMessage = "Something is incorrect with your entered information, come up with a better message later";
                    TempData["ErrorMessage"] = invalidModelErrorMessage;
                }
                return RedirectToAction("Create");
            }

            //return View(userDetailsModel);
        }

        // GET: UserDetailsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetailsModel = db.UsersDetails.Find(id);
            if (userDetailsModel == null)
            {
                return HttpNotFound();
            }
            if (userDetailsModel.RegisteredUserID != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                var editErrorMessage = "Why are you trying to mess with other people's stuff?!";
                TempData["ErrorMessage"] = editErrorMessage;
                return RedirectToAction("Index");
            }

            return View(userDetailsModel);
        }

        // POST: UserDetailsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber,Email,WebsiteURL,GitHubURL,LinkedinURL,pathToImg,pathToFile,About,FrontEnd,PHP,DotNet,RubyOnRails,iOS,Android,MeanJS,Mentor")] UserDetails userDetailsModel)
        {
            string unhashedEmail = userDetailsModel.Email.Trim().ToLower();

            userDetailsModel.EmailHash = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(unhashedEmail)).Select(s => s.ToString("x2")));
            userDetailsModel.RegisteredUserID = User.Identity.GetUserId();

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
            UserDetails userDetailsModel = db.UsersDetails.Find(id);
            if (userDetailsModel == null)
            {
                return HttpNotFound();
            }
            if (userDetailsModel.RegisteredUserID != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                var deleteErrorMessage = "Why are you trying to mess with other people's stuff?!";
                TempData["ErrorMessage"] = deleteErrorMessage;
                RedirectToAction("Index");
            }
            return View(userDetailsModel);
        }

        // POST: UserDetailsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetails userDetailsModel = db.UsersDetails.Find(id);
            db.UsersDetails.Remove(userDetailsModel);
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