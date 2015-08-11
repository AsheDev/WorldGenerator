using System;
using Core.Enums;
using System.Linq;
using Core.Helpers;
using Core.Persons;
using Core.Interfaces;
using System.Collections.Generic;

namespace Generate
{
    public class PersonGen
    {
        private Random Random { get; set; }
        private NameGen Names { get; set; }
        private List<string> PositiveTraits { get; set; }
        private List<string> NegativeTraits { get; set; }

        public PersonGen()
        {
            GeneralWordGen wordGen = new GeneralWordGen();
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
            PositiveTraits = wordGen.GetPositiveTraits();
            NegativeTraits = wordGen.GetNegativeTraits();
        }

        public IPerson GenerateSingle(PersonHelper personInfo)
        {
            IPerson person = new Person();
            person.Id = Random.Next(0, 780000000);
            person.Gender = DetermineGender();
            person.Name = GetName(personInfo.Race, person.Gender);
            person.Description = "DESCRIPTION";
            person.Race = personInfo.Race;
            person.Civilization = personInfo.Civilization;
            person.OriginatesFrom = personInfo.OriginatesFrom;
            person.Mythology = personInfo.Mythology;
            person.PersonalDeity = personInfo.Mythology.Deities[Random.Next(0, personInfo.Mythology.Deities.Count - 1)]; // make a method?
            person.Father = personInfo.Father; // might be null
            person.Mother = personInfo.Mother; // might be null
            person.Partner = null;
            person.Age = personInfo.Race.SexualMaturity - 1;
            person.Traits = (personInfo.Father == null || personInfo.Mother == null) ? DetermineTraits() : DetermineTraits(personInfo.Father, personInfo.Mother);
            person.SocialStatus = DetermineSocialStatus();
            person.Alive = true;
            return person;
        }

        public List<IPerson> GenerateMultiple(ICivilization civilization, int popCount, PersonHelper personalInfo)
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
                personHelper.OriginatesFrom = popCenter; // WHAT HAPPENS WHEN WE RUN OUT OF CITIES!? WE EXPAND! RAWR!!!
                personHelper.Father = new Person();
                personHelper.Mother = new Person();
                personHelper.Partner = new Person();

                IPerson person = GenerateSingle(personHelper);
                population.Add(person);
                popCenter.Population.Add(person);

                if (n < 9) person.SocialStatus = CoreEnums.Status.Highborne;
                Console.WriteLine("Name: " + population.Last().Name + "; Race: " + population.Last().Race.Name);
            }
            return population;
        }

        /// <summary>
        /// Basic True/False generator for determining gender
        /// </summary>
        /// <returns>Returns a Gender</returns>
        private CoreEnums.Gender DetermineGender()
        {
            return (Random.Next(0, 2) == 0) ? CoreEnums.Gender.Male : CoreEnums.Gender.Female;
        }

        // this should probably be overloaded to take in mother/father traits
        private List<ITraits> DetermineTraits()
        {
            List<ITraits> traits = new List<ITraits>();
            List<string> usedPositiveTraits = new List<string>();
            List<string> usedNegativeTraits = new List<string>();

            int max = Random.Next(15, 29);
            for (int n = 0; n <= max; n++)
            {
                ITraits trait = new Traits
                {
                    Id = Random.Next(0, 780000000),
                    Description = "DESCRIPTION"
                };
                trait.Healthy = Convert.ToBoolean(Random.Next(0, 2));

                if (trait.Healthy)
                {
                    trait.Name = PositiveTraits[Random.Next(0, PositiveTraits.Count - 1)];
                    PositiveTraits.Remove(trait.Name);
                    usedPositiveTraits.Add(trait.Name);
                }
                else
                {
                    trait.Name = NegativeTraits[Random.Next(0, NegativeTraits.Count - 1)];
                    NegativeTraits.Remove(trait.Name);
                    usedNegativeTraits.Add(trait.Name);
                }
                traits.Add(trait);
            }
            if (usedPositiveTraits.Count > 0) PositiveTraits.AddRange(usedPositiveTraits);
            if (usedNegativeTraits.Count > 0) NegativeTraits.AddRange(usedNegativeTraits);
            return traits;
        }

        // TODO!
        private List<ITraits> DetermineTraits(IPerson father, IPerson mother)
        {
            return new List<ITraits>();
        }

        private int DetermineAge(IRace race)
        {
            switch(race.GetType().Name.ToLower())
            {
                case "humans":
                    break;
                case "dwarves":
                    break;
                default:
                    break;
            }
            return 0;
        }

        private string GetName(IRace race, CoreEnums.Gender gender)
        {
            switch (race.GetType().Name.ToLower())
            {
                case "elves":
                    return DiceRollForNames((gender == CoreEnums.Gender.Female) ? CoreEnums.Word.ElfFemale : CoreEnums.Word.ElfMale);
                case "dwarves":
                    return DiceRollForNames((gender == CoreEnums.Gender.Female) ? CoreEnums.Word.DwarfFemale : CoreEnums.Word.DwarfMale);
                case "human":
                default:
                    return DiceRollForNames((gender == CoreEnums.Gender.Female) ? CoreEnums.Word.HumanFemale : CoreEnums.Word.HumanMale);
            }
        }

        // keep surnames???
        private string DiceRollForNames(CoreEnums.Word race)
        {
            int value = Random.Next(0, 10);
            if (value >= 0 && value <= 3) // 4
            {
                return Names.SingleName(race);
            }
            else if (value > 3 && value <= 6) // 3 chances
            {
                return Names.SingleNameWithAdjective(race); // maybe adjectives should only be given with achievements
            }
            else if (value > 6 && value <= 8) // 2 chances
            {
                return Names.FirstAndLastName(race, race);
            }
            else // 1 chance
            {
                return Names.FirstAndLastNameWithAdjective(race, race); // maybe adjectives should only be given with achievements
            }
        }

        // if their parents are of a particular status they should automatically inherit that
        private CoreEnums.Status DetermineSocialStatus()
        {
            return ((Random.Next(0, 12)) == 7) ? CoreEnums.Status.Highborne : CoreEnums.Status.Lowborne;
        }

        // TODO
        private string InitialDescriptionGen(IPerson person)
        {
            string one = "Born into a ";
            switch (Convert.ToInt32(person.SocialStatus))
            {
                case 0:
                    one = "noble house, ";
                    break;
                default:
                    one = "commoner's life, ";
                    break;
            }
            
            // TODO: select a random feature of the region to include in the bio
            string two = one + person.Name + " grew up in " + person.OriginatesFrom.Region.Name + " hailing specifically from the " +
                person.OriginatesFrom.GetType().Name + " of " + person.OriginatesFrom.Name + ".";


            return two;
            // Born of a noble house in REGION NAME, NAME hails from CITY
        }
    }
}
