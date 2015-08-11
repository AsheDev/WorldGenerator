using Core.Enums;
using Core.Worlds;
using Core.Interfaces;
using System.Collections.Generic;

namespace Generate
{
    public class WorldGen
    {
        private NameGen Names { get; set; }

        public WorldGen()
        {
            Names = new NameGen();
        }

        public IWorld Generate(List<IMythology> mythologies)
        {
            IWorld world = new World
            {
                Id = 0,
                Name = Names.SingleName(CoreEnums.Word.ElfPlace),
                Description = "DESCRIPTION",
                Mythologies = mythologies // if there is only one mythology it will be here, otherwise it will be an empty list waiting to be populated
            };
            return world;
        }
    }
}
