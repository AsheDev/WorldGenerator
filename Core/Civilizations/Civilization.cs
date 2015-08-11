using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Civilizations
{
    public class Civilization : ICivilization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}

        public IRace Race { get; set; }
        public List<IRegion> RegionsOwned { get; set; }
        public List<IPopulationCenters> PopulationCenters { get; set; }
        public List<IPerson> TotalPopulation { get; set; }
    }
}
