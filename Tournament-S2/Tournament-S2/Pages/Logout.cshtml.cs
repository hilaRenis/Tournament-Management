using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tournament_Web_Application.Pages
{
    public class LogoutModel : PageModel
    {
        public ActionResult OnGet()
        {
            HttpContext.SignOutAsync();
            return new RedirectToPageResult("index");
        }
    }
}
