//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HandleModel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CorrectionFactor
    {
        public int CFId { get; set; }
        public int StationID { get; set; }
        public Nullable<double> RainCorrFactorA { get; set; }
        public Nullable<double> RainCorrFactorB { get; set; }
        public Nullable<double> SediCorrFactorA { get; set; }
        public Nullable<double> SediCorrFactorB { get; set; }
        public Nullable<int> evaUpperlimit { get; set; }
        public Nullable<int> evaLowerlimit { get; set; }
        public Nullable<System.DateTime> WStartTime { get; set; }
        public Nullable<System.DateTime> WEndTime { get; set; }
        public Nullable<double> EvaMiddValue { get; set; }
        public Nullable<double> EvaWeight { get; set; }
        public Nullable<double> LTempLimit { get; set; }
    }
}
