using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADKT_WebProject.Models.Identities;
namespace ADKT_WebProject.Models
{
    public class LayoutViewModel
    {
        public IEnumerable<Brand> Brands { set; get; }
        public IEnumerable<Watch> Watches { set; get; }
    }
}