using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Generate
{
    public class GeneralWordGen
    {
        private Random Random { get; set; }

        public GeneralWordGen()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
        }

        //http://ideonomy.mit.edu/essays/traits.html
        public List<string> GetPositiveTraits()
        {
            return ReadFromFile(@"C:\Users\Michael\Documents\StoryGenerator\Names\PositiveTraits.txt");
        }

        //http://ideonomy.mit.edu/essays/traits.html
        public List<string> GetNegativeTraits()
        {
            return ReadFromFile(@"C:\Users\Michael\Documents\StoryGenerator\Names\NegativeTraits.txt");
        }

        public string GetAdjective()
        {
            List<string> adjectives = ReadFromFile(@"C:\Users\Michael\Documents\StoryGenerator\Names\Adjectives.txt");
            return adjectives[Random.Next(0, adjectives.Count - 1)];
        }

        public List<string> GetAdjectives()
        {
            return ReadFromFile(@"C:\Users\Michael\Documents\StoryGenerator\Names\Adjectives.txt");
        }

        private List<string> ReadFromFile(string file)
        {
            List<string> listOfWords = new List<string>();
            using (TextFieldParser parser = new TextFieldParser(file))
            {
                parser.Delimiters = new string[] { "|" };
                listOfWords.AddRange(parser.ReadFields());
            }
            return listOfWords;
        }
    }
}
