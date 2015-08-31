using System;
using Core.Enums;
using Connections;
using System.Data;
using Core.Utility;
using Core.Interfaces;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Generate
{
    public class NameGen
    {
        private Random Random { get; set; }
        MarkovNameGenerator Generator { get; set; }
        private List<string> Adjectives { get; set; }
        private List<string> UsedAdjectives { get; set; }

        public NameGen()
        {
            GeneralWordGen wordGen = new GeneralWordGen();
            Random = new Random(Guid.NewGuid().GetHashCode());
            Generator = new MarkovNameGenerator();
            Adjectives = wordGen.GetAdjectives();
            UsedAdjectives = new List<string>();
        }

        public string SingleName(CoreEnums.Word nameType)
        {
            return Generator.GetName(nameType);
        }

        public string SingleNameWithAdjective(CoreEnums.Word nameType)
        {
            GeneralWordGen general = new GeneralWordGen();
            return Generator.GetName(nameType) + " the " + GetAdjective().CapitalizeFirstLetter();
        }

        public string FirstAndLastName(CoreEnums.Word firstNameType, CoreEnums.Word lastNameType)
        {
            return Generator.GetName(firstNameType) + " " + Generator.GetName(lastNameType);
        }

        public string FirstAndLastNameWithAdjective(CoreEnums.Word firstNameType, CoreEnums.Word lastNameType)
        {
            GeneralWordGen general = new GeneralWordGen();
            return Generator.GetName(firstNameType) + " " + Generator.GetName(lastNameType) + " the " + GetAdjective().CapitalizeFirstLetter();
        }

        // TODO: prefer "places" for this and not male/female
        public string RegionName(IClimate climate, CoreEnums.Word nameType)
        {
            // I could put this on one line but I think it'd be less clear
            string name = Generator.GetName(nameType) + ClimateSwitch(climate);
            if (Random.Next(0, 4) == 0) name = AffixDemonstrative(name);
            return name;
        }

        // TODO: prefer "places" for this and not male/female
        public string RegionNameWithAdjective(IClimate climate, CoreEnums.Word nameType)
        {
            GeneralWordGen general = new GeneralWordGen();
            string name = Generator.GetName(nameType);
            if (Random.Next(0, 5) == 0) name = name + " the " + GetAdjective().CapitalizeFirstLetter();
            name = name + ClimateSwitch(climate);
            return name;
        }

        /// <summary>
        /// Gets an adjective. As it goes it removes adjectives from the list. If none exist the list is repopulated.
        /// </summary>
        /// <returns></returns>
        private string GetAdjective()
        {
            if (Adjectives.Count == 0) Adjectives.AddRange(UsedAdjectives);
            string adjective = Adjectives[Random.Next(0, Adjectives.Count - 1)];
            UsedAdjectives.Add(adjective);
            Adjectives.Remove(adjective);
            return adjective;
        }

        private string AffixDemonstrative(string name)
        {
            name = "The " + name;
            if (Random.Next(0, 3) == 0 && name[name.Length - 1] != 's') name = name + "s";
            return name;
        }

        private string ClimateSwitch(IClimate climate)
        {
            switch(climate.GetType().Name.ToLower())
            {
                case "alpine":
                    return Forests();
                case "chaparral":
                    return FlatLands();
                case "deciduousforest":
                    return Forests();
                case "desert":
                    return Deserts();
                case "grassland":
                    return FlatLands();
                case "rainforest":
                    return Forests();
                case "savanna":
                    return Savannas();
                case "steppe":
                    return Steppes();
                case "taiga":
                    return Arctic();
                case "tundra":
                default:
                    return Arctic();
            }
        }

        private string Forests()
        {
            List<string> adjectives = new List<string>
            {
                //" Primeval Forest",
                " Woodland",
                " Backwood",
                " Wildwood",
                " Hinterland",
                " Grove",
                " Wood",
                " Highland",
                " Maze",
                " Forest",
                " Labyrinth",
                " Jungle",
                " Mazes"
            };
            return adjectives[Random.Next(0, adjectives.Count - 1)];
        }

        private string Savannas()
        {
            List<string> adjectives = new List<string>
            {
                " Boscages",
                " Wildnerness",
                " Badlands"
            };
            return adjectives[Random.Next(0, adjectives.Count - 1)];
        }
        
        private string FlatLands()
        {
            List<string> adjectives = new List<string>
            {
                " Pastures",
                " Llanos",
                " Swards",
                " Veldts",
                " Ranges",
                " Pampas",
                " Fields",
                " Expanses",
                " Prairies",
                " Flatlands",
                " Outbacks",
                " Brambles",
                " Wilderness",
                " Thickets",
                " Flats",
                " Wilds",
                " Heaths",
                " Badlands",
                " Coppices",
                " Steppes",
                " Plains",
                " Wealds",
                " Morass",
                " Muskegs",
                " Mires",
                " Quagmires",
                " Sloughs",
                " Fens",
                " Wetlands",
                " Bogs",
                " Marshes",
                " Swamps",
                " Lowlands",
                " Wastelands",
                " Moors",
                " Mazes",
                " Wastes"
            };
            return adjectives[Random.Next(0, adjectives.Count - 1)];
        }

        private string Arctic()
        {
            List<string> adjectives = new List<string>
            {
                " Dunes",
                " Plains",
                " Llanos",
                " Flatlands",
                " Expanses",
                " Ranges",
                " Wastes"
            };
            return adjectives[Random.Next(0, adjectives.Count - 1)];
        }

        private string Deserts()
        {
            List<string> adjectives = new List<string>
            {
                " Dunes",
                " Sands"
            };
            return adjectives[Random.Next(0, adjectives.Count - 1)];
        }

        private string Steppes()
        {
            List<string> adjectives = new List<string>
            {
                " Plateaus",
                " Badlands",
                " Bluffs"
            };
            return adjectives[Random.Next(0, adjectives.Count - 1)];
        }

        
    }
}
