
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WacqBLL
{
    using HandleModel.Model;
    using Utilities;
    using WacqAbsFactory;
    using WacqIBLL;

    public  class hydStationBll:BaseBLL<hydStation>,IhydStationBLL
    {
        /// <summary>
        /// 站点列表条件查询
        /// </summary>
        /// <param name="Provice">选中省份</param>
        /// <param name="City">选中城市</param>
        /// <param name="Country">选中区县</param>
        /// <param name="Stationid">站点编码</param>
        /// <param name="Stationname">站点名称</param>
        /// <returns></returns>
        public hystationEntity SearchStationListByConditional(string Provice, string City, string Country, int Stationid, string Stationname, int cp,int ps,string UserID,string CompanyID)
        {
            List<hydStation> hs = new List<hydStation>();
            AbsFacory absfact = AbsFacory.CreatInstance();
            IhydStationBLL hsbll = absfact.CreathydStationBllInstance();

            if ((Provice== "==请选择=="|| Provice=="") &&(City== "==请选择=="|| City=="") &&(Country== "==请选择=="|| Country=="") && Stationid==0&& (Stationname==null|| Stationname==""))
            {
                if (UserID == ConfigHelper.AppSettings("CurrentUserName"))
                {
                    hs = hsbll.Query(p => true).ToList();
                }
                else
                {
                    IWM_CompanyBLL cbll = absfact.CreatIWM_CompanyBLLInstance();
                    var pe = cbll.Query(p => p.CompanyId == CompanyID)
                        .Select(x => new ProvinceEntity
                        {
                            Province = x.Province,
                            City = x.City,
                            County = x.County
                        }).FirstOrDefault();
                    if ((pe.City == "" || pe.City == null || pe.City == "&nbsp;") && (pe.County == "" || pe.City == null || pe.County == "&nbsp;"))
                    {
                        hs = hsbll.Query(p => p.Province == pe.Province).ToList();
                    }
                    else if ((pe.City != "" || pe.City != null || pe.City != "&nbsp;") && (pe.County == "" || pe.City == null || pe.County == "&nbsp;"))
                    {
                        hs = hsbll.Query(p => p.Province == pe.Province && p.City == pe.City).ToList();
                    }
                    else if ((pe.City != "" || pe.City != null || pe.City != "&nbsp;") && (pe.County != "" || pe.City != null || pe.County != "&nbsp;"))
                    {
                        hs = hsbll.Query(p => p.Province == pe.Province && p.City == pe.City && p.County == pe.County).ToList();
                    }
                }
                   
            }
            else if ((Provice == "==请选择==" || Provice == "") && (City == "==请选择=="|| City == "") && (Country == "==请选择==" || Country == "") && Stationid != 0)
            {
                hs = hsbll.Query(p => p.StationID == Stationid).ToList();
            }
            else if ((Provice == "==请选择==" || Provice == "") && (City == "==请选择==" || City == "") && (Country == "==请选择==" || Country == "") && (Stationname !=""&& Stationname!=null))
            {
                hs = hsbll.Query(p => p.StationName== Stationname).ToList();
            }
            else if ((Provice == "==请选择==" || Provice == "") && (City == "==请选择==" || City == "") && (Country == "==请选择==" || Country == "") && Stationid != 0 && (Stationname != "" && Stationname != null))
            {
                hs = hsbll.Query(p =>p.StationID== Stationid && p.StationName == Stationname).ToList();
            }
            else if ((Provice!= "==请选择=="|| Provice!="")&& City == "==请选择==" && Country == "==请选择==" && Stationid ==0 && (Stationname == null || Stationname == ""))
            {
                hs = hsbll.Query(p => p.Province == Provice).ToList();
            }
            else if ((Provice != "==请选择==" || Provice != "") && City == "==请选择==" && Country == "==请选择==" && Stationid != 0)
            {
                hs = hsbll.Query(p => p.Province == Provice&&p.StationID==Stationid).ToList();
            }
            else if ((Provice != "==请选择==" || Provice != "") && City == "==请选择==" && Country == "==请选择==" && (Stationname != "" && Stationname != null))
            {
                hs = hsbll.Query(p => p.Province == Provice && p.StationName == Stationname).ToList();
            }
            else if ((Provice != "==请选择=="&&Provice != "") && (City != "==请选择=="&&City!="") && Country == "==请选择==" && Stationid ==0 && (Stationname == null || Stationname == ""))
            {
                hs = hsbll.Query(p => p.Province == Provice&&p.City==City).ToList();
            }
            else if ((Provice != "==请选择==" && Provice != "") && (City != "==请选择==" && City != "") && Country == "==请选择==" && Stationid !=0)
            {
                hs = hsbll.Query(p => p.Province == Provice && p.City == City&&p.StationID== Stationid).ToList();
            }
            else if ((Provice != "==请选择==" && Provice != "") && (City != "==请选择==" && City != "") && Country == "==请选择==" && (Stationname != "" && Stationname != null))
            {
                hs = hsbll.Query(p => p.Province == Provice && p.City == City && p.StationName == Stationname).ToList();
            }
            else if ((Provice != "==请选择==" && Provice != "") && (City != "==请选择==" && City != "") &&(Country != "==请选择=="&& Country!="") && Stationid ==0 && (Stationname == null || Stationname == ""))
            {
                hs = hsbll.Query(p => p.Province == Provice && p.City == City&&p.County==Country).ToList();
            }
            else if ((Provice != "==请选择==" && Provice != "") && (City != "==请选择==" && City != "") && (Country != "==请选择==" && Country != "")&&Stationid != 0)
            {
                //int StationID=
                hs = hsbll.Query(p => p.Province == Provice && p.City == City && p.County == Country && p.StationID == Stationid).ToList();
            }
            else if ((Provice != "==请选择==" && Provice != "") && (City != "==请选择==" && City != "") && (Country != "==请选择==" && Country != "") && (Stationname != "" && Stationname != null))
            {
                hs = hsbll.Query(p => p.Province == Provice && p.City == City && p.County == Country&&p.StationName== Stationname).ToList();
            }
            List<hydStation> hs_ = new List<hydStation>();
            hs_ = hs.Skip(cp).Take(ps).ToList();
            hystationEntity hsentity = new hystationEntity();
            hsentity.rows = hs_;
            hsentity.total = hs.Count;
            hsentity.page = hs.Count / 5;
            return hsentity;
        }
    }
}
