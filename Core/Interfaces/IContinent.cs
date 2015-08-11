using Core.Enums;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IContinent : IBase
    {
        IWorld World { get; set; }
        CoreEnums.ContinentSize Size { get; set; }
        int AreaKilometersSquare { get; set; }
        List<IRegion> ListOfRegions { get; set; }
        Dictionary<CoreEnums.CardinalDirections, IContinent> AdjoiningContinents { get; set; } // 0 means there is no connection yet
        int UpperLatitude { get; set; }
        int Lowerlatitude { get; set; }
        List<ICivilization> CivilizationsPresent { get; set; }
    }
}
