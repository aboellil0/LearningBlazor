using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Pages
{
    public partial class EventBookingSystem : ComponentBase // Ensure the class inherits from ComponentBase  
    {
        private DateTime CurrentMonth { get; set; } = new DateTime(2024, 4, 1);
        private int SelectedDay { get; set; } = 15;

        private List<CalendarDay> CalendarDays { get; set; } = new List<CalendarDay>();

        protected override void OnInitialized() // This method is valid only if the class inherits from ComponentBase  
        {
            GenerateCalendarDays();
        }

        private void GenerateCalendarDays()
        {
            CalendarDays.Clear();

            // Determine the first day of the month  
            DateTime firstDayOfMonth = new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1);

            // Calculate how many empty cells we need before the first day  
            int emptyCellCount = ((int)firstDayOfMonth.DayOfWeek == 0 ? 7 : (int)firstDayOfMonth.DayOfWeek) - 1;

            // Add empty cells  
            for (int i = 0; i < emptyCellCount; i++)
            {
                CalendarDays.Add(new CalendarDay { Day = 0, IsEmpty = true });
            }

            // Get the number of days in the month  
            int daysInMonth = DateTime.DaysInMonth(CurrentMonth.Year, CurrentMonth.Month);

            // Add days of the month  
            for (int i = 1; i <= daysInMonth; i++)
            {
                CalendarDays.Add(new CalendarDay
                {
                    Day = i,
                    IsSelected = i == SelectedDay,
                    IsToday = i == DateTime.Now.Day && CurrentMonth.Month == DateTime.Now.Month && CurrentMonth.Year == DateTime.Now.Year
                });
            }
        }

        private void SelectDay(int day)
        {
            if (day <= 0) return;

            SelectedDay = day;

            // Update selection status for all days  
            foreach (var calendarDay in CalendarDays)
            {
                calendarDay.IsSelected = calendarDay.Day == day;
            }
        }

        private void NavigateMonth(int monthOffset)
        {
            CurrentMonth = CurrentMonth.AddMonths(monthOffset);
            SelectedDay = -1; // Clear selection when changing months  
            GenerateCalendarDays();
        }
    }

    public class CalendarDay
    {
        public int Day { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsSelected { get; set; }
        public bool IsToday { get; set; }
    }
}