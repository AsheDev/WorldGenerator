using Core.Enums;
using Core.Languages;
using Core.Interfaces;

namespace Generate
{
    public class LanguageGen
    {
        private NameGen Names { get; set; }

        public LanguageGen()
        {
            Names = new NameGen();
        }

        public ILanguage Generate()
        {
            return new Language { Id = 0, Name = Names.SingleName(CoreEnums.Word.ElfPlace) + " the Low Tongue", Description = "A language common to the lesser races of the world." };
        }

        // TODO: have this spit out different varied names for different races
        // TODO: I could use adjective here to go along with the name...
        public ILanguage Generate(IRace race)
        {
            if(race.GetType().Name.ToLower() == "elves")
            {
                return new Language { Id = 0, Name = Names.SingleName(CoreEnums.Word.ElfPlace) + " " + Names.SingleName(CoreEnums.Word.ElfPlace), Description = "A language common to the lesser races of the world." };
            }
            return new Language { Id = 0, Name = Names.SingleName(CoreEnums.Word.ElfPlace) + " the Low Tongue", Description = "A language common to the lesser races of the world." };
        }

        // leaving some old code here in case I want to use it later?..
        //public ILanguage Generate(IRace race)
        //{
        //    string name = new MarkovNameGenerator(Core.Enums.CoreEnums.Word.ElfPlace).NextName;
        //    ILanguage commonTongue = new Language { Id = 0, Name = name + " the Low Tongue", Description = "A language common to the lesser races of the world." };
        //}

        // hazaren the withering tongue
        // hazeren of highever
        // etc...
    }
}
