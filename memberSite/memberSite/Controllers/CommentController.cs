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
    [Authorize]
    public class CommentController : Controller
    {
        private MemberSiteDB db = new MemberSiteDB();

        // GET: CommentModels
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
            var searchResults = new List<Comment>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                //split search strings
                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.Comments.FirstOrDefault(s => s.Subject.Contains(searchString) || s.CommentText.Contains(searchString) || s.userDetail.FirstName.Contains(searchString) || s.userDetail.LastName.Contains(searchString)));
                }

                searchResults.OrderByDescending(s => s.Date);
            }
            else
            {
                //return alphabetized list if no search term
                searchResults = db.Comments.OrderByDescending(s => s.Date).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(searchResults.ToPagedList(pageNumber, pageSize));
        }

        // GET: CommentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentModel = db.Comments.Find(id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            return View(commentModel);
        }

        // GET: CommentModels/Create
        public ActionResult Create()
        {
            var user_id = User.Identity.GetUserId();

            if (!db.UsersDetails.Any(s => s.RegisteredUserID == user_id))
            {
                var noProfileErrorMessage = "Please create a profile before commenting";
                TempData["ErrorMessage"] = noProfileErrorMessage;
                return RedirectToAction("Create", "UserDetails");
            }
            return View();
        }

        // POST: CommentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Subject,Comment,CommentText")] Comment commentModel)
        {
            commentModel.Date = DateTime.Now.ToString("MM/dd/yyyy");

            commentModel.RegisteredUserID = User.Identity.GetUserId();

            commentModel.userDetail = db.UsersDetails.Where(x => x.RegisteredUserID == commentModel.RegisteredUserID).SingleOrDefault();

            if (ModelState.IsValid)
            {
                db.Comments.Add(commentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commentModel);
        }

        // GET: CommentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentModel = db.Comments.Find(id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            if (commentModel.RegisteredUserID != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                var editErrorMessage = "Why are you trying to mess with other people's stuff?!";
                TempData["ErrorMessage"] = editErrorMessage;
                return RedirectToAction("Index");
            }
            return View(commentModel);
        }

        // POST: CommentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Subject,Comment,CommentText")] Comment commentModel)
        {
            commentModel.Date = DateTime.Now.ToString("MM/dd/yyyy");

            commentModel.RegisteredUserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(commentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentModel);
        }

        // GET: CommentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentModel = db.Comments.Find(id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            if (commentModel.RegisteredUserID != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                var editErrorMessage = "Why are you trying to mess with other people's stuff?!";
                TempData["ErrorMessage"] = editErrorMessage;
                return RedirectToAction("Index");
            }
            return View(commentModel);
        }

        // POST: CommentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment commentModel = db.Comments.Find(id);
            db.Comments.Remove(commentModel);
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