using ADKT_WebProject.Models.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADKT_WebProject.Models
{
    public class CartItem
    {
        public string ItemId { set; get; }
        public string ItemName { set; get; }
        public double ItemPrice { set; get; }
        public int ItemNum { set; get; }
        public string ItemImg { set; get; }

        public double Payment { set; get; }
        public CartItem()
        {

        }
        public CartItem(string ItemId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                this.ItemId = ItemId;
                Watch Item = db.Watches.Single(w => w.Id == ItemId);
                ItemName = Item.name;
                ItemPrice = Item.price;
                ItemImg = Item.Img_Path;
                Payment = ItemPrice * ItemNum;
            }
        }

        public CartItem(string ItemId,int num)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                this.ItemId = ItemId;
                Watch Item = db.Watches.Single(w => w.Id == ItemId);
                ItemName = Item.name;
                ItemPrice = Item.price;
                ItemImg = Item.Img_Path;
                ItemNum = num;
                Payment = ItemPrice * ItemNum;
            }
        }

        public double GetPayMent()
        {
            return ItemNum * ItemPrice;
        }
    }
}