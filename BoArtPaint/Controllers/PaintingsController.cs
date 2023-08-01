using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoArtPaint.Models;

namespace BoArtPaint.Controllers {
    public class PaintingsController : Controller {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Paintings
        public ActionResult Index() {
            var paintings = _db.Paintings.Include(m => m.Artist);

            if (User.IsInRole(RoleName.CanManagePaintings)) {
                return View();
            }
            return View("Index - ForNonAuthorizedUsers", paintings.ToList());
        }

        // GET: Paintings/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var painting = _db.Paintings.Include(m => m.Artist).FirstOrDefault(m => m.Id == id);
            if (painting == null) {
                return HttpNotFound();
            }
            if (User.IsInRole(RoleName.CanManagePaintings)) {

                return View("Details", painting);
            }
            return View("Details - ForNonAuthorizedUsers", painting);
        }

        // GET: Paintings/Create
        [Authorize(Roles = RoleName.CanManagePaintings)]
        public ActionResult Create() {
            return View();
        }

        // POST: Paintings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,PaintUrl,Price,Artist")] Painting painting) {
            if (ModelState.IsValid) {
                _db.Paintings.Add(painting);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(painting);
        }

        // GET: Paintings/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Painting painting = _db.Paintings.Include(m => m.Artist).FirstOrDefault(m => m.Id == id);
            if (painting == null) {
                return HttpNotFound();
            }
            return View(painting);
        }

        // POST: Paintings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,PaintUrl,Price,ArtistId")] Painting painting) {
            if (ModelState.IsValid) {
                // Find the associated Artist entity based on the provided ArtistId
                Artist artist = _db.Artists.FirstOrDefault(a => a.Id == painting.ArtistId);

                // Check if the associated Artist was found
                if (artist != null) {
                    // Set the Artist property of the Painting to the associated Artist
                    painting.Artist = artist;

                    // Mark the Painting entity as modified and save changes
                    _db.Entry(painting).State = EntityState.Modified;
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                } else {
                    // Handle the case where the associated Artist is not found
                    // You may want to add appropriate error handling here
                }
            }
            return View(painting);
        }




        // GET: Paintings/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Painting painting = _db.Paintings.Find(id);
            if (painting == null) {
                return HttpNotFound();
            }
            return View(painting);
        }

        // POST: Paintings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Painting painting = _db.Paintings.Find(id);
            _db.Paintings.Remove(painting);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
