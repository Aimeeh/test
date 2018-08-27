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
    public class NSY_RTRUNBll: BaseBLL<NSY_RTRUN>, INSY_RTRUNBLL
    {
        public NSY_RTRUNEntity GetRainDataByConditional(string StationId, DateTime? Sdate, DateTime? Edate, string StationName, int cp, int ps,string transType)
        {
            var _sdate = Sdate == null ? new DateTime(1999, 1, 1) : Sdate.Value;
            var _edate = Edate == null ? new DateTime(2999, 1, 1) : Edate.Value;
            List<NSY_RTRUN> nsy = new List<NSY_RTRUN>();
            AbsFacory absfact = AbsFacory.CreatInstance();
            INSY_RTRUNBLL nsybll = absfact.CreatINSY_RTRUNBLLInstance();
            if (transType == "" || transType == null|| transType=="全部报")
            {
                nsy = nsybll.Query(p => p.STCD == StationId && p.DATATYPE == "26" && p.INSERTTM >= _sdate && p.INSERTTM <= _edate)
                .OrderByDescending(s => s.TM)
                .ToList();
            }
            else
            {
                var transType_ = 0;
                if (transType=="加报报")
                {
                    transType_ = 5;

                }else if (transType=="定时报")
                {
                    transType_ =60;
                }
                nsy = nsybll.Query(p => p.STCD == StationId 
                && p.DATATYPE == "26" && p.INSERTTM >= _sdate 
                && p.INSERTTM <= _edate&&p.PDR== transType_)
                .OrderByDescending(s => s.TM)
                .ToList();
            }
            List<NSY_RTRUN> nsyShow = new List<NSY_RTRUN>();
            nsyShow = nsy.Skip(cp).Take(ps)
                .ToList();
            NSY_RTRUNEntity nsyEntity = new NSY_RTRUNEntity();
            nsyEntity.rows = nsyShow;
            nsyEntity.total = nsy.Count;
            nsyEntity.page = nsy.Count/5;
            return nsyEntity;
        }

        public NSY_RTRUNEntity GetWaterDataByConditional(string StationId, DateTime? Sdate, DateTime? Edate, string StationName, int cp, int ps, string transType)
        {
            var _sdate = Sdate == null ? new DateTime(1999, 1, 1) : Sdate.Value;
            var _edate = Edate == null ? new DateTime(2999, 1, 1) : Edate.Value;
            List<NSY_RTRUN> nsy = new List<NSY_RTRUN>();
            AbsFacory absfact = AbsFacory.CreatInstance();
            INSY_RTRUNBLL nsybll = absfact.CreatINSY_RTRUNBLLInstance();
            if (transType == "" || transType == null || transType == "全部报")
            {
                nsy = nsybll.Query(p => p.STCD == StationId && p.DATATYPE == "39" && p.INSERTTM >= _sdate && p.INSERTTM <= _edate)
                .OrderByDescending(s => s.TM)
                .ToList();
            }
            else
            {
                var transType_ = 0;
                if (transType == "加报报")
                {
                    transType_ = 5;

                }
                else if (transType == "定时报")
                {
                    transType_ = 60;
                }
                nsy = nsybll.Query(p => p.STCD == StationId
                && p.DATATYPE == "39" && p.INSERTTM >= _sdate
                && p.INSERTTM <= _edate && p.PDR == transType_)
                .OrderByDescending(s => s.TM)
                .ToList();
            }
            List<NSY_RTRUN> nsyShow = new List<NSY_RTRUN>();
            nsyShow = nsy.Skip(cp).Take(ps)
                .ToList();
            NSY_RTRUNEntity nsyEntity = new NSY_RTRUNEntity();
            nsyEntity.rows = nsyShow;
            nsyEntity.total = nsy.Count;
            nsyEntity.page = nsy.Count / 5;
            return nsyEntity;
        }


    }
}
