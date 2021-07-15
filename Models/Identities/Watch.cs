using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADKT_WebProject.Models.Identities
{
    public class Watch
    {
        [Key]
        public string Id { set; get; }

        [Required]
        [StringLength(255)]
        public string name { set; get; }

        [Required]
        public bool gender { set; get; }

        [Required]
        [StringLength(255)]
        public string glass { set; get; }
        public int waterproof { set; get; }  // chi so chong nuoc

        [Required]
        [StringLength(255)]
        public string strap { set; get; }  // loai day : kim loai , day da 

        public Brand Brand { set; get; }
        [Required]
        public int BrandId { set; get; }
    }
}