using System;
using Core.Races; // I think this will only be temporary
using System.Linq;
using Core.Utility;
using Core.Observer;
using Core.Languages; // this will only be temporary
using Core.Interfaces;
using System.Collections.Generic;

namespace Generate
{
    public class RaceGen
    {
        private Random Random { get; set; }
        private NameGen Names { get; set; }
        private ILanguage CommonTongue { get; set; }
        private List<IMythology> Mythologies { get; set; }

        public RaceGen(List<IMythology> mythologies, ILanguage commonTongue)
        {
            CommonTongue = commonTongue;
            Mythologies = mythologies;
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
        }

        // can they share mythologies? as it stands they can right now
        public IRace GenerateSingle()
        {
            switch (Random.Next(0, 3))
            {
                case 0:
                    return GenerateHumans();
                case 1:
                    return GenerateElves();
                default:
                    return GenerateDwarves();
            }
        }

        public List<IRace> GenerateMultiple(int maxRaces)
        {
            List<string> availableRaces = new List<string>
            {
                new Humans().GetType().Name.ToLower(),
                new Elves().GetType().Name.ToLower(),
                new Dwarves().GetType().Name.ToLower()
            };
            if (maxRaces < availableRaces.Count) maxRaces = availableRaces.Count;

            List<IRace> finalRaces = new List<IRace>();
            List<string> finalRaceNames = new List<string>();
            while (true)
            {
                switch (availableRaces[Random.Next(0, availableRaces.Count)])
                {
                    case "humans":
                        finalRaces.Add(GenerateHumans());
                        finalRaceNames.Add("humans");
                        break;
                    case "elves":
                        finalRaces.Add(GenerateElves());
                        finalRaceNames.Add("elves");
                        break;
                    default:
                        finalRaces.Add(GenerateDwarves());
                        finalRaceNames.Add("dwarves");
                        break;
                }

                // I want to make sure all races are represented before continuing
                // this isn't perfect as one race will wind up with only one representation

                bool test = false;
                if (finalRaceNames.Count >= 3)
                {
                    test = availableRaces.All(r => finalRaceNames.Contains(r));
                    if (test) break;
                }
            }

            return finalRaces;
        }

        private IRace GenerateHumans()
        {
            IRace humans = new Humans()
            {
                Id = 0,
                Name = "Humans",
                Description = "A sturdy, all around stock.",
                NativeTongue = new Language { Id = 0, Name = Names.SingleName(Core.Enums.CoreEnums.Word.ElfPlace), Description = "A common tongue among the tongues." },
                CommonTongue = CommonTongue,
                Mythos = (Mythologies.Count == 1) ? Mythologies.First() : Mythologies.ElementAt(Random.Next(0, Mythologies.Count - 1))
            };
            return humans;
        }

        private IRace GenerateElves()
        {
            IRace elves = new Elves()
            {
                Id = 0,
                Name = "Elves",
                Description = "The learned of the realm.",
                NativeTongue = new Language { Id = 0, Name = "High " + Names.SingleName(Core.Enums.CoreEnums.Word.ElfPlace), Description = "Seldom encountered, this language sings to those that hear it." },
                CommonTongue = CommonTongue,
                Mythos = (Mythologies.Count == 1) ? Mythologies.First() : Mythologies.ElementAt(Random.Next(0, Mythologies.Count - 1))
            };
            return elves;
        }

        private IRace GenerateDwarves()
        {
            IRace dwarves = new Dwarves()
            {
                Id = 0,
                Name = "Dwarves",
                Description = "A stubborn, well-meaning, and ill-tempered sort.",
                NativeTongue = new Language { Id = 0, Name = Names.SingleName(Core.Enums.CoreEnums.Word.DwarfPlace) + " the bitter Tongue", Description = "A language not often spoken above ground." },
                CommonTongue = CommonTongue,
                Mythos = (Mythologies.Count == 1) ? Mythologies.First() : Mythologies.ElementAt(Random.Next(0, Mythologies.Count - 1))
            };
            return dwarves;
        }
    }
}
