using Core.Utility;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.PopulationCenters
{
    public class Town : IPopulationCenters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICivilization Civilization { get; set; }
        public IRegion Region { get; set; }
        public List<IPerson> Population { get; set; }
        public int MaxPopulation { get { return maxPopulation; } }
        public bool HasPort { get; set; }
        public bool HasMarket { get; set; }

        private double PopulationModifier = .22;
        private int maxPopulation;

        public Town()
        {
            maxPopulation = 32000;
            //Population = PopulationCenter.GetPopulation(_MaxPopulation, PopulationModifier);
        }
    }
}