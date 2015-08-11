using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Features
{
    public class Dunes : IFeatures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private List<IClimate> ClimateRestrictions { get; set; }
    }
}
