using System;
using Core.Enums;
using System.Linq;
using System.Text;
using Core.Regions;
using Core.Interfaces;
using Core.Continents;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Generate
{
    public class ContinentGen
    {
        private List<string> _ContinentNames { get; set; }
        private IWorld World { get; set; }
        private Random Random { get; set; }
        private NameGen Names { get; set; }

        public ContinentGen(IWorld world)
        {
            World = world;
            PopulateContinentName();
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfContinents"></param>
        /// <returns></returns>
        public List<IContinent> Generate(int numberOfContinents)
        {
            // TODO: have a thread generate eacah continent and its regions?
            List<IContinent> listOfContinents = new List<IContinent>();
            for (int n = 0; n < numberOfContinents; n++)
            {
                IContinent continent = new Continent();
                continent.Id = n;
                continent.Name = SelectRandomContinentName();
                continent.World = World;
                continent.Size = SelectRandomSize();
                continent.AreaKilometersSquare = CalculateContinentSizeKM(continent.Size);
                continent.ListOfRegions = new List<IRegion>(); // this is populated later
                continent.AdjoiningContinents = new Dictionary<CoreEnums.CardinalDirections, IContinent>();
                continent.UpperLatitude = CalculateLatitude(0);
                continent.Lowerlatitude = CalculateLatitude(continent.UpperLatitude);
                listOfContinents.Add(continent);                
            }

            // should I move all this to a separate method?
            listOfContinents = GenerateConnections(listOfContinents);
            listOfContinents = ConnectContinents(listOfContinents, listOfContinents.ElementAt(0));
            listOfContinents = RemoveEmptyConnections(listOfContinents);

            return listOfContinents;
        }

        // TODO: I need to get rid of this...
        private void PopulateContinentName()
        {
            _ContinentNames = new List<string>{
                "Harrofeld",
                "Carinor",
                "Leparoket",
                "Yapsilen",
                "Dreu'ke",
                "Reteeuki",
                "Wethertop",
                "Loposil",
                "Karina"
            };
        }

        private string SelectRandomContinentName()
        {
            if (Random.Next(0, 27) < 17)
            {
                return Names.SingleName(CoreEnums.Word.HumanPlace);
            } else {
                return Names.SingleName(CoreEnums.Word.ElfPlace);
            }
        }

        private CoreEnums.ContinentSize SelectRandomSize()
        {
            switch (Random.Next(0, 5))
            {
                case 0:
                    return CoreEnums.ContinentSize.VerySmall;
                case 1:
                    return CoreEnums.ContinentSize.Small;
                case 2:
                    return CoreEnums.ContinentSize.Moderate;
                case 3:
                    return CoreEnums.ContinentSize.Large;
                default:
                    return CoreEnums.ContinentSize.VeryLarge;
            }
        }

        private int CalculateContinentSizeKM(CoreEnums.ContinentSize size)
        {
            int plusOrMinus = Convert.ToInt32(((double)CoreEnums.ContinentSize.VerySmall * (double).27));
            switch ((int)size)
            {
                case 7000000:  // VerySmall
                    return Random.Next((int)CoreEnums.ContinentSize.VerySmall - plusOrMinus, (int)CoreEnums.ContinentSize.VerySmall + plusOrMinus);
                case 12000000: // Small
                    return Random.Next((int)CoreEnums.ContinentSize.Small - plusOrMinus, (int)CoreEnums.ContinentSize.Small + plusOrMinus);
                case 21000000: // Moderate
                    return Random.Next((int)CoreEnums.ContinentSize.Moderate - plusOrMinus, (int)CoreEnums.ContinentSize.Moderate + plusOrMinus);
                case 37000000: // Large
                    return Random.Next((int)CoreEnums.ContinentSize.Large - plusOrMinus, (int)CoreEnums.ContinentSize.Large + plusOrMinus);
                default:       // VeryLarge
                    return Random.Next((int)CoreEnums.ContinentSize.VeryLarge - plusOrMinus, (int)CoreEnums.ContinentSize.VeryLarge + plusOrMinus);
            }
        }

        /// <summary>
        /// Add N, E, S, and W connextions to each continent
        /// </summary>
        /// <param name="continents"></param>
        /// <returns></returns>
        private List<IContinent> GenerateConnections(List<IContinent> continents)
        {
            //Dictionary<CoreEnums.CardinalDirections, IContinent> availableConnections = new Dictionary<CoreEnums.CardinalDirections, IContinent>();
            //List<int> availableDirections; // four cardinal directions

            foreach (IContinent continent in continents)
            {
                continent.AdjoiningContinents.Add(CoreEnums.CardinalDirections.North, new Continent());
                continent.AdjoiningContinents.Add(CoreEnums.CardinalDirections.East, new Continent());
                continent.AdjoiningContinents.Add(CoreEnums.CardinalDirections.South, new Continent());
                continent.AdjoiningContinents.Add(CoreEnums.CardinalDirections.West, new Continent());



                //availableConnections.Clear();
                //availableDirections = new List<int> { 0, 1, 2, 3 }; // north, east, south, and west int representations
                //for (int n = 0; n < 4; n++) // for each connection...
                //{
                //    int direction = availableDirections[Random.Next(0, availableDirections.Count - 1)];
                //    availableConnections.Add((CoreEnums.CardinalDirections)direction, new Continent());
                //    availableDirections.Remove(direction);
                //}
                //continent.AdjoiningContinents = availableConnections;
            }
            return continents;
        }

        private List<IContinent> ConnectContinents(List<IContinent> continents, IContinent startingContinent)
        {
            int numberOfLoops = (continents.Count * 2) / 3;

            for (int n = 0; n < numberOfLoops; n++)
            {
                Dictionary<CoreEnums.CardinalDirections, IContinent> availableConnections = new Dictionary<CoreEnums.CardinalDirections, IContinent>();
                List<int> availableDirections = new List<int> { 0, 1, 2, 3 };
                int direction = Random.Next(0, startingContinent.AdjoiningContinents.Count - 1); // randomly select one of the connections
                if (startingContinent.AdjoiningContinents.Values.ElementAt(direction).Name == null)
                {
                    // no connection was found... let's create one
                    continents = NoConnectionExists(continents, startingContinent, direction);
                }
                else
                {
                    // a connection was found. Dig into that connection and try all over again
                    // this needs to keep digging until it finds a spot to create
                    continents = ConnectionExists(continents, startingContinent.AdjoiningContinents.Values.ElementAt(direction));
                }
            }
            return continents;
        }

        private List<IContinent> ConnectionExists(List<IContinent> continents, IContinent startingContinent)
        {
            Dictionary<CoreEnums.CardinalDirections, IContinent> availableConnections = new Dictionary<CoreEnums.CardinalDirections, IContinent>();
            List<int> availableDirections = new List<int> { 0, 1, 2, 3 };
            int direction = Random.Next(0, startingContinent.AdjoiningContinents.Count - 1); // randomly select one of the connections
            if (startingContinent.AdjoiningContinents.Values.ElementAt(direction).Name == null)
            {
                // no connection was found... let's create one
                continents = NoConnectionExists(continents, startingContinent, direction);
            }
            else
            {
                // a connection was found. Dig into that connection and try all over again
                continents = ConnectContinents(continents, startingContinent.AdjoiningContinents.Values.ElementAt(direction));
            }
            return continents;
        }

        private List<IContinent> RemoveEmptyConnections(List<IContinent> continents)
        {
            foreach(IContinent continent in continents)
            {
                foreach (var item in continent.AdjoiningContinents.Where(d => d.Value.Name == null).ToList())
                {
                    continent.AdjoiningContinents.Remove(item.Key);
                }
            }
            return continents;
        }

        private List<IContinent> NoConnectionExists(List<IContinent> continents, IContinent startingContinent, int direction)
        {
            // select the first continent that's greater than the current one (the ones coming before should have lower Ids)
            // TODO: this has generated a "Sequence contains no elements" exception...
            IContinent continent = continents.Where(c => c.Id > startingContinent.Id).First();
            CoreEnums.CardinalDirections key = (CoreEnums.CardinalDirections)startingContinent.AdjoiningContinents.Keys.ElementAt(direction);
            startingContinent.AdjoiningContinents[key] = continent;

            switch (Convert.ToInt32(key))
            {
                case 0:
                    direction = 2;
                    break;
                case 1:
                    direction = 3;
                    break;
                case 2:
                    direction = 0;
                    break;
                default:
                    direction = 1;
                    break;
            }
            continent.AdjoiningContinents[(CoreEnums.CardinalDirections)direction] = startingContinent;
            return continents;
        }
        
        private Dictionary<CoreEnums.CardinalDirections, IContinent> ConstructConnections(Dictionary<CoreEnums.CardinalDirections, IContinent> availableConnections, List<IContinent> continents, IContinent primaryContinent)
        {
            foreach (IContinent continent in continents)
            {
                if (continents[0].AdjoiningContinents.Count == 0) break; // it's Australia!

                // check if the continent already has a connection to another landmass
                int element = Random.Next(0, continents[0].AdjoiningContinents.Count - 1);
                if (primaryContinent.AdjoiningContinents.Values.ElementAt(element).Name == null)
                {
                    // no connection to another continent exists
                    primaryContinent.AdjoiningContinents[0] = continent;
                }
                else
                {
                    // a connection exists so let's go deeper
                    ConstructConnections(availableConnections, continents, primaryContinent.AdjoiningContinents.Values.ElementAt(element));
                }
            }
            return availableConnections;
        }

        // TODO: this may need to be more robust
        private int CalculateLatitude(int upper)
        {
            if(upper == 0) // there is no upper bound to be wary of
            {
                return Random.Next(-100, 101);
            }
            else
            {
                int lower = 0;
                do
                {
                    lower = Random.Next(-100, upper + 1);
                } while ((Math.Abs(upper - lower) < 5));
                return lower;
            }
        }
    }
}
