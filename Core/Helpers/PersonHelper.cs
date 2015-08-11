using Core.Enums;
using Core.Interfaces;

namespace Core.Helpers
{
    public class PersonHelper
    {
        public IRace Race { get; set; }
        public ICivilization Civilization { get; set; }
        public IPopulationCenters OriginatesFrom { get; set; }
        public IMythology Mythology { get; set; }
        public IPerson Father { get; set; }
        public IPerson Mother { get; set; }
        public IPerson Partner { get; set; }
    }
}
