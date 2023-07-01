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
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            LectureDTO lecture = _lectureRepository.GetLecture(username, password);
            if (lecture != null)
            {
                string json = JsonConvert.SerializeObject(lecture);
                HttpContext.Session.SetString("lecture", json);
                msg = "login success";
                return Page();
            }
            else
            {
                msg = "Invalid";
                return Page();
            }

        }
    }
}
