using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ADKT_WebProject.Models;
using ADKT_WebProject.Models.Identities;

namespace ADKT_WebProject.Controllers
{
    public class WatchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Watches
        
        public ActionResult Index(string searchString)
        {
            var watches = db.Watches.Include(w => w.Brand);
            var brands = db.Brands;
            LayoutViewModel viewModel = new LayoutViewModel();
            viewModel.Brands = brands.ToList();
            viewModel.Watches = watches.Where(x=>x.name.Contains(searchString) ||searchString ==null).ToList();
            return View(viewModel);
        }

        //public async Task<ActionResult> Searching(string searchString)
        //{

        //    return RedirectToAction("Index");
        //}

        // GET: Watches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watch watch = db.Watches.Find(id);
            watch.Brand = db.Brands.Find(watch.BrandId);
            if (watch == null)
            {
                return HttpNotFound();
            }
            return View(watch);
        }

        // GET: Watches/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "name");
            return View();
        }

        // POST: Watches/Create
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

        // GET: Watches/Edit/5
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

        // POST: Watches/Edit/5
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

        // GET: Watches/Delete/5
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

        // POST: Watches/Delete/5
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

        public ActionResult GenderList(string gender)
        {

            LayoutViewModel viewModel = new LayoutViewModel();
            viewModel.Brands = db.Brands.ToList();
            viewModel.Watches = db.Watches.Where(w => w.gender == gender).ToList();
            ViewBag.gender = gender;
            return View(viewModel);
        }
    }
}
