using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WacqBllFactory
{
    using WacqIBLL;
    using WacqBLL;
    using WacqAbsFactory;

    public class Factory:AbsFacory
    {
        public override IConfigParameterBLL CreatConfigParameterBllInstance()
        {
            return new ConfigParameterBll();
        }

        public override IhydStationBLL CreathydStationBllInstance()
        {
            return new hydStationBll();
        }

        public override IMeasuredParameterBLL CreatMeasureParameterBllInstance()
        {
            return new MeasureParameterBll();
        }

        public override ISoundverDataBLL CreatSoundverDataBllInstance()
        {
            return new SoundverDataBll();
        }

        public override ISpeedDataBLL CreatSpeedDataBllInstance()
        {
            return new SpeedDataBll();
        }
        public override IWM_UserBLL CreatIWM_UserBllInstance()
        {
            return new WM_UserBll();
        }

        public override IWM_CompanyBLL CreatIWM_CompanyBLLInstance()
        {
            return new WM_CompanyBll();
        }

        public override INSY_RTRUNBLL CreatINSY_RTRUNBLLInstance()
        {
            return new NSY_RTRUNBll();
        }
    }
}
