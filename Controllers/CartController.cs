using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADKT_WebProject.Models;
using ADKT_WebProject.Models.Identities;
using Microsoft.AspNet.Identity;

namespace ADKT_WebProject.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart

        public ActionResult CheckOut()
        {
            List<CartItem> cartItems = GetCart();
            return View(cartItems);
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cartItems = Session["CartItem"] as List<CartItem>;
            if( cartItems == null)
            {
                cartItems = new List<CartItem>();
                Session["CartItem"] = cartItems;
            }
            return cartItems;
        }

        public ActionResult AddItem(string ItemId,string strUrl)
        {
            Watch watch = db.Watches.SingleOrDefault(w => w.Id == ItemId);
            if(watch == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<CartItem> cartItems = GetCart();
            CartItem item = cartItems.SingleOrDefault(w => w.ItemId == watch.Id);
            if(item != null)
            {
                if(watch.number < item.ItemNum)
                {
                    return View("OutOfStock");
                }
                item.ItemNum++;
                return Redirect(strUrl);
            }
            CartItem newItem = new CartItem(ItemId,1);
            if (watch.number < newItem.ItemNum)
            {
                return View("OutOfStock");
            }

            cartItems.Add(newItem);
            return Redirect(strUrl);
        }


        public ActionResult PlaceOrder()
        {
            List<CartItem> ItemList = GetCart();
            if (ItemList == null)
            {
                return RedirectToAction("Index", "Watches");
            }

            // add new receipt
            Receipt newReceipt = new Receipt();
            newReceipt.CustomerId = User.Identity.GetUserId();
            newReceipt.date = DateTime.Now;
            db.Receipts.Add(newReceipt);
            db.SaveChanges();

            // add new receipt_details
            foreach (var item in ItemList)
            {
                Receipt_Detail receipt_Detail = new Receipt_Detail();
                receipt_Detail.ReceiptId = newReceipt.Id;
                receipt_Detail.WatchId = item.ItemId;
                receipt_Detail.numOfItem = item.ItemNum;
                db.receipt_Details.Add(receipt_Detail);
                
            }
            db.SaveChanges();
            Session["CartItem"] = null;
            return RedirectToAction("Index", "Watches");
        }
    }


}