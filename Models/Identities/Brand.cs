using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADKT_WebProject.Models.Identities
{
    public class Brand
    {
        [Key]
        public int Id { set; get; }

        [Required]
        [StringLength(255)]
        public string name { set; get; }
    }
}