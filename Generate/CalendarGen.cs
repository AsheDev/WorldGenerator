using System;
using Core.Enums;
using Core.Calendar;
using Core.Interfaces;
using System.Collections.Generic;

namespace Generate
{
    public class CalendarGen
    {
        private Random Random { get; set; }
        private NameGen Names { get; set; }

        public CalendarGen()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
            Names = new NameGen();
        }

        /// <summary>
        /// Generate a single calendar year
        /// </summary>
        /// <returns></returns>
        public IYear Generate()
        {
            int daysInWeek = Random.Next(5, 13);
            List<IDay> days = new List<IDay>();
            for (int n = 0; n < daysInWeek; n++)
            {
                days.Add(GenerateDay());
            }

            IWeek week = GenerateWeek(days);

            int monthsInYear = Random.Next(9, 17);
            List<IMonth> months = new List<IMonth>();
            for (int n = 0; n < monthsInYear; n++)
            {
                months.Add(GenerateMonth());
            }

            IYear calendarYear = GenerateYear(months, week);
            calendarYear = FillDaysInMonths(calendarYear);

            return calendarYear;
        }

        private IDay GenerateDay()
        {
            IDay day = new CalendarDay
            {
                Id = Random.Next(1, 42545253),
                Name = Names.SingleName(Core.Enums.CoreEnums.Word.ElfFemale) + "dag", // TODO: randomize this a bit
                Description = "DESCRIPTION"
            };
            return day;
        }

        private IWeek GenerateWeek(List<IDay> days)
        {
            IWeek week = new CalendarWeek
            {
                Id = Random.Next(1, 42545253),
                Name = Names.SingleName(Core.Enums.CoreEnums.Word.ElfFemale) + " aun sennight", // TODO: randomize this a bit
                Description = "DESCRIPTION",
                Days = days
            };
            return week;
        }

        private IMonth GenerateMonth()
        {
            IMonth month = new CalendarMonth
            {
                Id = Random.Next(1, 42545253),
                Name = Names.SingleName(Core.Enums.CoreEnums.Word.ElfFemale) + " obermaand", // TODO: randomize this a bit
                Description = "DESCRIPTION"
            };
            return month;
        }

        private IYear GenerateYear(List<IMonth> months, IWeek week)
        {
            IYear year = new CalendarYear
            {
                Id = Random.Next(1, 42545253),
                Name = Names.SingleName(Core.Enums.CoreEnums.Word.ElfFemale) + " arn", // TODO: randomize this a bit
                Description = "DESCRIPTION",
                Months = months,
                Week = week,
                Count = 1,
                Epoch = CoreEnums.Epochs.AgeOfMyth
            };
            return year;
        }

        private IYear FillDaysInMonths(IYear year)
        {
            int daysInYear = Random.Next(291, 472);
            int ballpark = daysInYear / year.Months.Count;

            foreach (IMonth month in year.Months)
            {
                int variance = Random.Next(-2, 3);
                month.DaysInMonth = ballpark + variance;
            }
            return year;
        }
    }
}
