using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADKT_WebProject.Models.Identities
{
    public class Receipt_Detail
    {
        [Key]
        public int Id { set; get; }

        public Watch Watch { set; get; }
        public string WatchId { set; get; }

        public int numOfItem { set; get; }

        public Receipt Receipt { set; get; }
        public int ReceiptId { set; get; }
    }
}