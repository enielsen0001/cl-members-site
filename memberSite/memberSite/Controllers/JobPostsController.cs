using memberSite.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace memberSite.Controllers
{
    public class JobPostsController : Controller
    {
        private MemberSiteDB db = new MemberSiteDB();

        // GET: JobPosts
        [Authorize]
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

            //query db from textbox string
            var searchResults = new List<JobPost>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                //split search strings
                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.JobPosts.FirstOrDefault(s => s.Title.Contains(searchString) || s.Company.Contains(searchString) || s.PostBody.Contains(searchString)));
                }
                searchResults.OrderBy(s => s.Date);
            }
            else
            {
                //return alphabetized list if no search term
                searchResults = db.JobPosts.OrderBy(s => s.Date).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(searchResults.ToPagedList(pageNumber, pageSize));
        }

        // GET: JobPosts/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // GET: JobPosts/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [Authorize]
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,PostBody,Company")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                jobPost.Date = DateTime.Now.ToString("MM/dd/yyyy");
                jobPost.RegisteredUserID = User.Identity.GetUserId();
                db.JobPosts.Add(jobPost);
                db.SaveChanges();
                return RedirectToAction("Details", new
                {
                    id = jobPost.ID
                });
            }

            return View(jobPost);
        }

        // GET: JobPosts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }

            if (jobPost.RegisteredUserID != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                var editErrorMessage = "Why are you trying to mess with other people's stuff?!";
                TempData["ErrorMessage"] = editErrorMessage;
                return RedirectToAction("Index");
            }

            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,PostBody,Company")] JobPost jobPost)
        {
            jobPost.Date = DateTime.Now.ToString("MM/dd/yyyy");
            jobPost.RegisteredUserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }

            if (jobPost.RegisteredUserID != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                var editErrorMessage = "Why are you trying to mess with other people's stuff?!";
                TempData["ErrorMessage"] = editErrorMessage;
                return RedirectToAction("Index");
            }

            return View(jobPost);
        }

        // POST: JobPosts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
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