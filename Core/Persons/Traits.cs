using Core.Interfaces;

namespace Core.Persons
{
    public class Traits : ITraits
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Healthy { get; set; }
    }
}
