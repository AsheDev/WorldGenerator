using System;
using Core.Climates;
using Core.Interfaces;

namespace Core.Factories
{
    public static class ClimateFactory
    {
        private static Random _Random = new Random(Guid.NewGuid().GetHashCode());

        // TODO: this would likely benefit from a binary tree search
        public static IClimate Get(int upperLat, int lowerLat)
        {
            int throwOfTheDice = 0;
            // ERROR: upper was LOWER than lower :/
            if (upperLat < lowerLat)
            {
                Console.WriteLine("CHECK THIS SHIT OUT.");
                Console.ReadLine();
            }

            int latitude = _Random.Next(lowerLat, upperLat + 1);

            #region above 50
            if (latitude > 50)
            {
                if (latitude > 70)
                {
                    throwOfTheDice = _Random.Next(0, 3);
                    switch (throwOfTheDice)
                    {
                        case 0:
                            return new Tundra();
                        case 1:
                            return new Taiga();
                        default:
                            return new Grassland();
                    }
                }

                throwOfTheDice = _Random.Next(0, 4);
                switch (throwOfTheDice)
                {
                    case 0:
                        return new Alpine();
                    case 1:
                        return new Taiga();
                    case 2:
                        return new Tundra();
                    default:
                        return new Grassland();
                }
            }
            #endregion

            if (latitude >= 40 && latitude < 50)
            {
                throwOfTheDice = _Random.Next(0, 3);
                switch (throwOfTheDice)
                {
                    case 0: 
                        return new Chaparral();
                    case 1:
                        return new Steppe();
                    default:
                        return new Grassland();
                }
            }
            if (latitude >= 35 && latitude < 40)
            {
                throwOfTheDice = _Random.Next(0, 2);
                switch (throwOfTheDice)
                {
                    case 0:
                        return new Chaparral();
                    default:
                        return new Grassland();
                }
            }
            if (latitude >= 20 && latitude < 35)
            {
                throwOfTheDice = _Random.Next(0, 4);
                switch (throwOfTheDice)
                {
                    case 0:
                        return new Desert();
                    case 1:
                        return new DeciduousForest();
                    case 2:
                        return new Savanna();
                    default:
                        return new Grassland();
                }
            }
            if (latitude >= 0 && latitude < 20)
            {
                throwOfTheDice = _Random.Next(0, 5);
                switch (throwOfTheDice)
                {
                    case 0:
                        return new Desert();
                    case 1:
                        return new DeciduousForest();
                    case 2:
                        return new Rainforest();
                    case 3:
                        return new Savanna();
                    default:
                        return new Steppe();
                }
            }
            if (latitude >= -24 && latitude < 0)
            {
                throwOfTheDice = _Random.Next(0, 4);
                switch (throwOfTheDice)
                {
                    case 0:
                        return new Desert();
                    case 1:
                        return new Rainforest();
                    case 2:
                        return new DeciduousForest();
                    default:
                        return new Steppe();
                }
            }
            if (latitude >= -31 && latitude < -24)
            {
                throwOfTheDice = _Random.Next(0, 5);
                switch (throwOfTheDice)
                {
                    case 0:
                        return new Desert();
                    case 1:
                        return new DeciduousForest();
                    case 2:
                        return new Rainforest();
                    case 3:
                        return new Steppe();
                    default:
                        return new Grassland();
                }
            }
            if (latitude >= -38 && latitude < -31)
            {
                throwOfTheDice = _Random.Next(0, 3);
                switch (throwOfTheDice)
                {
                    case 0:
                        return new Desert();
                    case 1:
                        return new DeciduousForest();
                    default:
                        return new Grassland();
                }
            }
            if (latitude >= -60 && latitude < -38)
            {
                throwOfTheDice = _Random.Next(0, 2);
                switch (throwOfTheDice)
                {
                    case 0:
                        return new Desert();
                    default:
                        return new Grassland();
                }
            }
            else
            {
                return new Grassland();
            }
                       
            //if (latitude >= 35 && latitude <= 40) return new Chaparral();
            //if (latitude >= -60 && latitude <= 30) return new Desert();
            //if (latitude >= -38 && latitude <= 23) return new DeciduousForest();
            //if (latitude >= 24 || latitude <= -24) return new Grassland(); // PAY CLOSE ATTENTION TO THIS ONE
            //if (latitude >= -25 && latitude <= 15) return new Rainforest();
            //if (latitude >= 8 && latitude <= 20) return new Savanna();
            //if (latitude >= -31 && latitude <= 50) return new Steppe();
        }
    }
}
