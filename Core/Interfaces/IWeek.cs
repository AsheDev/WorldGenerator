using System.Collections.Generic;

namespace Core.Interfaces
{
    // I'm not sure this is useful...
    public interface IWeek : IBase
    {
        List<IDay> Days { get; set; }
    }
}
