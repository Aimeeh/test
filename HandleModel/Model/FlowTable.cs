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
    
    public partial class FlowTable
    {
        public int FTId { get; set; }
        public Nullable<int> StationID { get; set; }
        public Nullable<System.DateTime> FTestStartTime { get; set; }
        public Nullable<System.DateTime> FTestEndTime { get; set; }
        public Nullable<double> StartwaterLev { get; set; }
        public Nullable<double> EndwaterLev { get; set; }
        public Nullable<double> WaterWidth { get; set; }
        public Nullable<double> FlowValue { get; set; }
        public Nullable<int> WaterModel { get; set; }
        public Nullable<int> SpeedverCount { get; set; }
        public Nullable<double> SecArea { get; set; }
        public Nullable<double> MeanDepth { get; set; }
        public Nullable<double> MaxDepth { get; set; }
        public Nullable<double> MeanVelocity { get; set; }
        public Nullable<double> MaxVelocity { get; set; }
        public int CPId { get; set; }
        public string RevTime { get; set; }
    }
}