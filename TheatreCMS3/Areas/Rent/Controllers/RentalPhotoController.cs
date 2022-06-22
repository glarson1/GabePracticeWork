using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Rent.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Controllers
{
    public class RentalPhotoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/RentalPhoto
        public ActionResult Index()
        {
            return View(db.RentalPhotoes.ToList());
        }

        // GET: Rent/RentalPhoto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalPhoto rentalPhoto = db.RentalPhotoes.Find(id);
            if (rentalPhoto == null)
            {
                return HttpNotFound();
            }
            return View(rentalPhoto);
        }

        // GET: Rent/RentalPhoto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/RentalPhoto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalPhotoId,RentalsName,Damaged,RentalPhotos,Details")] RentalPhoto rentalPhoto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                //Converting uploaded file to array before db updates
                var newPhoto = photoConv(photo);
                rentalPhoto.RentalPhotos = newPhoto;

                db.RentalPhotoes.Add(rentalPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalPhoto);
        }


        public byte[] photoConv(HttpPostedFileBase photo)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(photo.InputStream))
            {
                bytes = br.ReadBytes(photo.ContentLength);
            }

            return bytes;
        }



        // GET: Rent/RentalPhoto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalPhoto rentalPhoto = db.RentalPhotoes.Find(id);
            if (rentalPhoto == null)
            {
                return HttpNotFound();
            }
            return View(rentalPhoto);
        }

        // POST: Rent/RentalPhoto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalPhotoId,RentalsName,Damaged,RentalPhotos,Details")] RentalPhoto rentalPhoto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {

                //Converting uploaded file to array before db updates
                var newPhoto = photoConv(photo);
                rentalPhoto.RentalPhotos = newPhoto;

                db.Entry(rentalPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalPhoto);
        }

        // GET: Rent/RentalPhoto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalPhoto rentalPhoto = db.RentalPhotoes.Find(id);
            if (rentalPhoto == null)
            {
                return HttpNotFound();
            }
            return View(rentalPhoto);
        }

        // POST: Rent/RentalPhoto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalPhoto rentalPhoto = db.RentalPhotoes.Find(id);
            db.RentalPhotoes.Remove(rentalPhoto);
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
