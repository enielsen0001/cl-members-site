using memberSite.Models;
using Microsoft.AspNet.Identity;
using System;
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
        public ActionResult Index()
        {
            ViewBag.Message = TempData["ErrorMessage"];
            return View(db.Comments.ToList());
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
            var user_id = User.Identity.GetUserId();
            //assign datetime
            commentModel.Date = DateTime.Now.ToString("MM/dd/yyyy");
            //assign userid
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
            if (commentModel.RegisteredUserID != User.Identity.GetUserId())
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
            if (commentModel.RegisteredUserID != User.Identity.GetUserId())
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