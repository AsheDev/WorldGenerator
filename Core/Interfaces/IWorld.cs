using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IWorld : IBase
    {
        List<IMythology> Mythologies { get; set; }
    }
}
