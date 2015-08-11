using System;

namespace Core.Utility
{
    public static class Region
    {
        private static Random _Random = new Random(Guid.NewGuid().GetHashCode());

        public static double GetAverageRainFall(double high, double low)
        {
            return _Random.NextDouble() * (high - low) + low;
        }

        public static double GetAverageTemperature(double high, double low)
        {
            return _Random.NextDouble() * (high - low) + low;
        }
    }
}
