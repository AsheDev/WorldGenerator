using Core.Enums;
using Core.Interfaces;
using Core.Topography;

namespace Core.Factories
{
    public static class TopographyFactory
    {
        public static ITopography Get(int id, CoreEnums.RegionSize size, IClimate climate)
        {
            switch (id)
            {
                case 0:
                    return new Highlands(size, climate);
                case 1:
                    return new Hills(size, climate);
                case 2:
                    return new Mountains(size, climate);
                case 3:
                    return new Lowlands(size, climate);
                case 4:
                    return new Plains(size, climate);
                case 5:
                default:
                    return new Valleys(size, climate);
            }
        }
    }
}
