using Core.Enums;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IPerson : IBase // not super sold on "Person"
    {
        CoreEnums.Gender Gender { get; set; }
        IRace Race { get; set; } // you cacn get their language from their race
        ICivilization Civilization { get; set; }
        IPopulationCenters OriginatesFrom { get; set; } // I can get region/continent from here
        IMythology Mythology { get; set; }
        IDeity PersonalDeity { get; set; }
        double Age { get; set; }
        IPerson Father { get; set; }
        IPerson Mother { get; set; }
        IPerson Partner { get; set; } // let's try to not make this static (let it change with time possibly)
        List<IPerson> Children { get; set; }
        List<ITraits> Traits { get; set; }
        CoreEnums.Status SocialStatus { get; set; }
        bool Alive { get; set; } // when I'm using the database this may not be all that useful

        // this needs to be a type i think thats good nope nope just this needs to be a type nope this just needs to be a type.
        int BirthYear { get; }
        int BirthMonth { get; }
        int BirthDay { get; }

        // i love you verne 
 
        



        // Month? Year? Era? Also, birth date?
        // profession
        // physical characteristics that can be passed on?
    }
}
