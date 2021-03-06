using System.Web.Mvc;

namespace ADKT_WebProject.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index",Controller="Receipts", id = UrlParameter.Optional },
                new[] { "ADKT_WebProject.Areas.Admin.Controllers" }
            );
        }
    }
}