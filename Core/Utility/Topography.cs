using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    internal static class Topography
    {
        private static Random _Random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Using the list of AvailableFeatures a list of features is built for the final object
        /// </summary>
        /// <returns>Returns a list of features</returns>
        internal static List<IFeatures> PopulateFeatures(CoreEnums.RegionSize size, List<IFeatures> AvailableFeatures)
        {
            List<IFeatures> Features = new List<IFeatures>(); // do I need to initialize this?..
            int numberOfFeatures = DetermineNumberOfFeatures(size);
            while (true)
            {
                // ERROR: 'System.ArgumentOutOfRangeException' 
                AvailableFeatures.RemoveAt(_Random.Next(0, AvailableFeatures.Count - 1));
                if (numberOfFeatures == AvailableFeatures.Count) break;
            }
            return AvailableFeatures;
        }

        /// <summary>
        /// This determines the number of features to be available by the size of the region
        /// </summary>
        /// <param name="size">Accepts the size of the region</param>
        /// <returns>Returns an integer representing the total number of allowable features</returns>
        private static int DetermineNumberOfFeatures(CoreEnums.RegionSize size)
        {
            switch ((int)size)
            {
                case 1400000: // VerySmall
                    return _Random.Next(3, 6);
                case 3200000: // Small
                    return _Random.Next(4, 7);
                case 4000000: // Moderate
                    return _Random.Next(5, 8);
                case 5300000: // Large
                    return _Random.Next(6, 9);
                default:      // VeryLarge
                    return _Random.Next(7, 10);
            }
        }
    }
}
