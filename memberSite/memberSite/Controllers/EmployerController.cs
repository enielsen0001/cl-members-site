using memberSite.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace memberSite.Controllers
{
    public class EmployerController : Controller
    {
        private MemberSiteDB db = new MemberSiteDB();

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
    }
}