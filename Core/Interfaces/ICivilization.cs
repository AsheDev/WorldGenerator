using System.Collections.Generic;

namespace Core.Interfaces
{
    // There can exist multiple civilizations for a single race
    // Think Sumer, Egypt, Babylon

    public interface ICivilization : IBase
    {
        IRace Race { get; set; }
        List<IRegion> RegionsOwned { get; set; }
        List<IPopulationCenters> PopulationCenters { get; set; }
        List<IPerson> TotalPopulation { get; set; }
        // what phase are they in? Are they a kingdom, or something else? I don't know
    }
}
