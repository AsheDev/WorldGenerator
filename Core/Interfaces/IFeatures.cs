using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IFeatures : IBase
    {
        // what climates is this feature found (restricted to) in?
        //List<IClimate> ClimateRestrictions { get; set; } // should this be private?
    }
}
