using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;

namespace PRN221_Project1._0.Pages
{
    public class LoginModel : PageModel
    {
        ILectureRepository _lectureRepository;
        [BindProperty]
        public string? username { get; set; }
        [BindProperty]
        public string? password { get; set; }
        public string? msg { get; set; }
        public LoginModel(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }
        public IActionResult OnGet()
        {
            string json = HttpContext.Session.GetString("lecture");
            if (!string.IsNullOrEmpty(json))
            {
                return RedirectToPage("/Timetable");
            }
            else
            {
                string wsadmin = HttpContext.Session.GetString("admin");
                if (!string.IsNullOrEmpty(wsadmin))
                {
                    return RedirectToPage("/ManageGroup");
                }
            }
            return Page();

        }
        public IActionResult OnPost()
        {
            LectureDTO lecture = _lectureRepository.GetLecture(username, password);
            if (username.Equals("wsadmin@gmail.com") && password.Equals("admin123"))
            {
                HttpContext.Session.SetString("admin", username);
                return RedirectToPage("ManageGroup");
            }
            else
            {
                if (lecture != null)
                {
                    string json = JsonConvert.SerializeObject(lecture);
                    HttpContext.Session.SetString("lecture", json);
                    msg = "login success";
                    return RedirectToPage("Timetable");
                }
                else
                {
                    msg = "Invalid";
                    return Page();
                }
            }

        }
    }
}
