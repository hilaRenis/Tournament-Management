using BLL.UserBLL;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Tournament_Web_Application.Pages.Users
{

    [Authorize(Policy = "ADMIN")]

    public class UserModel : PageModel
    {
        private UserLogicLayer userLogicLayer;
        public List<BLL.Models.Users> users;

        public UserModel(UserLogicLayer userLogicLayer) 
        {
            this.userLogicLayer = userLogicLayer;
        }

        public void OnGet()
        {
            users = userLogicLayer.GetAllUsers();
        }
    }
}
