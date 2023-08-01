using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Project1._0.Pages
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.CommitAsync();
            return RedirectToPage("/Login");
        }
    }
}
