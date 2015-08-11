using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Calendar
{
    public class CalendarMonth : IMonth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int DaysInMonth { get; set; }
    }
}
