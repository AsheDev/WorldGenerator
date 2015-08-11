using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public class CoreEnums
    {
        public enum AverageRange
        {
            VeryLow = 0,
            Low = 1,
            Moderate = 2,
            High = 3,
            VeryHigh = 4
        };
                
        public enum ContinentSize
        {
            VerySmall = 7000000,    // 07,000,000 Sq. Km
            Small = 12000000,       // 12,000,000 Sq. Km
            Moderate = 21000000,    // 21,000,000 Sq. Km
            Large = 37000000,       // 37,000,000 Sq. Km
            VeryLarge = 68000000,   // 68,000,000 Sq. Km
        }

        public enum RegionSize
        {
            VerySmall = 1400000,   // 1,400,000 Sq. Km
            Small = 3200000,       // 3,200,000 Sq. Km
            Moderate = 4000000,    // 4,000,000 Sq. Km
            Large = 5300000,       // 5,300,000 Sq. Km
            VeryLarge = 6200000,   // 6,200,000 Sq. Km
        }

        public enum Alignment
        {
            LawfulGood = 0,
            NeutralGood = 1,
            ChaoticGood = 2,
            LawfulNeutral = 3,
            TrueNeutral = 4,
            ChaoticNeutral = 5,
            LawfulEvil = 6,
            NeutralEvil = 7,
            ChaoticEvil = 8
        }

        public enum CardinalDirections
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }

        public enum Epochs
        {
            AgeOfMyth = 0,
            AgeOfLegends = 1,
            AgeOfStories = 2,
            AgeOfPower = 3,
            AgeOfStrife = 4,
            AgeOfTales = 5,
            AgeOfValour = 6,
            AgeOfHeroes = 7,
            AgeOfCivilization = 8,
            AgeOfTwilight = 9
        }

        public enum Climate
        {
            LowLatitude = 0,
            MidLatitude = 1,
            HighLatitude = 2
        }

        public enum Word
        {
            ElfMale = 0,
            ElfFemale = 1,
            ElfPlace = 2,
            HumanMale = 3,
            HumanFemale = 4,
            HumanPlace = 5,
            DwarfMale = 6,
            DwarfFemale = 7,
            DwarfPlace = 8,
            DeityNames = 9,
            Adjective = 10
        }

        public enum Deity
        {
            Primary = 0,
            Major = 1,
            Minor = 2
        }

        //http://atheism.about.com/od/theismtheists/p/theismvarieties.htm
        public enum MythologicalType
        {
            Monotheistic = 0,
            Polytheistc = 1,
            Pantheistic = 2
        }

        public enum Gender
        {
            Male = 0,
            Female = 1
        }

        public enum Status
        {
            Highborne = 0,
            Lowborne = 1
        }
    }
}
