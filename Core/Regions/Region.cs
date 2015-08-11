using Core.Enums;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Regions
{
    public class Region : IRegion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IClimate Climate { get; set; }
        public CoreEnums.RegionSize Size { get; set; }
        public int AreaKilometersSquare { get; set; }
        public ITopography Topography { get; set; }
        public List<IFeatures> Features { get; set; }
        public List<ICivilization> Civilizations { get; set; }
        public List<IPopulationCenters> PopulationCenters { get; set; }

        private int _MaxCivilizations = 5; // how can I use this?
        private int _MaxPopulationCenters = 7; // how can I use this?
        // list of territories (what are territories?)
        // level of population (make an enum; heavy, moderate, low)
        // contested?
        // who lives here?
        // size of the region. Likely linked to size of the continent (a VeryLarge continent can support a certain number)

        public Region()
        {
            Features = new List<IFeatures>();
            Civilizations = new List<ICivilization>();
            PopulationCenters = new List<IPopulationCenters>();
        }

        // is this the best way to implement this?
        public bool CanSupportAdditionalPopulationCenters()
        {
            return (PopulationCenters.Count < _MaxPopulationCenters);
        }
    }
}
