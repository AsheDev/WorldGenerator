using System.Collections.Generic;
using Core.Enums;

namespace Core.Interfaces
{
    public interface IMythology : IBase
    {
        CoreEnums.MythologicalType MythosType { get; set; }
        List<IDeity> Deities { get; set; }
    }
}
