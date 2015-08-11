using Core.Enums;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRegion : IBase
    {
        IClimate Climate { get; set; }
        CoreEnums.RegionSize Size { get; set; }
        int AreaKilometersSquare { get; set; }
        ITopography Topography { get; set; }
        List<IFeatures> Features { get; set; }
        List<ICivilization> Civilizations { get; set; }
        List<IPopulationCenters> PopulationCenters { get; set; }
        // TODO: what about AdjoiningRegions????


        // List<Monuments> of monuments

        // list of territories (what are territories?)
        // level of population (make an enum; heavy, moderate, low)
        // contested?
        // who lives here?

        bool CanSupportAdditionalPopulationCenters();
    }
}
