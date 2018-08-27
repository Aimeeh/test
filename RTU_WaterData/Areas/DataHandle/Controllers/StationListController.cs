using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;
using WacqBLL;

namespace RTU_WaterData.Areas.DataHandle.Controllers
{
    public class StationListController : Controller
    {
        WM_CompanyBll cbll = new WM_CompanyBll();
        // GET: DataHandle/StationList
        public ActionResult Index()
        {
            //登录超时验证
            if (Session["UserID"] == null || Session["UserID"].ToString() == "")
            {
                //超时则返回登录页面
                return Content("<script>alert('登录超时!');location.href='/RainWaterData/';</script>");
            }
            string UserID = Session["UserID"].ToString();
            string CompanyID = Session["CompanyID"].ToString();
            //查询登录账户管辖区域下的所有站点信息
            StructuralEntity structuralEntity = cbll.GetSationList(CompanyID, UserID);
            ViewBag.UserID = UserID;
            ViewBag.proviceList = structuralEntity.provinceEntity;
            return View();
        }
    }
}