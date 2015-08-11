using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Worlds
{
    public class World : IWorld
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<IMythology> Mythologies { get; set; }
    }
}
