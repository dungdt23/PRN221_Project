using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;

namespace PRN221_Project1._0.Pages
{
    public class TimetableModel : PageModel
    {
        public int? year;
        public int? selectedYear;
        public int? week;
        public int? selectedWeek;
        ISessionRepository _sessionRepository;
        ISlotRepository _slotRepository;
        public List<SessionDTO> sessions;
        public List<DateTime> dates;
        public List<SlotDTO> slots;
        public TimetableModel(ISessionRepository sessionRepository, ISlotRepository slotRepository)
        {
            _sessionRepository = sessionRepository;
            _slotRepository = slotRepository;
        }
        public IActionResult OnGet(int? year, int? week)
        {
            slots = _slotRepository.GetSlots();

            if (year.HasValue && week.HasValue)
            {
                this.year = year.Value;
                this.week = week.Value;
                selectedWeek = week.Value;
                selectedYear = year.Value;
            }
            //get dates in selected week
            getWeeks();

            //get lecture 
            string json = HttpContext.Session.GetString("lecture");
            if (!string.IsNullOrEmpty(json))
            {
                LectureDTO lecture = JsonConvert.DeserializeObject<LectureDTO>(json);
                // Do something with the lecture object
                DateTime from = dates.First();
                DateTime to = dates.Last();
                sessions = _sessionRepository.GetSessions(lecture.LectureId, from, to);
                return Page();

            }
            else
            {
                // Redirect the user to the login page
                return RedirectToPage("/Login");
            }

        }


        //get list of dates which in selected week
        public void getWeeks()
        {
            List<DateTime> selectedDates = new List<DateTime>();
            if (selectedWeek.HasValue && selectedYear.HasValue)
            {
                DateTime firstMondayOfYear = FindFirstMondayOfYear(selectedYear.Value);
                DateTime mondayOfSelectedWeek = firstMondayOfYear.AddDays(7 * (selectedWeek.Value - 1));
                selectedDates.Add(mondayOfSelectedWeek);
                for (int i = 1; i < 7; i++)
                {
                    DateTime dayInWeek = mondayOfSelectedWeek.AddDays(i);
                    selectedDates.Add(dayInWeek);
                }
            }
            else
            {
                DateTime now = DateTime.Now;
                // calculate the Monday of the current week
                DateTime monday = now.AddDays(-(int)now.DayOfWeek + (int)DayOfWeek.Monday);
                if (now.DayOfWeek == 0)
                {
                    monday = now.AddDays(-(int)6);
                }
                selectedDates.Add(monday);
                for (int i = 1; i < 7; i++)
                {
                    DateTime dayInWeek = monday.AddDays(i);
                    selectedDates.Add(dayInWeek);
                }
            }
            dates = selectedDates;
        }

        public DateTime FindFirstMondayOfYear(int year)
        {
            DateTime date = new DateTime(year, 1, 1);
            // calculate the number of days to add to reach the first Monday
            int daysToAdd = DayOfWeek.Monday - date.DayOfWeek;
            // if the first day of the year is after Monday, add 7 days to get to the next Monday
            if (daysToAdd < 0)
            {
                daysToAdd += 7;
            }
            // add the calculated number of days to reach the first Monday
            date = date.AddDays(daysToAdd);
            return date;
        }

    }
}
