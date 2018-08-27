using HandleModel.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;
using WacqBLL;
using WacqIBLL;

namespace RTU_WaterData.Areas.DataHandle.Controllers
{
    public class RainWaterReportController : Controller
    {
        INSY_RTRUNBLL nsyBll = new NSY_RTRUNBll();
        // GET: DataHandle/RainWaterReport
        public ActionResult Index()
        {
            //登录超时验证
            if (Session["UserID"] == null || Session["UserID"].ToString() == "")
            {
                //超时则返回登录页面
                return Content("<script>alert('登录超时!');location.href='/RainWaterData/';</script>");
            }
            string UserID = Session["UserID"].ToString();
            ViewBag.UserID = UserID;
            return View();
        }

        public ActionResult WaterIndex()
        {
            //登录超时验证
            if (Session["UserID"] == null || Session["UserID"].ToString() == "")
            {
                //超时则返回登录页面
                return Content("<script>alert('登录超时!');location.href='/RainWaterData/';</script>");
            }
            string UserID = Session["UserID"].ToString();
            ViewBag.UserID = UserID;
            return View();
        }

        public ActionResult PeriodResult()
        {
            //登录超时验证
            if (Session["UserID"] == null || Session["UserID"].ToString() == "")
            {
                //超时则返回登录页面
                return Content("<script>alert('登录超时!');location.href='/RainWaterData/';</script>");
            }
            string UserID = Session["UserID"].ToString();
            ViewBag.UserID = UserID;
            return View();
        }

        /// <summary>
        /// 获得雨量数据
        /// </summary>
        /// <param name="StationId"></param>
        /// <param name="Sdate"></param>
        /// <param name="Edate"></param>
        /// <param name="StationName"></param>
        /// <param name="cp"></param>
        /// <param name="ps"></param>
        /// <param name="transType"></param>
        /// <returns></returns>
        public object GetRainData(string StationId, DateTime? Sdate, DateTime? Edate, string StationName, int cp, int ps, string transType)
        {
            NSY_RTRUNEntity nsy = new NSY_RTRUNEntity();
            nsy=nsyBll.GetRainDataByConditional(StationId, Sdate, Edate, StationName, cp, ps, transType);
            object JSONObj = JsonConvert.SerializeObject(nsy);
            return JSONObj;
        }

        /// <summary>
        /// 获得水位数据
        /// </summary>
        /// <param name="StationId"></param>
        /// <param name="Sdate"></param>
        /// <param name="Edate"></param>
        /// <param name="StationName"></param>
        /// <param name="cp"></param>
        /// <param name="ps"></param>
        /// <param name="transType"></param>
        /// <returns></returns>
        public object GetWaterData(string StationId, DateTime? Sdate, DateTime? Edate, string StationName, int cp, int ps, string transType)
        {
            NSY_RTRUNEntity nsy = new NSY_RTRUNEntity();
            nsy=nsyBll.GetWaterDataByConditional(StationId, Sdate, Edate, StationName, cp, ps, transType);
            object JSONObj = JsonConvert.SerializeObject(nsy);
            return JSONObj;
        }

        public string GetPeriodData(int StationID, DateTime? Sdate, DateTime? Edate)
        {
            RWEntities db = new RWEntities();
            var _sdate = Sdate == null ? new DateTime(1999, 1, 1) : Sdate.Value;
            var _edate = Edate == null ? new DateTime(2999, 1, 1) : Edate.Value;
            List<MResults> mrList = new List<MResults>();
            var mr = db.FlowTable.Where(p => p.FTestStartTime >= _sdate && p.FTestStartTime <= Edate && p.StationID == StationID)
                .Select(s => new MResults
                {
                    CPId = s.CPId,
                    FTId = s.FTId,
                    //数据接收时间
                    RevTime = s.RevTime,
                    //观测时间
                    Time = s.FTestStartTime,
                }).OrderByDescending(s => s.Time).ToList();
            for (int i = 0; i < mr.Count; i++)
            {
                int CPId = mr[i].CPId;
                int FTId = mr[i].FTId;
                var obj = db.FlowTable.Where(p => p.FTId == FTId && p.StationID == StationID)
                     .Select(s => new MResults
                     {
                         //数据接收时间
                         RevTime = s.RevTime,
                         //起始水位
                         StartWaterLev = s.StartwaterLev,
                         //结束水位
                         EndWaterLev = s.EndwaterLev,
                         //总流量
                         TotalFlow = s.FlowValue,
                         //过水面积
                         SecArea = s.SecArea,
                         //平均流速
                         MeanVelocity = s.MeanVelocity,
                         //最大流速
                         MaxSpeed = s.MaxVelocity,
                         //水面宽
                         WaterWidth = s.WaterWidth,
                         //平均水深
                         TotalDepth = s.MeanDepth,
                         //最大水深
                         MaxDepth = s.MaxDepth,
                         //水位模式
                         WaterModel = s.WaterModel,
                         //SoundLine = new List<SoundLineInfo>()
                     }).FirstOrDefault();
                obj.SoundLine = new List<SoundLineInfo>();
                SoundLineInfo sli = new SoundLineInfo();
                sli.StartDistL = 0; sli.RiverElva = 0;
                obj.SoundLine.Add(sli);
                List<SoundLineInfo> slilist = db.SoundverData.Where(p => p.StationID == StationID && p.CPId == CPId)
                    .Select(s => new SoundLineInfo
                    {
                        StartDistL = s.StartDistL,
                        RiverElva = s.VerData
                    }).ToList();
                obj.SoundLine.AddRange(slilist);
                obj.VelocityLine = new List<VelocityLineInfo>();
                VelocityLineInfo vli = new VelocityLineInfo(); vli.StartDistV = 0; vli.RiverElva = 0;
                obj.VelocityLine.Add(vli);
                List<VelocityLineInfo> vlilist = db.SpeedData.Where(p => p.StationID == StationID && p.CPId == CPId)
                    .Select(s => new VelocityLineInfo
                    {
                        StartDistV = s.StartDistV,
                        RiverElva = s.RiverElva,
                        HCoeffA = s.HCoeffA,
                        HCoeffB = s.HCoeffB,
                        MCoeffA = s.MCoeffA,
                        MCoeffB = s.MCoeffB,
                        LCoeffA = s.LCoeffA,
                        LCoeffB = s.LCoeffB
                    }).ToList();
                obj.VelocityLine.AddRange(vlilist);
                DateTime Time = Convert.ToDateTime(obj.RevTime);
                obj.RevTime = Time.ToString("yyyy - MM - dd HH: mm:ss");

                //一对多关系 查询出每条测试结果对应垂线数据
                var Partobj = db.FlowParArea.Where(p => p.StationID == StationID && p.FTId == FTId)
                    .Select(d => new PartData
                    {
                        //线平均水深
                        Depth = d.PMeanDepth,
                        //线面流速
                        MSpeed = d.FlowData,
                        //线平均流速
                        MeanSpeed = d.PMeanVelocity,
                        //线部分面积
                        PartArea = d.PartArea,
                        //线平均流量
                        PartFlow = d.PartArea * d.PMeanVelocity,
                    }).ToList();
                obj.PartData = new List<PartData>();
                PartData pd = new PartData();
                pd.Depth = 0; pd.MSpeed = 0; pd.MeanSpeed = 0;
                pd.PartArea = 0; pd.PartFlow = 0;
                obj.PartData.Add(pd);
                obj.PartData.AddRange(Partobj);
                mrList.Add(obj);
            }     
            return SerializerDataToClient.GetResponseJsonString(true, mrList);}
        
    }
}