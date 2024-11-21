using BLL.UserBLL;
using BLL.Models;
using DAL.UserDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using BLL.DTO;
using BLL.Utils;

namespace Tournament_Web_Application.Pages.Users
{

    [Authorize]
    public class EditModel : PageModel
    {
        private UserLogicLayer userLogicLayer;

        [BindProperty]
        public UserDTO UserDTO { get; set; }

        public EditModel(UserLogicLayer userLogicLayer)
        {
            this.userLogicLayer = userLogicLayer;
        }

        public void OnGet(int id)
        {
            var user = userLogicLayer.GetUserById(new BLL.Models.Users(id));
            UserDTO = new UserDTO(user);
        }

        public ActionResult OnPost()
        {
            var salt = "";
            var password = "";

            if (UserDTO.Password == null)
            {
                var user = userLogicLayer.GetUserById(new BLL.Models.Users(UserDTO.Id));
                salt = user.Salt;
                password = user.Password;
            }
            else
            {
                salt = PasswordHash.GenerateSalt();
                password = PasswordHash.HashPassword(UserDTO.Password, salt);
            }

            var selectedUser = new BLL.Models.Users(UserDTO.Id, UserDTO.Name, UserDTO.LastName, UserDTO.Username, password, UserDTO.Role, salt);
            userLogicLayer.UpdateUser(selectedUser);
            TempData["success"] = "Details updated successfully";
            return RedirectToPage("/Users/User");
        }
    }
}
