using Core.Enums;

namespace Core.Interfaces
{
    public interface IClimate : IBase
    {
        CoreEnums.Climate ClimateType { get; set; } // low, mid, or high latitude?

        CoreEnums.AverageRange AveragePrecipitation { get; set; }
        double AveragePrecipitationCentimeters { get; set; }

        CoreEnums.AverageRange AverageTemperature { get; set; }
        double AverageTemperatureCelcius { get; set; }
    }
}
