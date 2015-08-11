using Core.Enums;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Climates
{
    public class Desert : IClimate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CoreEnums.Climate ClimateType { get; set; } // low, mid, or high latitude?
        
        public CoreEnums.AverageRange AveragePrecipitation { get; set; }
        public double AveragePrecipitationCentimeters { get; set; }

        public CoreEnums.AverageRange AverageTemperature { get; set; }
        public double AverageTemperatureCelcius { get; set; }
        
        // TODO: these generate the above averages...
        private int _TemperatureHigh = 37;
        private int _TemperatureLow = -3;
        private int _RainfallHigh = 22;
        private int _RainfallLow = 2;

        public Desert()
        {
            AveragePrecipitation = CoreEnums.AverageRange.Moderate;
            AveragePrecipitationCentimeters = Utility.Region.GetAverageRainFall(_RainfallHigh, _RainfallLow);
            AverageTemperature = CoreEnums.AverageRange.Moderate;
            AverageTemperatureCelcius = Utility.Region.GetAverageTemperature(_TemperatureHigh, _TemperatureLow);
        }
    }
}
