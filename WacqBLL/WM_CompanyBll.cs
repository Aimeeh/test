using HandleModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using WacqAbsFactory;
using WacqIBLL;

namespace WacqBLL
{
    public class WM_CompanyBll : BaseBLL<WM_Company>, IWM_CompanyBLL
    {
        /// <summary>
        /// 查询站点列表和省份集合
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public StructuralEntity GetSationList(string CompanyID,string UserID)
        {
            StructuralEntity StEntity = new StructuralEntity();
            //加载操作表格对象
            AbsFacory absfact = AbsFacory.CreatInstance();
            IhydStationBLL hsbll = absfact.CreathydStationBllInstance();
            IWM_CompanyBLL cbll = absfact.CreatIWM_CompanyBLLInstance();
            //超级管理员账户
            if (UserID== ConfigHelper.AppSettings("CurrentUserName"))
            {
                //加载所有站点信息
                //List<hydStation> hs = hsbll.Query(p=>true).ToList();
                //加载所有省份信息
                List<ProvinceEntity> pentity = new List<ProvinceEntity>();
                var pe = cbll.Query(p=>true)
                 .Select(x =>new
                {
                     x.Province
                 }).Distinct().ToList();
                for(int i = 0; i < pe.Count; i++)
                {
                    ProvinceEntity ppe = new ProvinceEntity();
                    ppe.Province = pe[i].Province;
                    pentity.Add(ppe);
                }
                //StEntity.stationEntity = hs;
                StEntity.provinceEntity = pentity;
            }
            else//区域管理员账户
            {
                //加载区域管理员账户管辖的所有站点信息
                //List<hydStation> hs = new List<hydStation>();
                //List<ProvinceEntity> pe = new List<ProvinceEntity>();
                var pe = cbll.Query(p => p.CompanyId == CompanyID)
                .Select(x => new ProvinceEntity
                {
                    Province = x.Province,
                    City = x.City,
                    County = x.County
                }).FirstOrDefault();
                //if ((pe.City==""||pe.City==null||pe.City== "&nbsp;")&&(pe.County==""||pe.City==null||pe.County== "&nbsp;"))
                //{
                //    hs = hsbll.Query(p => p.Province == pe.Province).ToList();
                //}
                //else if((pe.City != "" || pe.City != null || pe.City != "&nbsp;") && (pe.County == "" || pe.City == null || pe.County == "&nbsp;"))
                //{
                //    hs = hsbll.Query(p => p.Province == pe.Province&&p.City==pe.City).ToList();
                //}
                //else if ((pe.City != "" || pe.City != null || pe.City != "&nbsp;") && (pe.County != "" || pe.City != null || pe.County != "&nbsp;"))
                //{
                //    hs = hsbll.Query(p => p.Province == pe.Province && p.City == pe.City&&p.County==pe.County).ToList();
                //}
                List<ProvinceEntity> provice = new List<ProvinceEntity>();
                ProvinceEntity pentity = new ProvinceEntity();
                pentity.Province= pe.Province;
                provice.Add(pentity);
                //StEntity.stationEntity = hs;
                StEntity.provinceEntity = provice;
            }
            return StEntity;
        }

        /// <summary>
        /// 获得城市集合
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="provice"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public object GetCityListByUser(string UserID,string provice,string CompanyID)
        {
            //加载操作表格对象
            AbsFacory absfact = AbsFacory.CreatInstance();
            IhydStationBLL hsbll = absfact.CreathydStationBllInstance();
            IWM_CompanyBLL cbll = absfact.CreatIWM_CompanyBLLInstance();
            if (UserID == ConfigHelper.AppSettings("CurrentUserName"))
            {
                var city_Entity = hsbll.Query(p => p.Province == provice)
                 .Select(x => new
                {
                    City = x.City
                }).Distinct().ToList();
                return city_Entity;
            }
            else
            {
                var pe = cbll.Query(p => p.CompanyId == CompanyID)
                    .Select(x => new ProvinceEntity
                    {
                        Province = x.Province,
                        City = x.City,
                        County = x.County
                    }).FirstOrDefault();
                if ((pe.City == "" || pe.City == null || pe.City == "&nbsp;") && (pe.County == "" || pe.City == null || pe.County == "&nbsp;"))
                {
                   var hs = hsbll.Query(p => p.Province == pe.Province)
                        .Select(x=>new { City = x.City }).Distinct().ToList();
                    return hs;
                }
                else if ((pe.City != "" || pe.City != null || pe.City != "&nbsp;") && (pe.County == "" || pe.City == null || pe.County == "&nbsp;"))
                {
                    var hs = hsbll.Query(p => p.Province == pe.Province&&p.City==pe.City)
                         .Select(x => new { City = x.City }).Distinct().ToList();
                    return hs;
                }
            }
            return "";
        }

        /// <summary>
        /// 获得区县集合
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="provice"></param>
        /// <param name="city"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public object GetCountryListByUser(string UserID, string provice,string city, string CompanyID)
        {
            //加载操作表格对象
            AbsFacory absfact = AbsFacory.CreatInstance();
            IhydStationBLL hsbll = absfact.CreathydStationBllInstance();
            IWM_CompanyBLL cbll = absfact.CreatIWM_CompanyBLLInstance();
            if (UserID == ConfigHelper.AppSettings("CurrentUserName"))
            {
                var city_Entity = hsbll.Query(p => p.Province == provice&&p.City==city)
                 .Select(x => new
                 {
                     Country = x.County
                 }).Distinct().ToList();
                return city_Entity;
            }
            else
            {
                var pe = cbll.Query(p => p.CompanyId == CompanyID)
                    .Select(x => new ProvinceEntity
                    {
                        Province = x.Province,
                        City = x.City,
                        County = x.County
                    }).FirstOrDefault();
                if ((pe.City == "" || pe.City == null || pe.City == "&nbsp;") && (pe.County == "" || pe.City == null || pe.County == "&nbsp;"))
                {
                    var hs = hsbll.Query(p => p.Province == pe.Province && p.City == city)
                         .Select(x => new { Country = x.County }).Distinct().ToList();
                    return hs;
                }
                else if ((pe.City != "" || pe.City != null || pe.City != "&nbsp;") && (pe.County == "" || pe.City == null || pe.County == "&nbsp;"))
                {
                    var hs = hsbll.Query(p => p.Province == pe.Province && p.City == city)
                         .Select(x => new { Country = x.County }).Distinct().ToList();
                    return hs;
                }
                else if ((pe.City != "" || pe.City != null || pe.City != "&nbsp;") && (pe.County != "" || pe.City != null || pe.County != "&nbsp;"))
                {
                    var hs = hsbll.Query(p => p.Province == pe.Province && p.City == city&&p.County==pe.County)
                         .Select(x => new { Country = x.County }).Distinct().ToList();
                    return hs;
                }
            }
            return "";
        }
    }
}
