using BLL.UserBLL;
using BLL.Models;
using DAL.UserDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;


namespace Tournament_Web_Application.Pages.Users
{

    [Authorize(Policy = "ADMIN")]
    public class DeleteModel : PageModel
    {
        private UserLogicLayer userLogicLayer;

        [BindProperty]
        public BLL.Models.Users user { get; set; }

        public DeleteModel(UserLogicLayer userLogicLayer)
        {
            this.userLogicLayer = userLogicLayer;
        }

        public void OnGet(BLL.Models.Users user)
        {
            this.user = userLogicLayer.GetUserById(user);
        }

        public IActionResult OnPost()
        {
            if (userLogicLayer.DeleteUser(user))
            {
                TempData["success"] = "User deleted successfully";
            }
            else
            {
                TempData["error"] = "Failed to delete user";
            }

            return RedirectToPage("/Users/User");
        }
    }
}
