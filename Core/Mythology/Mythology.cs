using Core.Enums;
using Core.Utility;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Mythology
{
    public class Mythology : IMythology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CoreEnums.MythologicalType MythosType { get; set; }
        public List<IDeity> Deities { get; set; }

        public Mythology()
        {
            MythosType = (CoreEnums.MythologicalType)Utility.General.Random.Next(0, CoreEnums.MythologicalType.GetNames(typeof(CoreEnums.MythologicalType)).Length - 1);
        }
    }
}
