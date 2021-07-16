using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ADKT_WebProject.Models;
using ADKT_WebProject.Models.Identities;

namespace ADKT_WebProject.Areas.Admin.Controllers
{
    [Authorize]
    public class WatchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Watches
        public ActionResult Index()
        {
            var watches = db.Watches.Include(w => w.Brand);
            return View(watches.ToList());
        }

        // GET: Admin/Watches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = db.Watches.Find(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(watch);
        }

        // GET: Admin/Watches/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "name");
            return View();
        }

        // POST: Admin/Watches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,gender,glass,waterproof,strap,BrandId")] Watch watch)
        {
            if (ModelState.IsValid)
            {
                db.Watches.Add(watch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "name", watch.BrandId);
            return View(watch);
        }

        // GET: Admin/Watches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = db.Watches.Find(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "name", watch.BrandId);
            return View(watch);
        }

        // POST: Admin/Watches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,gender,glass,waterproof,strap,BrandId")] Watch watch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "name", watch.BrandId);
            return View(watch);
        }

        // GET: Admin/Watches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = db.Watches.Find(id);
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(watch);
        }

        // POST: Admin/Watches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Watch watch = db.Watches.Find(id);
            db.Watches.Remove(watch);
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
