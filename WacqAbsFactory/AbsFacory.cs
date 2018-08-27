using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WacqAbsFactory
{
    using WacqIBLL;
    using System.Reflection;
    /// <summary>
    /// 抽象工厂类，将来被业务工厂继承，并且重写其中的抽象方法
    /// </summary>
    public abstract class AbsFacory
    {
        public static AbsFacory CreatInstance()
        {
            //通过反射来创建当前AbsFacory的子类对象
            Assembly ass = Assembly.Load("WacqBllFactory");
            object obj = ass.CreateInstance("WacqBllFactory.Factory");
            return obj as AbsFacory;
        }
        public abstract IhydStationBLL CreathydStationBllInstance();
        public abstract IConfigParameterBLL CreatConfigParameterBllInstance();
        public abstract IMeasuredParameterBLL CreatMeasureParameterBllInstance();
        public abstract ISoundverDataBLL CreatSoundverDataBllInstance();
        public abstract ISpeedDataBLL CreatSpeedDataBllInstance();
        public abstract IWM_UserBLL CreatIWM_UserBllInstance();
        public abstract IWM_CompanyBLL CreatIWM_CompanyBLLInstance();
        public abstract INSY_RTRUNBLL CreatINSY_RTRUNBLLInstance();
    }
}
