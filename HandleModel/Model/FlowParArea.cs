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
    
    public partial class FlowParArea
    {
        public int FpaId { get; set; }
        public int StationID { get; set; }
        public Nullable<double> FlowData { get; set; }
        public Nullable<double> PartArea { get; set; }
        public Nullable<double> CorrFactor { get; set; }
        public int FTId { get; set; }
        public string RevTime { get; set; }
        public Nullable<double> PartDepth { get; set; }
        public Nullable<double> PMeanDepth { get; set; }
        public Nullable<double> PartVelocity { get; set; }
        public Nullable<double> PMeanVelocity { get; set; }
    }
}
