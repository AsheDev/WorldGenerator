using Core.Enums;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Persons
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CoreEnums.Gender Gender { get; set;}
        public IRace Race { get; set; } // you can get their language from their race
        public ICivilization Civilization { get; set; }
        public IPopulationCenters OriginatesFrom { get; set; } // I can get region/continent from here
        public IMythology Mythology { get; set; }
        public IDeity PersonalDeity { get; set; }
        public double Age { get; set; }
        public IPerson Father { get; set; }
        public IPerson Mother { get; set; }
        public IPerson Partner { get; set; } // let's try to not make this static (let it change with time possibly)
        public List<IPerson> Children { get; set; }
        public List<ITraits> Traits { get; set; }
        public CoreEnums.Status SocialStatus { get; set; }
        public bool Alive { get; set; }
        public int BirthYear { get { return birthYear; } }
        public int BirthMonth { get { return birthMonth; } }
        public int BirthDay { get { return birthDay; } }
        
        private int birthYear;
        private int birthMonth;
        private int birthDay;

        public Person()
        {
            birthYear = 0;
            birthMonth = 0;
            birthDay = 0;
        }

        public Person(int year, int month, int day)
        {
            birthYear = year;
            birthMonth = month;
            birthDay = day;
        }
    }
}
