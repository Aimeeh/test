using HandleModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class StructuralEntity
    {
        public List<hydStation> stationEntity { get; set; }
        public List<ProvinceEntity> provinceEntity { get; set; }

    }

    public class ProvinceEntity
    {
        public string Province { get;  set; }
        public string City { get; set; }
        public string County { get; set; }

        //public List<CityEntity> cityEntity { get; internal set; }

        //public List<CountyEntity> countyEntity { get; internal set; }

    }

    public class CityEntity
    {
        public string City { get; internal set; }
    }

    public class CountyEntity
    {
        public string County { get; internal set; }
    }

    public class NSY_RTRUNEntity
    {
        public List<NSY_RTRUN> rows { get; set; }
        public int page { get; set; }
        public int total { get; set; }
    }

    public class hystationEntity
    {
        public List<hydStation> rows { get; set; }
        public int page { get; set; }
        public int total { get; set; }
    }

    public class MResults
    {
        public int CPId { get; set; }
        public int FTId { get; set; }
        public DateTime? Time { get; set; }
        public double? TotalArea { get; set; }
        public double? TotalFlow { get; set; }
        public double? TotalSpeed { get; set; }
        public double? MaxSpeed { get; set; }
        public double? TotalDepth { get; set; }
        public double? LineCount { get; set; }
        public int MaxLineCount { get; set; }
        public double? MaxDepth { get; set; }
        public double? WaterWidth { get; set; }
        public double? StartWaterLev { get; set; }
        public double? EndWaterLev { get; set; }
        public double? WaterSpeed { get; set; }
        public double? Flow { get; set; }
        public double? RightDistance { get; set; }
        public double? LeftDistance { get; set; }
        public double? BaseBottle { get; set; }
        public double? TopElevWaterGau { get; set; }
        public double? SecArea { get; set; }
        public double? MeanVelocity { get; set; }
        public string RevTime { get; set; }
        public double w1 { get; set; }
        public double w2 { get; set; }
        public int? WaterModel { get; set; }
        public List<PartData> PartData { get;set;}
        public List<SoundLineInfo> SoundLine { get;  set; }
        public List<VelocityLineInfo> VelocityLine { get;  set; }
    }

    

    
    public class SoundLineInfo
    {
       
        public double? RiverElva { get; set; }
 
        public double? StartDistL { get; set; }
    }

    public class VelocityLineInfo
    {
        public double? HCoeff { get; set; }
       
        public double? LCoeff { get; set; }

        public double? MCoeff { get; set; }

        public double? CorrecFactor { get; set; }
   
        public double? StartDistV { get; set; }
    
        public double? RiverElva { get; set; }
        
        public double? HCoeffA { get; set; }
    
        public double? HCoeffB { get; set; }
        
        public double? MCoeffA { get; set; }
     
        public double? MCoeffB { get; set; }
      
        public double? LCoeffA { get; set; }

        public double? LCoeffB { get; set; }
    }
    public class PartData
    {
        public double? Xpos { get; set; }
        public double? Depth { get; set; }
        public double? MSpeed { get; set; }
        public double? MeanSpeed { get; set; }
        public double? PartArea { get; set; }
        public double? PartFlow { get; set; }
        public double? CorrFactor { get; set; }
    }
}
