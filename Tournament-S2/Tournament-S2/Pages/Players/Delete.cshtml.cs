using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using BLL.Models;
using BLL.PlayerBLL;
using BLL.DTO;

namespace Tournament_Web_Application.Pages.Players
{
    [Authorize(Policy = "ADMIN")]
    public class DeleteModel : PageModel
    {
        private PlayerLogicLayer playerLogicLayer;

        [BindProperty]
        public PlayerDTO PlayerDTO { get; set; }

        public DeleteModel(PlayerLogicLayer playerLogicLayer)
        {
            this.playerLogicLayer = playerLogicLayer;
        }

        public void OnGet(int id)
        {
            var player = playerLogicLayer.GetPlayerById(new Player(id));
            PlayerDTO = new PlayerDTO(player);
        }

        public ActionResult OnPost()
        {
            var player = new Player(PlayerDTO.Id);
            playerLogicLayer.DeletePlayer(player);
            TempData["success"] = "Player deleted successfully";
            return RedirectToPage("/Players/Player");
        }
    }
}
