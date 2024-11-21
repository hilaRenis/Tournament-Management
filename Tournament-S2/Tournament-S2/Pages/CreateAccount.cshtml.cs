using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL.Models;
using DAL.UserDAL;
using BLL.UserBLL;
using System.ComponentModel.DataAnnotations;
using BLL.Utils;

namespace Tournament_Web_Application.Pages
{
    public class CreateAccountModel : PageModel 
    {
        private UserLogicLayer userLogic;

        public CreateAccountModel(UserLogicLayer userLogic)
        {
            this.userLogic = userLogic;
        }

        [BindProperty]
        [Required(ErrorMessage = "Name field cannot be empty!")]

        public string Name { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "LastName field cannot be empty!")]
        public string LastName { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Username field cannot be empty!")]
        public string Username { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Password field cannot be empty!")]
        public string Password { get; set; }


        public ActionResult OnPost()
        {
          
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string salt = PasswordHash.GenerateSalt();
            string password = PasswordHash.HashPassword(Password, salt);

            bool created = userLogic.CreateUser(new BLL.Models.Users(Name, LastName,Username,password,salt));

            if (created == false)
            {
                ModelState.AddModelError("User.Username", $"Username exists! Please, choose a new one.");
            }
            else
            {
                TempData["success"] = "Account created successfully";
            }

            return Page();

        }
    }
}
