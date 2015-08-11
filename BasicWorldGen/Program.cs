using System;
using Generate;
using Core.Enums;
using System.Linq;
using Core.Worlds; // testing for now
using Core.Languages;
using Core.Mythology;
using Core.Interfaces;
using System.Collections.Generic;
using Core.Climates;
using Core.Helpers;
using Core.PopulationCenters;
using System.Threading.Tasks;
using System.Threading;
using Core.Persons;
using DatabaseConnection; // testing

namespace BasicWorldGen
{
    class Program
    {
        private static Random _Random = new Random(Guid.NewGuid().GetHashCode());

        static void Main(string[] args)
        {
            //NameGen names = new NameGen();

            //// would it help with memory if I saved every 250, then read them back into a hashset, and started all over again?

            //int count = 0;
            //HashSet<string> namesTest = new HashSet<string>();
            //string currentName;
            //while (true)
            //{
            //    count++;
            //    currentName = names.SingleName(CoreEnums.Word.ElfMale);
            //    namesTest.Add(currentName);
            //    Console.Write(namesTest.Count + "; " + currentName + "\n");
            //}

            //Database worldGen = new Database(System.Configuration.ConfigurationManager.AppSettings["Testing"]);
            Database worldGen = new Database("WorldGen");
            new PopulateDatabaseNames(worldGen).AddAdjectives();
            Console.ReadLine();




            CalendarGen calendar = new CalendarGen();
            IYear calendarYear = calendar.Generate();



            // Generate the mythology
            MythosGen mythos = new MythosGen();
            List<IMythology> mythologies = new List<IMythology>();
            if ((_Random.Next(0, 2) == 1))
            {
                mythologies.AddRange(mythos.GenerateMultiple());
            }
            else
            {
                mythologies.Add(mythos.GenerateSingle());
            }
            
            // Generate the world
            WorldGen worlds = new WorldGen();
            IWorld world = worlds.Generate(mythologies);
            
            // Generate the common language
            LanguageGen languages = new LanguageGen();
            ILanguage commonTongue = languages.Generate();
            
            // Generate the races
            RaceGen raceGen = new RaceGen(mythologies, commonTongue);
            List<IRace> races = raceGen.GenerateMultiple(_Random.Next(3, 8));
            
            // Generate the civilizations present
            CivilizationGen civGen = new CivilizationGen();
            List<ICivilization> civilizations = civGen.GenerateMultiple(races);

            // Generate the continents
            ContinentGen continentGen = new ContinentGen(world);
            List<IContinent> continents = continentGen.Generate(_Random.Next(2, 5));

            // TODO: I don't think the Climate/Features is totally working
            // TODO: military structures (castles, outposts, etc...), 1-3-5 per region, determine control of the region (must be an odd number)
            // Generate the regions within the continents
            RegionGen regionGen = new RegionGen();
            List<IRegion> availableRegions = new List<IRegion>(); // this is for a starting region of a civilization
            foreach (IContinent continent in continents)
            {
                continent.ListOfRegions = regionGen.Generate(continent, civilizations);
                availableRegions.AddRange(continent.ListOfRegions);
            }

            // now assign a starting region and hamlet to each civilization
            PopulationCenterGen popGen = new PopulationCenterGen();
            foreach (ICivilization civilization in civilizations)
            {
                int index = _Random.Next(0, availableRegions.Count - 1);
                IRegion region = availableRegions.ElementAt(index);
                civilization.RegionsOwned.Add(availableRegions[index]);
                availableRegions.RemoveAt(index);
                civilization.PopulationCenters.Add(popGen.GenerateSingle(civilization));
            }

            // How will populations spread? When the settlement reaches a certain population, a certain "level"? 
            // Once they fill a region they'll move into adjacent regions, begin clashing with others
            
            // I need to define both TotalPopulation as well as individual civilization's populations

            // All of this will create a population for each civilization
            // TODO: is this implemented..? Each person needs to be added to the hamlet in the region established in the previous foreach
            // http://www.codeproject.com/Articles/189374/The-Basics-of-Task-Parallelism-via-C
            CancellationTokenSource cts = new CancellationTokenSource(); // do I really need this?
            //List<IPerson> totalPopulation = new List<IPerson>();
            PersonGen populace = new PersonGen();

            //int populationCount = 0;
            //switch (civilizations.First().Race.GetType().Name.ToLower())
            //{
            //    case "humans":
            //        //populationCount = _Random.Next(650, 720);
            //        populationCount = 25;
            //        break;
            //    case "dwarves":
            //        //populationCount = _Random.Next(820, 900);
            //        populationCount = 25;
            //        break;
            //    default:
            //        //populationCount = _Random.Next(1100, 1400);
            //        populationCount = 25;
            //        break;
            //}

            //PersonHelper personInfo = new PersonHelper();
            //personInfo.Civilization = civilizations.First();
            //personInfo.Race = civilizations.First().Race;
            //personInfo.Mythology = civilizations.First().Race.Mythos;

            //// maybe we should check the population levels before starting the next loop? First thing in the for loop?
            //IPopulationCenters popCenter = civilizations.First().PopulationCenters.First(pc => pc.Population.Count < pc.MaxPopulation);
            //personInfo.OriginatesFrom = popCenter; // WHAT HAPPENS WHEN WE RUN OUT OF CITIES!?
            //personInfo.Father = new Person();
            //personInfo.Mother = new Person();
            //personInfo.Partner = new Person();

            //// TODO: the name generator is not threadsafe I do not think. Need to start storing names in a DB
            ////int index = civilizations.FindIndex(c => c.Id == civilizations.First().Id);
            //Task<List<IPerson>> populationTask = new Task<List<IPerson>>(() => populace.GenerateMultiple(civilizations.First(), populationCount, personInfo), cts.Token);
            //populationTask.Start();

            //populationTask.Wait();

            #region
            //civilization.TotalPopulation = populationTask.Result;
            //totalPopulation.AddRange(populationTask.Result);

            // I DON'T THINK THIS IS THREAD SAFE
            // would it be better to create a list of tasks and then execute them?
            int totalPopulation = 0;
            List<Task> tasks = new List<Task>();
            foreach (ICivilization civilization in civilizations)
            {
                int populationCount = 0;
                switch (civilization.Race.GetType().Name.ToLower())
                {
                    case "humans":
                        //populationCount = _Random.Next(650, 720);
                        populationCount = 25;
                        break;
                    case "dwarves":
                        //populationCount = _Random.Next(820, 900);
                        populationCount = 25;
                        break;
                    default:
                        //populationCount = _Random.Next(1100, 1400);
                        populationCount = 25;
                        break;
                }

                PersonHelper personInfo = new PersonHelper();
                personInfo.Civilization = civilization;
                personInfo.Race = civilization.Race;
                personInfo.Mythology = civilization.Race.Mythos;

                // maybe we should check the population levels before starting the next loop? First thing in the for loop?
                IPopulationCenters popCenter = civilization.PopulationCenters.First(pc => pc.Population.Count < pc.MaxPopulation);
                personInfo.OriginatesFrom = popCenter; // WHAT HAPPENS WHEN WE RUN OUT OF CITIES!?
                personInfo.Father = new Person();
                personInfo.Mother = new Person();
                personInfo.Partner = new Person();

                // TODO: the name generator is not threadsafe I do not think. Need to start storing names in a DB
                int index = civilizations.FindIndex(c => c.Id == civilization.Id);
                
                Task<List<IPerson>> populationTask = new Task<List<IPerson>>(() => populace.GenerateMultiple(civilization, populationCount, personInfo), cts.Token);
                //tasks.Add(populationTask);
                populationTask.Start();
                //civilization.TotalPopulation = populationTask.Result;
                //totalPopulation.AddRange(populationTask.Result);
                //populationTask.Wait();
                totalPopulation += populationCount;
            }

            //foreach (Task task in tasks)
            //{
            //    task.Start();                
            //}


            Task.WaitAll();            

            cts.Cancel();
            #endregion

            Console.WriteLine("Total Civilizations: " + civilizations.Count);
            Console.WriteLine("Total Population: " + totalPopulation);
            Console.ReadLine();
        }

        private static List<IPerson> GeneratePopulation(int id, ICivilization civilization, int popCount)
        {
            List<IPerson> population = new List<IPerson>();
            for (int n = 0; n < popCount; n++)
            {
                //Thread.Sleep(_Random.Next(200, 700));
                PersonHelper personHelper = new PersonHelper();
                personHelper.Civilization = civilization;
                personHelper.Race = civilization.Race;
                personHelper.Mythology = civilization.Race.Mythos;

                // maybe we should check the population levels before starting the next loop? First thing in the for loop?
                IPopulationCenters popCenter = civilization.PopulationCenters.First(pc => pc.Population.Count < pc.MaxPopulation);
                personHelper.OriginatesFrom = popCenter; // WHAT HAPPENS WHEN WE RUN OUT OF CITIES!?
                personHelper.Father = new Person();
                personHelper.Mother = new Person();
                personHelper.Partner = new Person();

                PersonGen personGen = new PersonGen();

                IPerson person = personGen.GenerateSingle(personHelper);
                population.Add(person);
                popCenter.Population.Add(person);

                if (n < 9) person.SocialStatus = CoreEnums.Status.Highborne;
                WriteToConsole("ID: " + id + "Name: " + population.Last().Name + "; Race: " + population.Last().Race.Name);
            }
            return population;
        }

        private static void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }    
}
