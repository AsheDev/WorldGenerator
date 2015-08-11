using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMonth : IBase
    {
        int DaysInMonth { get; set; }
    }
}
