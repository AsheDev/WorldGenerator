using System;
using Core.Enums;
using Core.Factories;
using Core.Languages;
using Core.Interfaces;
using System.Threading;
using Core.Civilizations;
using System.Collections.Generic;

namespace Generate
{
    public class CivilizationGen
    {
        private Random Random { get; set; }
        private NameGen Names { get; set; }

        public CivilizationGen()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
        }

        // overload so we can pass in a race or not?
        public ICivilization GenerateSingle(IRace race)
        {
            // TODO: needs shit like "Kingdom" or "Empire" and whatnot to prepend onto these names
            string civName = "";
            switch (race.GetType().Name.ToLower())
            {
                case "humans":
                    civName = Names.SingleName(CoreEnums.Word.HumanMale);
                    break;
                case "elves":
                    civName = Names.SingleName(CoreEnums.Word.ElfPlace);
                    break;
                case "dwarves":
                default:
                    civName = Names.SingleName(CoreEnums.Word.DwarfFemale);
                    break;
            }

            ICivilization civilization = new Civilization
            {
                Id = Random.Next(0, 676786760), // TODO: this is database related shit
                Name = civName,
                Description = "CIVDESCRIPTION",
                Race = race,
                RegionsOwned = new List<IRegion>(),
                PopulationCenters = new List<IPopulationCenters>(),
                TotalPopulation = new List<IPerson>()
            };
            return civilization;
        }

        // How do I want to factor the amount of races to generate? Making shit up with "numberOfContinents"? I don't know
        public List<ICivilization> GenerateMultiple(List<IRace> racesOfMer)
        {
            List<ICivilization> civilizations = new List<ICivilization>();
            foreach (IRace race in racesOfMer)
            {
                civilizations.Add(GenerateSingle(race));
            }
            return civilizations;
        }

        //public List<IPerson> GeneratePopulation(ICivilization civilization)
        //{
        //    CancellationTokenSource cts = new CancellationTokenSource(); // do I really need this?
        //    PersonGen populace = new PersonGen();

        //    int populationCount = 0;
        //    switch (civilization.Race.GetType().Name.ToLower())
        //    {
        //        case "humans":
        //            populationCount = _Random.Next(650, 720);
        //            break;
        //        case "dwarves":
        //            populationCount = _Random.Next(820, 900);
        //            break;
        //        default:
        //            populationCount = _Random.Next(1100, 1400);
        //            break;
        //    }

        //    PersonHelper personInfo = new PersonHelper();
        //    personInfo.Civilization = civilization;
        //    personInfo.Race = civilization.Race;
        //    personInfo.Mythology = civilization.Race.Mythos;

        //    // maybe we should check the population levels before starting the next loop? First thing in the for loop?
        //    IPopulationCenters popCenter = civilization.PopulationCenters.First(pc => pc.Population.Count < pc.MaxPopulation);
        //    personInfo.OriginatesFrom = popCenter; // WHAT HAPPENS WHEN WE RUN OUT OF CITIES!?
        //    personInfo.Father = new Person();
        //    personInfo.Mother = new Person();
        //    personInfo.Partner = new Person();

        //    // TODO: the name generator is not threadsafe I do not think. Need to start storing names in a DB
        //    int index = civilizations.FindIndex(c => c.Id == civilization.Id);
        //    Task<List<IPerson>> populationTask = new Task<List<IPerson>>(() => populace.GenerateMultiple(civilization, populationCount, personInfo), cts.Token);
        //    populationTask.Start();
        //}
    }
}
