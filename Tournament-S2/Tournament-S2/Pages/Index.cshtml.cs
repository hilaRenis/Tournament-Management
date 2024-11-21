using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tournament_Web_Application.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet() 
        {
        }
    }
}
