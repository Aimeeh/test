//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTU_WaterData.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ST_RIVER_R
    {
        public string STCD { get; set; }
        public System.DateTime TM { get; set; }
        public Nullable<decimal> Z { get; set; }
        public Nullable<decimal> Q { get; set; }
        public Nullable<decimal> XSA { get; set; }
        public Nullable<decimal> XSAVV { get; set; }
        public Nullable<decimal> XSMXV { get; set; }
        public string FLWCHRCD { get; set; }
        public string WPTN { get; set; }
        public string MSQMT { get; set; }
        public string MSAMT { get; set; }
        public string MSVMT { get; set; }
    }
}