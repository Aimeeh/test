using HandleModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace WacqIBLL
{
    public interface INSY_RTRUNBLL:IBaseBLL<NSY_RTRUN>
    {
        NSY_RTRUNEntity GetWaterDataByConditional(string StationId, DateTime? Sdate, DateTime? Edate, string StationName, int cp, int ps, string transType);
        NSY_RTRUNEntity GetRainDataByConditional(string StationId, DateTime? Sdate, DateTime? Edate, string StationName, int cp, int ps, string transType);
    }
}
