using Core.Interfaces;

namespace Core.Military
{
    public class Castle : IFortification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICivilization ControlledBy { get; set; }
    }
}
