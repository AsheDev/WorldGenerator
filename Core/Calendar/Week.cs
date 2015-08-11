using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Calendar
{
    public class CalendarWeek : IWeek
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<IDay> Days { get; set; }
    }
}
