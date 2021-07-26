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
    public class ReceiptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Receipts
        public ActionResult Index()
        {
            var receipts = db.Receipts.Include(r =>r.Customer);
            return View(receipts.ToList());
        }

        // GET: Admin/Receipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Include(r => r.Customer).SingleOrDefault(r => r.Id == id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            var receiptDetails = db.receipt_Details.Include(rd => rd.Watch).Where(rd => rd.ReceiptId == receipt.Id);
            ViewBag.receiptdetails = receiptDetails.ToList();
            return View(receipt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                var tempReceipt = db.Receipts.Find(receipt.Id);
                tempReceipt.status = receipt.status;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Receipt_DetailId = new SelectList(db.receipt_Details, "Id", "Id", receipt.Receipt_DetailId);
            return View(receipt);
        }
        // GET: Admin/Receipts/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Receipt_DetailId = new SelectList(db.receipt_Details, "Id", "Id");
        //    return View();
        //}

        // POST: Admin/Receipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Receipt receipt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(receipt).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    //ViewBag.Receipt_DetailId = new SelectList(db.receipt_Details, "Id", "Id", receipt.Receipt_DetailId);
        //    return View(receipt);
        //}

        // GET: Admin/Receipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Receipt_DetailId = new SelectList(db.receipt_Details, "Id", "Id", receipt.Receipt_DetailId);
            return View(receipt);
        }

        // POST: Admin/Receipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Receipt_DetailId = new SelectList(db.receipt_Details, "Id", "Id", receipt.Receipt_DetailId);
            return View(receipt);
        }

        // GET: Admin/Receipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Include(r => r.Customer).SingleOrDefault(r => r.Id == id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            var receiptDetails = db.receipt_Details.Include(rd => rd.Watch).Where(rd => rd.ReceiptId == receipt.Id);
            ViewBag.receiptdetails = receiptDetails.ToList();
            return View(receipt);
        }

        // POST: Admin/Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Receipt receipt = db.Receipts.Find(id);
            db.Receipts.Remove(receipt);
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
