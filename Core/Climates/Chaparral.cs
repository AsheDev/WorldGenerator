using Core.Enums;
using Core.Interfaces;

namespace Core.Climates
{
    public class Chaparral : IClimate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CoreEnums.Climate ClimateType { get; set; } // low, mid, or high latitude?

        public CoreEnums.AverageRange AveragePrecipitation { get; set; }
        public double AveragePrecipitationCentimeters { get; set; }

        public CoreEnums.AverageRange AverageTemperature { get; set; }
        public double AverageTemperatureCelcius { get; set; }

        // these generate the above averages...
        private double _TemperatureHigh = 10;
        private double _TemperatureLow = -40;
        private double _RainfallHigh = 38.1;
        private double _RainfallLow = 20.32;

        public Chaparral()
        {
            AveragePrecipitation = CoreEnums.AverageRange.Moderate;
            AveragePrecipitationCentimeters = Utility.Region.GetAverageRainFall(_RainfallHigh, _RainfallLow);
            AverageTemperature = CoreEnums.AverageRange.Moderate;
            AverageTemperatureCelcius = Utility.Region.GetAverageTemperature(_TemperatureHigh, _TemperatureLow);
        }
    }
}