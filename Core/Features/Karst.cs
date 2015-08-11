using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Features
{
    // A Karst is a landscape formed from the dissolution of soluble rocks including limestone, dolomite and gypsum. It is characterized by sinkholes, caves, and underground drainage systems
    public class Karst : IFeatures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private List<IClimate> ClimateRestrictions { get; set; }
    }
}
