using Core.Races;
using Core.Observer;
using Core.Interfaces;

namespace Core.Factories
{
    public static class RaceFactory
    {
        public static IRace Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new Dwarves();
                case 1:
                    return new Humans();
                case 2:
                default:
                    return new Elves();
            }
        }
    }
}
