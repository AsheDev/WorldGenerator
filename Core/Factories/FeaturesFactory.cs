using System;
using Core.Features;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Factories
{
    public static class FeaturesFactory
    {
        private static Random _Random = new Random(Guid.NewGuid().GetHashCode());

        public static IFeatures Get(int id)
        {
            // read in the climate
            // depending upon the climat we get a feature associated with it



            switch (id)
            {
                case 0:
                    return new Bog();
                case 1:
                    return new Caves();
                case 2:
                    return new Craters();
                case 3:
                    return new Dunes();
                case 4:
                    return new Faults();
                case 5:
                    return new Forest();
                case 6:
                    return new Fumaroles();
                case 7:
                    return new Karst();
                case 8:
                    return new Ridges();
                case 9:
                    return new Rivers();
                case 10:
                    return new Shrubland();
                default:
                    return new Talus();
            }
        }

        public static IFeatures PopulateValley(int id, IClimate climate)
        {
            switch (id)
            {
                case 0:
                    return new Caves();
                case 1:
                    return new Caves();
                case 2:
                    return new Forest();
                case 3:
                    return new Forest();
                case 4:
                    return new Forest();
                case 5:
                    return new Rivers();
                case 6:
                    return new Rivers();
                case 7:
                    return new Ridges();
                case 8:
                    return new Shrubland();
                case 9:
                default:
                    return new Fumaroles();
            }
        }

        public static IFeatures PopulatePlains(int id, IClimate climate)
        {
            // if forests exist don't allow dunes and vice versa
            switch (id)
            {
                case 0:
                    return new Forest();
                case 1:
                    return new Forest();
                case 2:
                    return new Faults();
                case 3:
                    return new Rivers();
                case 4:
                    return new Shrubland();
                case 5:
                    return new Shrubland();
                case 6:
                    return new Bog();
                case 7:
                    return new Bog();
                case 8:
                    return new Dunes();
                case 9:
                default:
                    return new Dunes();
            }
        }

        public static IFeatures PopulateMountain(int id, IClimate climate)
        {
            switch (id)
            {
                case 0:
                    return new Caves();
                case 1:
                    return new Caves();
                case 2:
                    return new Forest();
                case 3:
                    return new Forest();
                case 4:
                    return new Ridges();
                case 5:
                    return new Ridges();
                case 6:
                    return new Rivers();
                case 7:
                    return new Karst();
                case 8:
                    return new Fumaroles();
                case 9:
                default:
                    return new Talus();
            }
        }

        public static IFeatures PopulateLowlands(int id, IClimate climate)
        {
            switch (id)
            {
                case 0:
                    return new Forest();
                case 1:
                    return new Forest();
                case 2:
                    return new Faults();
                case 3:
                    return new Rivers();
                case 4:
                    return new Bog();
                case 5:
                    return new Fumaroles();
                case 6:
                    return new Craters();
                case 7:
                    return new Shrubland();
                case 8:
                    return new Dunes();
                case 9:
                default:
                    return new Dunes();
            }
        }

        public static IFeatures PopulateHills(int id, IClimate climate)
        {
            switch (id)
            {
                case 0:
                    return new Faults();
                case 1:
                    return new Forest();
                case 2:
                    return new Forest();
                case 3:
                    return new Ridges();
                case 4:
                    return new Ridges();
                case 5:
                    return new Rivers();
                case 6:
                    return new Karst();
                case 7:
                    return new Fumaroles();
                case 8:
                    return new Shrubland();
                case 9:
                default:
                    return new Shrubland();
            }
        }

        public static IFeatures PopulateHighlands(int id, IClimate climate)
        {
            // now we need to exlude features. For example, if the climate is a Savanna then we shouldn't have forests
            int featureId = 0;
            switch (climate.GetType().Name.ToLower())
            {
                case "grassland":
                    featureId = (id < 3) ? _Random.Next(3, 10) : id;
                    break;
                case "chaparral":
                    featureId = (id < 3) ? _Random.Next(3, 10) : id;
                    break;
                case "desert":
                    featureId = (id < 3) ? _Random.Next(3, 10) : id;
                    break;
                case "savanna":
                    featureId = (id < 3) ? _Random.Next(3, 10) : id;
                    break;
                case "steppe":
                    featureId = (id < 3) ? _Random.Next(3, 10) : id;
                    break;
                case "tundra":
                    featureId = (id < 3) ? _Random.Next(3, 10) : id;
                    break;
            }

            switch (id)
            {
                case 0:
                    return new Forest();
                case 1:
                    return new Forest();
                case 2:
                    return new Forest(); // skip these if climate is of type...
                case 3:
                    return new Caves();
                case 4:
                    return new Faults();
                case 5:
                    return new Ridges();
                case 6:
                    return new Ridges();
                case 7:
                    return new Talus();
                case 8:
                    return new Rivers();
                case 9:
                default:
                    return new Shrubland();
            }
        }

        public static List<IFeatures> GetClimateFeatures(IClimate climate)
        {
            switch (climate.GetType().Name.ToLower())
            {
                case "alpine":
                    return AlpineFeatures();
                case "chaparral":
                    return ChaparralFeatures();
                case "deciduousforest":
                    return DeciduousForestFeatures();
                case "desert":
                    return DesertFeatures();
                case "grassland":
                    return GrasslandFeatures();
                case "rainforest":
                    return RainforestFeatures();
                case "savanna":
                    return SavannaFeatures();
                case "steppe":
                    return SteppeFeatures();
                case "taiga":
                    return TaigaFeatures();
                case "tundra":
                default:
                    return TundraFeatures();
            }
        }

        private static List<IFeatures> AlpineFeatures()
        {
            return new List<IFeatures> { new Caves(), new Craters(), new Faults(), new Forest(), new Fumaroles(), new Ridges(), new Rivers(), new Talus() };
        }

        private static List<IFeatures> ChaparralFeatures()
        {
            return new List<IFeatures> { new Craters(), new Faults(), new Fumaroles(), new Ridges(), new Rivers(), new Shrubland() };
        }

        private static List<IFeatures> DeciduousForestFeatures()
        {
            return new List<IFeatures> { new Craters(), new Faults(), new Forest(), new Karst(), new Ridges(), new Rivers(), new Talus() };
        }

        private static List<IFeatures> DesertFeatures()
        {
            return new List<IFeatures> { new Craters(), new Dunes(), new Faults(), new Ridges() };
        }

        private static List<IFeatures> GrasslandFeatures()
        {
            return new List<IFeatures> { new Bog(), new Craters(), new Faults(), new Fumaroles(), new Ridges(), new Rivers(), new Shrubland() };
        }

        private static List<IFeatures> RainforestFeatures()
        {
            return new List<IFeatures> { new Caves(), new Craters(), new Faults(), new Forest(), new Fumaroles(), new Rivers() };
        }

        private static List<IFeatures> SavannaFeatures()
        {
            return new List<IFeatures> { new Ridges(), new Rivers(), new Shrubland() };
        }

        private static List<IFeatures> SteppeFeatures()
        {
            return new List<IFeatures> { new Caves(), new Bog(), new Craters(), new Faults(), new Dunes(), new Ridges(), new Rivers(), new Shrubland() };
        }

        private static List<IFeatures> TaigaFeatures()
        {
            return new List<IFeatures> { new Craters(), new Faults(), new Fumaroles(), new Ridges(), new Shrubland(), new Karst() };
        }

        private static List<IFeatures> TundraFeatures()
        {
            return new List<IFeatures> { new Caves(), new Craters(), new Dunes(), new Faults(), new Karst(), new Ridges(), new Talus() };
        }
    }
}
