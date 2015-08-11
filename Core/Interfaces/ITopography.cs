using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ITopography : IBase
    {
        List<IFeatures> Features { get; set; }
        List<ITopography> CorrespondingTopography { get; set; }
    }
}
