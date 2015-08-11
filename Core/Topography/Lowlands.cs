using System;
using Core.Enums;
using Core.Features;
using Core.Factories;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Topography
{
    public class Lowlands : ITopography
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<IFeatures> Features { get; set; }
        public List<ITopography> CorrespondingTopography { get; set; }

        private Random _Random = new Random(Guid.NewGuid().GetHashCode());
        private List<IFeatures> AvailableFeatures { get; set; }

        public Lowlands()
        {
            // EMPTY
        }

        /// <summary>
        /// Primary constructor for generating a topography with appropriate settings
        /// </summary>
        /// <param name="size">Accepts the size of the region the topography belongs to</param>
        public Lowlands(CoreEnums.RegionSize size, IClimate climate)
        {
            AvailableFeatures = PopulateAvailableFeatures();
            Features = PopulateFinalFeatures(climate);
            CorrespondingTopography = PopulateCorrespondingTopography();
        }

        /// <summary>
        /// Populates the available features for this topography type.
        /// </summary>
        /// <param name="climate">Accepts a climate type</param>
        /// <returns>Returns a List of Features contained within this topography</returns>
        private List<IFeatures> PopulateFinalFeatures(IClimate climate)
        {
            List<IFeatures> availableClimateFeatures = FeaturesFactory.GetClimateFeatures(climate);
            List<IFeatures> features = new List<IFeatures>();
            bool excludeFeatures = false;
            for (int n = 0; n < 10; n++)
            {
                IFeatures feature = FeaturesFactory.PopulateLowlands(_Random.Next(0, availableClimateFeatures.Count - 1), climate);
                feature.Id = n;
                feature.Name = "NAME"; // tie the name generator to this
                feature.Description = "DESCRIPTION";
                AvailableFeatures.Add(feature);

                // if a dune or forest feature has not been excluded yet we need to continually check
                if (!excludeFeatures)
                {
                    if (feature.GetType().Name == "Dunes")
                    {
                        availableClimateFeatures.RemoveAll(c => c.GetType().Name == "Forest");
                        excludeFeatures = true;
                        continue;
                    }
                    if (feature.GetType().Name == "Forest")
                    {
                        availableClimateFeatures.RemoveAll(c => c.GetType().Name == "Dunes");
                        excludeFeatures = true;
                        continue;
                    }
                }
            }
            return features;
        }

        /// <summary>
        /// Populates the available matching topography for this particular type
        /// </summary>
        /// <returns>Returns a List of suitable, related topography</returns>
        private List<ITopography> PopulateCorrespondingTopography()
        {
            return new List<ITopography> { new Hills(), new Highlands(), new Plains(), new Lowlands() };
        }

        /// <summary>
        /// Populates the available features that are allowed within the Highlands topography. 
        /// This will be considered along with Climate, at a later time, to construct the region properly.
        /// </summary>
        /// <returns>Returns a List of available features</returns>
        private List<IFeatures> PopulateAvailableFeatures()
        {
            return new List<IFeatures> { new Forest(), new Bog(), new Craters(), new Rivers(), new Shrubland(), new Dunes() };
        }
    }
}