using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Languages
{
    public class Language : ILanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
