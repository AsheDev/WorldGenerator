using Core.Utility;
using Core.Observer;
using Core.Languages;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Races
{
    public class Elves : IRace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ILanguage NativeTongue { get; set; }
        public ILanguage CommonTongue { get; set; }
        public IMythology Mythos { get; set; }
        public int LifeSpan { get { return lifeSpan; } }
        public int SexualMaturity { get { return sexualMaturity; } }

        private int lifeSpan;
        private int sexualMaturity;

        public Elves()
        {
            NativeTongue = new Language();
            CommonTongue = new Language();
            Mythos = new Core.Mythology.Mythology();
            lifeSpan = 5700;
            sexualMaturity = 735;
        }
    }
}
