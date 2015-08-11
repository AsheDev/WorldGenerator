using System;
using Core.Enums;
using System.Linq;
using System.Text;
using Core.Regions;
using Core.Factories;
using Core.Interfaces;
using Core.Civilizations;
using System.Threading.Tasks;
using Core.PopulationCenters;
using System.Collections.Generic;

namespace Generate
{
    public class RegionGen
    {
        private List<string> RegionNames { get; set; }
        private List<string> Adjectives { get; set; }
        private Random Random { get; set; }
        private NameGen Names { get; set; }

        public RegionGen()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="continent"></param>
        /// <returns></returns>
        public List<IRegion> Generate(IContinent continent, List<ICivilization> civilizations)
        {
            List<IRegion> listOfRegions = new List<IRegion>();
            int remainingKilometersSquare = continent.AreaKilometersSquare;
            int regionCount = 0;
            while(true)
            {
                // FOR EXAMPLE: A Savanna shouldn't have a forest in it
                IRegion region = new Region();
                region.Id = regionCount;
                region.Climate = ClimateFactory.Get(continent.UpperLatitude, continent.Lowerlatitude); // TODO: this should be based off latitude (upper and lower bounds) of parent continent
                region.Name = GetName(region.Climate);
                region.Size = SelectRandomSize(remainingKilometersSquare, 5);
                region.AreaKilometersSquare = CalculateRegionSizeKM(region.Size);
                region.Topography = TopographyFactory.Get(Random.Next(0, 6), region.Size, region.Climate); // TODO: pass in the climate type so features can be filtered out (no forests in tundra for example)
                region.Features = region.Topography.Features; // FROM ABOVE: features here should be based off climate...
                region.Civilizations.Add(civilizations.ElementAt(Random.Next(0, civilizations.Count - 1)));
                listOfRegions.Add(region);

                remainingKilometersSquare -= region.AreaKilometersSquare;
                if (remainingKilometersSquare < (int)CoreEnums.RegionSize.VerySmall)
                {
                    region.AreaKilometersSquare += remainingKilometersSquare;
                    break;
                }
                regionCount++;
            }
            return listOfRegions;
        }

        // TODO: this should pick the number of features dependent upon the SIZE of the region
        // TODO: this will need to be smarter. We can't have Dunes next to shrubland next to forests or somesuch
        private List<IFeatures> PopulateRegionWithFeatures(List<IFeatures> features)
        {
            // TODO: instead of removing items we'll need to add them to a new list while checking that the Features are compatible
            int sentinel = (features.Count / 2);
            while (true)
            {
                features.RemoveAt(Random.Next(0, features.Count - 1));
                if (sentinel == features.Count) break;
            }

            return features;
        }

        /// <summary>
        /// Selects a random size for a region based on the current size of a continent
        /// </summary>
        /// <param name="currentSize">The size of the continent</param>
        /// <param name="upperLimit">Relates to the size of the continents that can be used. 5 is the max.</param>
        /// <returns>Returns a Core.Enums.RegionSize value</returns>
        private CoreEnums.RegionSize SelectRandomSize(int currentSize, int upperLimit)
        {
            if (upperLimit > 5) upperLimit = 5;
            CoreEnums.RegionSize size = CoreEnums.RegionSize.VerySmall;
            switch (Random.Next(0, upperLimit))
            {
                case 0:
                    return size;
                case 1:
                    size = CoreEnums.RegionSize.Small;
                    if ((int)size < currentSize)
                    {
                        return size;
                    }
                    else
                    {
                        return SelectRandomSize(currentSize, 1);
                    }
                case 2:
                    size = CoreEnums.RegionSize.Moderate;
                    if ((int)size < currentSize)
                    {
                        return size;
                    }
                    else
                    {
                        return SelectRandomSize(currentSize, 2);
                    }
                case 3:
                    size = CoreEnums.RegionSize.Large;
                    if ((int)size < currentSize)
                    {
                        return size;
                    }
                    else
                    {
                        return SelectRandomSize(currentSize, 3);
                    }
                default:
                    size = CoreEnums.RegionSize.VeryLarge;
                    if ((int)size < currentSize)
                    {
                        return size;
                    }
                    else
                    {
                        return SelectRandomSize(currentSize, 4);
                    }
            }
        }

        private int CalculateRegionSizeKM(CoreEnums.RegionSize size)
        {
            int plusOrMinus = Convert.ToInt32(((double)CoreEnums.RegionSize.VerySmall * (double).27));
            switch ((int)size)
            {
                case 1400000:  // VerySmall
                    return Random.Next((int)CoreEnums.RegionSize.VerySmall - plusOrMinus, (int)CoreEnums.RegionSize.VerySmall + plusOrMinus);
                case 3200000: // Small
                    return Random.Next((int)CoreEnums.RegionSize.Small - plusOrMinus, (int)CoreEnums.RegionSize.Small + plusOrMinus);
                case 4000000: // Moderate
                    return Random.Next((int)CoreEnums.RegionSize.Moderate - plusOrMinus, (int)CoreEnums.RegionSize.Moderate + plusOrMinus);
                case 5300000: // Large
                    return Random.Next((int)CoreEnums.RegionSize.Large - plusOrMinus, (int)CoreEnums.RegionSize.Large + plusOrMinus);
                default:       // VeryLarge
                    return Random.Next((int)CoreEnums.RegionSize.VeryLarge - plusOrMinus, (int)CoreEnums.RegionSize.VeryLarge + plusOrMinus);
            }
        }
        
        private string GetCardinalDirections()
        {
            List<string> direction = new List<string>
            {
                "North",
                "Northern",
                "East",
                "Eastern",
                "West",
                "Western",
                "South",
                "Southern"
            };
            return direction[Random.Next(0, direction.Count - 1)];
        }

        /// <summary>
        /// Generate a name for the region
        /// </summary>
        /// <param name="climate"></param>
        /// <returns></returns>
        private string GetName(IClimate climate)
        {
            switch (Random.Next(0, 3))
            {
                case 0:
                    return ((Random.Next(0, 5) == 0) ? Names.RegionNameWithAdjective(climate, CoreEnums.Word.HumanPlace) : Names.RegionName(climate, CoreEnums.Word.HumanPlace));
                case 1:
                    return ((Random.Next(0, 5) == 0) ? Names.RegionNameWithAdjective(climate, CoreEnums.Word.ElfPlace) : Names.RegionName(climate, CoreEnums.Word.ElfPlace));
                case 2:
                default:
                    return ((Random.Next(0, 5) == 0) ? Names.RegionNameWithAdjective(climate, CoreEnums.Word.DwarfPlace) : Names.RegionName(climate, CoreEnums.Word.DwarfPlace));
            }
        }
    }
}
