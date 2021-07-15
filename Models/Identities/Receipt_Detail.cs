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
        public int WatchId { set; get; }
    }
}