using Core.Enums;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Calendar
{
    public class CalendarYear : IYear
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Count { get; set; } // this is the "year" number like 2015 or what have you
        public CoreEnums.Epochs Epoch { get; set; }
        public List<IMonth> Months { get; set; }
        public IWeek Week { get; set; }
        // what civilization does it belong to?
        // what age does it belong to?
    }
}
