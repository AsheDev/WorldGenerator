using Core.Interfaces;

namespace Core.Calendar
{
    public class CalendarDay : IDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
