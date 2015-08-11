using Core.Enums;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Continents
{
    public class Continent : IContinent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IWorld World { get; set; }
        public CoreEnums.ContinentSize Size { get; set; }
        public int AreaKilometersSquare { get; set; }
        public List<IRegion> ListOfRegions { get; set; }
        public Dictionary<CoreEnums.CardinalDirections, IContinent> AdjoiningContinents { get; set; } // 0 means there is no connection yet
        public int UpperLatitude { get; set; }
        public int Lowerlatitude { get; set; }
        public List<ICivilization> CivilizationsPresent { get; set; }
        // number of civilizations
        // number of cities, hm?
        // bodies of water surrounding? we can see how it's all connected
    }
}
