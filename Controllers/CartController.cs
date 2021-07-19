using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADKT_WebProject.Models;
using ADKT_WebProject.Models.Identities;

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
                    return View("ThongBao");
                }
                item.ItemNum++;
                return Redirect(strUrl);
            }
            CartItem newItem = new CartItem(ItemId);
            //if (watch.number < item.ItemNum)
            //{
            //    return View("ThongBao");
            //}
            
            cartItems.Add(newItem);
            return Redirect(strUrl);
        }


        //public ActionResult CreateReceipt()
        //{
        //    List<CartItem> ItemList = GetCart();

        //}
    }


}