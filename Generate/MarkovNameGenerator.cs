using System;
using Core.Enums;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Generate
{
    // Generates random names based on the statistical weight of letter sequences
    // in a collection of sample names
    public class MarkovNameGenerator
    {
        private Random Random { get; set; }

        public MarkovNameGenerator()
        {
            // populate random?
        }

        public MarkovNameGenerator(Random random, CoreEnums.Word word)
        {
            int minLength = 4;
            int baseOrder = ((random.Next(0, 2) == 1)) ? 4 + 1 : 4 - 1; // 4 seems to be a sweet spot so we mix it up by doing plus or minus 1
            switch (Convert.ToInt32(word))
            {
                case 0: // male elf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleElvishNames.txt", baseOrder, minLength);
                    break;
                case 1: // female elf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleElvishNames.txt", baseOrder, minLength);
                    break;
                case 2: // elf places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\ElvishPlaceNames.txt", baseOrder, minLength);
                    break;
                case 3: // male human names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleHumanNames.txt", baseOrder, minLength);
                    break;
                case 4: // female human names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleHumanNames.txt", baseOrder, minLength);
                    break;
                case 5: // human places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\HumanPlaceNames.txt", baseOrder, minLength);
                    break;
                case 6: // male dwarf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleDwarfNames.txt", baseOrder, minLength);
                    break;
                case 7: // female dwarf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleDwarfNames.txt", baseOrder, minLength);
                    break;
                case 8: // dwarven places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\DwarvenPlaceNames.txt", baseOrder, minLength);
                    break;
                case 9: // deity names
                default:
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\DeityNames.txt", 4, 4);
                    break;
            }
        }

        // What about an order of 8 for place names?
        public MarkovNameGenerator(CoreEnums.Word word)
        {
            Random = new Random();
            int minLength = 4;
            int baseOrder = ((Random.Next(0, 2) == 1)) ? 4 + 1 : 4 - 1; // 4 seems to be a sweet spot so we mix it up by doing plus or minus 1
            switch (Convert.ToInt32(word))
            {
                case 0: // male elf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleElvishNames.txt", baseOrder, minLength);
                    break;
                case 1: // female elf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleElvishNames.txt", baseOrder, minLength);
                    break;
                case 2: // elf places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\ElvishPlaceNames.txt", baseOrder, minLength);
                    break;
                case 3: // male human names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleHumanNames.txt", baseOrder, minLength);
                    break;
                case 4: // female human names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleHumanNames.txt", baseOrder, minLength);
                    break;
                case 5: // human places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\HumanPlaceNames.txt", baseOrder, minLength);
                    break;
                case 6: // male dwarf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleDwarfNames.txt", baseOrder, minLength);
                    break;
                case 7: // female dwarf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleDwarfNames.txt", baseOrder, minLength);
                    break;
                case 8: // dwarven places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\DwarvenPlaceNames.txt", baseOrder, minLength);
                    break;
                case 9: // deity names
                default:
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\DeityNames.txt", 4, 4);
                    break;
            }
        }

        public string GetName(CoreEnums.Word nameType)
        {
            Random = new Random();
            int minLength = 4;
            int baseOrder = ((Random.Next(0, 2) == 1)) ? 4 + 1 : 4 - 1; // 4 seems to be a sweet spot so we mix it up by doing plus or minus 1
            switch (Convert.ToInt32(nameType))
            {
                case 0: // male elf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleElvishNames.txt", baseOrder, minLength);
                    break;
                case 1: // female elf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleElvishNames.txt", baseOrder, minLength);
                    break;
                case 2: // elf places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\ElvishPlaceNames.txt", baseOrder, minLength);
                    break;
                case 3: // male human names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleHumanNames.txt", baseOrder, minLength);
                    break;
                case 4: // female human names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleHumanNames.txt", baseOrder, minLength);
                    break;
                case 5: // human places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\HumanPlaceNames.txt", baseOrder, minLength);
                    break;
                case 6: // male dwarf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\MaleDwarfNames.txt", baseOrder, minLength);
                    break;
                case 7: // female dwarf names
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\FemaleDwarfNames.txt", baseOrder, minLength);
                    break;
                case 8: // dwarven places
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\DwarvenPlaceNames.txt", baseOrder, minLength);
                    break;
                case 9: // deity names
                default:
                    NameGenerator(@"C:\Users\Michael\Documents\StoryGenerator\Names\DeityNames.txt", 4, 4);
                    break;
            }
            return NextName;
        }

        // I think this is the problem area when it comes to threads
        // possibly the parser for reading from a file?
        private void NameGenerator(string fileName, int order, int minLength)
        {
            // fix the parameter values
            if (order < 1) order = 1;
            if (minLength < 1) minLength = 1;

            _order = order;
            _minLength = minLength;

            using (TextFieldParser parser = new TextFieldParser(fileName))
            {
                parser.Delimiters = new string[] { "|" };
                while (true)
                {
                    string[] names = parser.ReadFields();
                    if (names == null) break;
                    foreach (string name in names)
                    {
                        string upper = name.Trim().ToUpper();
                        if (upper.Length < order + 1) continue;
                        _samples.Add(upper);
                    }
                }
            }

            // Build the chains
            foreach (string word in _samples)
            {
                for (int letter = 0; letter < word.Length - order; letter++)
                {
                    string token = word.Substring(letter, order);
                    List<char> entry = null;
                    if (_chains.ContainsKey(token))
                        entry = _chains[token];
                    else
                    {
                        entry = new List<char>();
                        _chains[token] = entry;
                    }
                    entry.Add(word[letter + order]);
                }
            }
        }
        
        #region cut this out?
        //constructor
        //public MarkovNameGenerator(string fileName, int order, int minLength)
        //{
        //    //fix parameter values
        //    if (order < 1)
        //        order = 1;
        //    if (minLength < 1)
        //        minLength = 1;

        //    _order = order;
        //    _minLength = minLength;

        //    //@"C:\Users\Michael\Desktop\ElvishNames.txt"
        //    using (TextFieldParser parser = new TextFieldParser(fileName))
        //    {
        //        parser.Delimiters = new string[] { "|" };
        //        while (true)
        //        {
        //            string[] names = parser.ReadFields();
        //            if (names == null)
        //            {
        //                break;
        //            }
        //            foreach (string name in names)
        //            {
        //                string upper = name.Trim().ToUpper();
        //                if (upper.Length < order + 1)
        //                    continue;
        //                _samples.Add(upper);
        //            }
        //        }
        //    }

        //    //Build chains            
        //    foreach (string word in _samples)
        //    {
        //        for (int letter = 0; letter < word.Length - order; letter++)
        //        {
        //            string token = word.Substring(letter, order);
        //            List<char> entry = null;
        //            if (_chains.ContainsKey(token))
        //                entry = _chains[token];
        //            else
        //            {
        //                entry = new List<char>();
        //                _chains[token] = entry;
        //            }
        //            entry.Add(word[letter + order]);
        //        }
        //    }
        //}

        //Get the next random name
        #endregion

        // Should I be doing so much heavy lifting in a GET?
        public string NextName
        {
            get
            {
                // Get a random token somewhere in middle of sample word                
                string s = "";
                do
                {
                    int n = _rnd.Next(_samples.Count);
                    int nameLength = _samples[n].Length;
                    if (nameLength < _order) _order = nameLength;
                    s = _samples[n].Substring(_rnd.Next(0, nameLength - _order), _order);
                    while (s.Length < nameLength)
                    {
                        string token = s.Substring(s.Length - _order, _order);
                        char c = GetLetter(token);
                        if (c != '?')
                            s += GetLetter(token);
                        else
                            break;
                    }

                    if (s.Contains(" "))
                    {
                        string[] tokens = s.Split(' ');
                        s = "";
                        for (int t = 0; t < tokens.Length; t++)
                        {
                            if (tokens[t] == "")
                                continue;
                            if (tokens[t].Length == 1)
                                tokens[t] = tokens[t].ToUpper();
                            else
                                tokens[t] = tokens[t].Substring(0, 1) + tokens[t].Substring(1).ToLower();
                            if (s != "")
                                s += " ";
                            s += tokens[t];
                        }
                    }
                    else
                    {
                        s = s.Substring(0, 1) + s.Substring(1).ToLower();
                    }
                    //Console.WriteLine("\nLength: " + s.Length);
                }
                while (_used.Contains(s) || s.Length < _minLength);
                _used.Add(s);
                return s;
            }
        }

        // Reset the used names
        // Useful? what's this all about?
        public void Reset()
        {
            _used.Clear();
        }

        // Private members (derrrrrr)
        private Dictionary<string, List<char>> _chains = new Dictionary<string, List<char>>();
        private List<string> _samples = new List<string>();
        private List<string> _used = new List<string>();
        private Random _rnd = new Random();
        private int _order;
        private int _minLength;

        // Get a random letter from the chain
        private char GetLetter(string token)
        {
            if (!_chains.ContainsKey(token))
                return '?';
            List<char> letters = _chains[token];
            int n = _rnd.Next(letters.Count);
            return letters[n];
        }
    }
}
