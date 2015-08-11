using System;
using Core.Enums;
using System.Linq;
using Core.Factories;
using Core.Interfaces;
using Core.PopulationCenters;
using System.Collections.Generic;

namespace Generate
{
    public class PopulationCenterGen
    {
        private Random Random { get; set; }
        private NameGen Names { get; set; }

        public PopulationCenterGen()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
        }

        /// <summary>
        /// Generates a single Hamlet.
        /// </summary>
        /// <returns></returns>
        public IPopulationCenters GenerateSingle(ICivilization civilization)
        {
            IPopulationCenters center = null;
            if (!civilization.RegionsOwned.Last().CanSupportAdditionalPopulationCenters()) return center; // as long as the last region has available centers we can keep going
            
            center = new Hamlet(); // we start with a hamlet and move up as population increases
            return CreateCenter(civilization, center);
        }

        public IPopulationCenters Upgrade(ICivilization civilization, IPopulationCenters center)
        {
            IPopulationCenters upgrade = null;
            if (!civilization.RegionsOwned.Last().CanSupportAdditionalPopulationCenters()) return upgrade; // as long as the last region has available centers we can keep going

            if (!center.GetType().Name.ToLower().Equals("metropolis"))
            {
                upgrade = PopulationCenterFactory.Get(center.GetType().Name);
            }
            else // we have a metropolis. Generate a new Hamlet now.
            {
                return GenerateSingle(civilization);
            }

            return CreateCenter(civilization, upgrade);
        }

        // multiple or only one civilization being passed in?
        public List<IPopulationCenters> GenerateMultiple(List<ICivilization> civilizations, IRegion region)
        {
            // let's just build a random number of them for now...
            List<IPopulationCenters> populationCenters = new List<IPopulationCenters>();
            int randomCount = Random.Next(0, 4);
            for (int n = 0; n < randomCount; n++)
            {
                IPopulationCenters center = PopulationCenterFactory.Get(Random.Next(0, 7));
                center.Id = n;
                center.Name = Names.SingleName(CoreEnums.Word.HumanPlace);
                center.Description = "CENTERDESCRIPTION";
                center.Civilization = civilizations.ElementAt(Random.Next(0, 3)); // TODO: this is made up. Heh.
                center.Region = region;
                // population is established when constructed
                center.HasPort = false;
                center.HasMarket = true;
                populationCenters.Add(center);
            }
            return populationCenters;
        }

        private IPopulationCenters CreateCenter(ICivilization civilization, IPopulationCenters center)
        {
            center.Id = Random.Next(0, 423645245);
            center.Name = Names.SingleName(CoreEnums.Word.HumanPlace); // TODO: named according to race
            center.Description = "DESCRIPTION";
            center.Civilization = civilization;
            center.Region = civilization.RegionsOwned.First(r => r.CanSupportAdditionalPopulationCenters());
            center.Population = new List<IPerson>();
            center.HasPort = false; // TODO: hard coded
            center.HasMarket = true; // TODO: hard coded
            return center;
        }
    }
}
