using Core.Enums;
using Core.Interfaces;

namespace Core.Mythology
{
    public class Deity : IDeity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IDeity ChiefDiety { get; set; } // if this is null then they are the primary deity
        public CoreEnums.Deity Prominence { get; set; }
        public CoreEnums.Alignment Alignment { get; set; }
    }
}
