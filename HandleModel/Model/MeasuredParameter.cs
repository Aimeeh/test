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
    
    public partial class MeasuredParameter
    {
        public int MPId { get; set; }
        public Nullable<int> StationID { get; set; }
        public Nullable<double> HWaterValue { get; set; }
        public Nullable<double> HWaterMInterval { get; set; }
        public Nullable<double> HwaterFluctMeasure { get; set; }
        public Nullable<double> MWaterValue { get; set; }
        public Nullable<double> MWaterMInterval { get; set; }
        public Nullable<double> MwaterFluctMeasure { get; set; }
        public Nullable<double> LWaterMInterval { get; set; }
        public Nullable<double> LwaterFluctMeasure { get; set; }
        public Nullable<double> OffsetDistance { get; set; }
        public Nullable<double> WarnWaterValue { get; set; }
        public Nullable<double> WarnFlowValue { get; set; }
        public Nullable<double> WarnVelValue { get; set; }
        public int CPId { get; set; }
        public string RevTime { get; set; }
    }
}
