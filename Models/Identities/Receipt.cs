using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADKT_WebProject.Models.Identities
{
    public class Receipt
    {
        [Key]
        public int Id { set; get; }

        public ApplicationUser Customer { set; get; }
        public string CustomerId { set; get; }

        public DateTime date { set; get; }

        public int status { set; get; }

    }
}