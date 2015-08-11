using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IPopulationCenters : IBase
    {
        ICivilization Civilization { get; set; }
        IRegion Region { get; set; } // where is it?
        List<IPerson> Population { get; set; }
        int MaxPopulation { get; }
        bool HasPort { get; set;}
        bool HasMarket { get; set; }
        // anything else?
    }
}
