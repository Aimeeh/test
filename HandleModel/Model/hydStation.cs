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
    
    public partial class hydStation
    {
        public int SID { get; set; }
        public int StationID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public Nullable<int> CouID { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public string RiverWay { get; set; }
        public string Basin { get; set; }
        public Nullable<double> Voltage { get; set; }
        public Nullable<double> RTUVoltage { get; set; }
        public Nullable<double> RTUVoltage2 { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<byte> Onlinestate { get; set; }
        public string OnlineTime { get; set; }
        public string Province { get; set; }
        public string CityId { get; set; }
        public string City { get; set; }
        public string CountyId { get; set; }
        public string County { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Enabled { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public string ProvinceId { get; set; }
        public Nullable<int> DeleteMark { get; set; }
        public string KCode { get; set; }
        public string StationID_Code { get; set; }
        public string WarnPhoneNum { get; set; }
        public string DeviceType { get; set; }
        public string C_DeviceType { get; set; }
    }
}