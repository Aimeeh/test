using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WacqBLL;

namespace RTU_WaterData.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 登录首页
        /// </summary>
        /// <returns></returns>
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //用户对象
        WM_UserBll vubll = new WM_UserBll();

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginCheck()
        {
            try
            {
                //用户输入账户
                string UserID = Request["UserID"];
                //用户输入密码
                string PassWord = Request["PassWord"];
                //验证反馈信息
                string outMsg = "";
                //验证用户名和密码
                bool checkResult = vubll.GetUserObjCheck(UserID, PassWord, out outMsg);
                if (checkResult == true)
                {
                    //用户密码正确将账户信息放入session中
                    Session["UserID"] = UserID;
                    Session["CompanyID"] = outMsg;
                    //进入系统首页
                    //return RedirectToAction("Index", "Home", new {CompanyID= outMsg });
                    return Content("<script>location.href='/RainWaterData/Home/Index';</script>");
                }
                else
                {
                    //验证失败显示错误信息
                    ViewBag.Err = outMsg;
                    //return View("Index");
                    return Content("<script>location.href='/RainWaterData';</script>");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
     
        }
    }
}