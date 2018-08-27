using System.Web.Mvc;

namespace RTU_WaterData.Areas.DataHandle
{
    public class DataHandleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DataHandle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DataHandle_default",
                "DataHandle/{controller}/{action}/{id}",
                 new { action = "Index", id = UrlParameter.Optional }
            // new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
            //new string[] { "Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}