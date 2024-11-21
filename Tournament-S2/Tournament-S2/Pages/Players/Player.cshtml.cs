using BLL.Models;
using BLL.PlayerBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Tournament_Web_Application.Pages.Players
{
    [Authorize(Policy = "ADMIN")]
    public class PlayerModel : PageModel
    {
        private PlayerLogicLayer playerLogicLayer;
        public List<Player> players;

        public PlayerModel(PlayerLogicLayer playerLogicLayer)
        {
            this.playerLogicLayer = playerLogicLayer;
        }

        public void OnGet()
        {
            players = playerLogicLayer.GetAllPlayers();

        }
    }
}
