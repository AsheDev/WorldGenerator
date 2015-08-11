using Core.Interfaces;
using Core.PopulationCenters;

namespace Core.Factories
{
    public static class PopulationCenterFactory
    {
        public static IPopulationCenters Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new Hamlet();
                case 1:
                    return new Village();
                case 2:
                    return new CastleTown();
                case 3:
                    return new Burgh();
                case 4:
                    return new Town();
                case 5:
                    return new City();
                case 6:
                default:
                    return new Metropolis();
            }
        }

        /// <summary>
        /// This is really only intended to generate the next "level" of a city
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static IPopulationCenters Get(string typeName)
        {
            switch (typeName.ToLower())
            {
                case "hamlet": // max 2000
                    return new Village();
                case "village": // max 7000
                    return new Burgh();
                case "burgh": // max 11200
                    return new CastleTown();
                case "castletown": // max 15500
                    return new Town();
                case "town": // max 32000
                    return new City();
                case "city": // max 73500
                default:
                    return new Metropolis();
            }
        }
    }
}
