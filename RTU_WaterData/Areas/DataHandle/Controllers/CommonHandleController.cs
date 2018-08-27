using HandleModel.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;
using WacqBLL;

namespace RTU_WaterData.Areas.DataHandle.Controllers
{
    public class CommonHandleController : Controller
    {
        WM_CompanyBll companyBll = new WM_CompanyBll();
        hydStationBll hydStationBll = new hydStationBll();
        // GET: DataHandle/CommonHandle
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询省份下的城市信息
        /// </summary>
        /// <param name="provice">选中的省份</param>
        /// <returns></returns>
        public string GetCityList(string provice)
        {            
            string UserID = Session["UserID"].ToString();
            string CompanyID = Session["CompanyID"].ToString();
            var city_Entity = companyBll.GetCityListByUser(UserID, provice, CompanyID);
            return SerializerDataToClient.GetResponseJsonString(true, city_Entity);
        }

        /// <summary>
        /// 查询城市下的区县
        /// </summary>
        /// <param name="provice">选中的省份</param>
        /// <param name="city">选中的城市</param>
        /// <returns></returns>
        public string GetCountryList(string provice,string city)
        {
            string UserID = Session["UserID"].ToString();
            string CompanyID = Session["CompanyID"].ToString();
            var country_Entity = companyBll.GetCountryListByUser(UserID, provice, city, CompanyID);
            return SerializerDataToClient.GetResponseJsonString(true, country_Entity);
        }

        /// <summary>
        /// 条件查询站点信息
        /// </summary>
        /// <param name="Provice">选中省份</param>
        /// <param name="City">选中城市</param>
        /// <param name="Country">选中区县</param>
        /// <param name="Stationid">填写站号</param>
        /// <param name="Stationname">填写站点名称</param>
        /// <returns></returns>
        public object SearchStationList(string Provice,string City,string Country,int Stationid,string Stationname,int cp,int ps)
        {
            string UserID = Session["UserID"].ToString();
            string CompanyID = Session["CompanyID"].ToString();
            hystationEntity hst = hydStationBll.SearchStationListByConditional(Provice, City, Country, Stationid, Stationname,cp,ps, UserID, CompanyID);
            object JSONObj = JsonConvert.SerializeObject(hst);
            return JSONObj;
            //return SerializerDataToClient.GetResponseJsonString(true, hst);
        }

    }
}