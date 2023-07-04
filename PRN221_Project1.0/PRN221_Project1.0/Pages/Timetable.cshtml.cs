using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Project1._0.Pages
{
    public class TimetableModel : PageModel
    {
        public int? year;
        public int? selectedYear;
        public int? week;
        public int? selectedWeek;
        public TimetableModel()
        {

        }
        public void OnGet(int? year, int? week)
        {
            if (year.HasValue && week.HasValue)
            {
                this.year = year.Value;
                this.week = week.Value;
                selectedWeek = week.Value;
                selectedYear = year.Value;
            }
        }

    }
}
