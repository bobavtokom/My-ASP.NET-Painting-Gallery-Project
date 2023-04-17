using BoArtPaint.Models;
using BoArtPaint.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoArtPaint.Controllers {
    public class HomeController : Controller {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index() {
            var artists = _db.Artists.ToList();
            var viewmodel = new ArtistViewModel {
                Artists = artists 
            };
            return View(viewmodel);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}