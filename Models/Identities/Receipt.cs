using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADKT_WebProject.Models.Identities
{
    public class Receipt
    {
        [Key]
        public string Id { set; get; }

        [Required]
        [StringLength(100)]
        public string CustomerName { set; get; }

        [Required]
        [StringLength(255)]
        public string CustomerAddress { set; get; }

        [Required]
        [StringLength(12)]
        public string CustomerPhone { set; get; }

        public Receipt_Detail Receipt_Detail { set; get; }
        public int Receipt_DetailId { set; get; }
    }
}