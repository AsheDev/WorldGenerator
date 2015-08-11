using Core.Enums;

namespace Core.Interfaces
{
    public interface IDeity : IBase
    {
        IDeity ChiefDiety { get; set; } // if this is null then they are the primary deity
        CoreEnums.Deity Prominence { get; set; }
        CoreEnums.Alignment Alignment { get; set; }
        // pantheon; in the future I can have multiple pantheons for whatever civilizations or sects... which pantheon do they belong to? I don't know...
    }
}
