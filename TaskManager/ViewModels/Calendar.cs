namespace TaskManager.ViewModels
{
    public class Calendar
    {
        public CalendarContext Context;
        public List<int> Days;

        public Calendar(int shiftMonth)
        {
            Context = new CalendarContext(shiftMonth);

            Days = new List<int>();

            for (int i = 0; i < Context.FirstWeekDayInMonth; i++)
                Days.Add(0);

            for (int i = 0; i < Context.DaysInMonth; i++)
                Days.Add(i + 1);

            while (Days.Count % 7 != 0)
                Days.Add(0);
        }
    }

    public class CalendarContext
    {
        public DateTime Date { get; set; }
        public int Year { get; set; }        
        public string ViewMonth { get; set; }
        public int ViewToday { get; set; }
        public int DaysInMonth { get; set; }        
        public int FirstWeekDayInMonth { get; set; }
        public int ShiftMonth { get; set; }

        public CalendarContext(int shiftMonth)
        {
            ShiftMonth = shiftMonth;
            Date = DateTime.Now.AddMonths(shiftMonth);
            Date = Date.Date;
            Year = Date.Year;
            var month = Date.Month;
            ViewMonth = Date.ToString("MMMM", new System.Globalization.CultureInfo("en-US"));

            ViewToday = month == DateTime.Now.Month ? Date.Day : -1;

            DaysInMonth = DateTime.DaysInMonth(Year, month);

            var firstDayInMonth = (int)(new DateTime(Year, month, 1).DayOfWeek);

            FirstWeekDayInMonth = (firstDayInMonth + 6) % 7;
        }
    }

}
