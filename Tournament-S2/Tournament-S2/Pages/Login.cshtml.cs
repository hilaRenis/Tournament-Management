using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL.Models;
using DAL.UserDAL;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using BLL.UserBLL;
using System.ComponentModel.DataAnnotations;
using BLL.DTO;
using BLL.Utils;

namespace Tournament_Web_Application.Pages
{
    public class LoginModel : PageModel
    {
        private UserLogicLayer userLogic;

        public LoginModel(UserLogicLayer userLogic)
        {
            this.userLogic = userLogic; 
        }

        [BindProperty]
        [Required(ErrorMessage = "Username field cannot be empty!")]

        public string Username { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Password field cannot be empty!")]

        public string Password { get; set; }

        public void OnGet()
        {

        }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            BLL.Models.Users GetUserByUsername = userLogic.GetUserByUsername(new BLL.Models.Users(Username));

            BLL.Models.Users user = new BLL.Models.Users(Username, PasswordHash.HashPassword(Password, GetUserByUsername.Salt), GetUserByUsername.Salt);

            BLL.Models.Users foundUser = userLogic.GetUser(user);

            if (foundUser == null)
            {
                TempData["error"] = "User doesn't exist";
                return Page();
            }
            else
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, Username));
                claims.Add(new Claim("Id", Convert.ToString(foundUser.Id)));
                claims.Add(new Claim("Role", foundUser.Role.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return new RedirectToPageResult("index");
            }
        }
    }
}
