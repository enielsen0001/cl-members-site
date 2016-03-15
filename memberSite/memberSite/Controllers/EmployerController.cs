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
//begin ridiculous filters--------------------------------------------------------------------
        public ActionResult FilterFE(string currentFilter, int? page, string searchTerm = null)
        {

            ViewBag.Message = TempData["ErrorMessage"];

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.FrontEnd == true && (s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString))));
                }
            }
            else
            {
                searchResults = db.UsersDetails.Where(s => s.FrontEnd
                 == true).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", searchResults.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult FilterJS(string currentFilter, int? page, string searchTerm = null)
        {

            ViewBag.Message = TempData["ErrorMessage"];

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.MeanJS == true && (s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString))));
                }
            }
            else
            {
                searchResults = db.UsersDetails.Where(s => s.MeanJS
                 == true).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", searchResults.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult FilterPHP(string currentFilter, int? page, string searchTerm = null)
        {

            ViewBag.Message = TempData["ErrorMessage"];

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.PHP == true && (s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString))));
                }
            }
            else
            {
                searchResults = db.UsersDetails.Where(s => s.PHP
                 == true).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", searchResults.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult FilterRuby(string currentFilter, int? page, string searchTerm = null)
        {

            ViewBag.Message = TempData["ErrorMessage"];

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.RubyOnRails == true && (s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString))));
                }
            }
            else
            {
                searchResults = db.UsersDetails.Where(s => s.RubyOnRails
                 == true).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", searchResults.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult FilterDotNet(string currentFilter, int? page, string searchTerm = null)
        {

            ViewBag.Message = TempData["ErrorMessage"];

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.DotNet == true && (s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString))));
                }
            }
            else
            {
                searchResults = db.UsersDetails.Where(s => s.DotNet
                 == true).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", searchResults.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult FilterIOS(string currentFilter, int? page, string searchTerm = null)
        {

            ViewBag.Message = TempData["ErrorMessage"];

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.iOS == true && (s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString))));
                }
            }
            else
            {
                searchResults = db.UsersDetails.Where(s => s.iOS
                 == true).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", searchResults.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult FilterAndroid(string currentFilter, int? page, string searchTerm = null)
        {

            ViewBag.Message = TempData["ErrorMessage"];

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.Android == true && (s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString))));
                }
            }
            else
            {
                searchResults = db.UsersDetails.Where(s => s.Android
                 == true).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", searchResults.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult FilterMentor(string currentFilter, int? page, string searchTerm = null)
        {

            ViewBag.Message = TempData["ErrorMessage"];

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            ViewBag.CurrentFilter = searchTerm;

            var searchResults = new List<UserDetails>();
            if (!String.IsNullOrEmpty(searchTerm))
            {
                page = 1;

                var searchStrings = searchTerm.Split(' ');
                foreach (var searchString in searchStrings)
                {
                    searchResults.Add(db.UsersDetails.FirstOrDefault(s => s.Mentor == true && (s.About.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString))));
                }
            }
            else
            {
                searchResults = db.UsersDetails.Where(s => s.Mentor
                 == true).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View("Index", searchResults.ToPagedList(pageNumber, pageSize));
        }
    }
}