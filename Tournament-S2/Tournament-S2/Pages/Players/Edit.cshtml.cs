using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using BLL.Models;
using BLL.PlayerBLL;
using BLL.TeamBLL;
using BLL.DTO;
using BLL.NationalityBLL;
using BLL.LocationBLL;

namespace Tournament_Web_Application.Pages.Players
{
    [Authorize(Policy = "ADMIN")]
    public class EditModel : PageModel
    {
        private PlayerLogicLayer playerLogicLayer;
        private TeamLogicLayer teamsLogicLayer;
        private NationalityLogicLayer nationalityLogicLayer;

        public SelectList Teams { get; set; }

        public SelectList Nationalities { get; set; }

        [BindProperty]
        public PlayerDTO PlayerDTO { get; set; }

        public EditModel(PlayerLogicLayer playerLogicLayer, TeamLogicLayer teamsLogicLayer, NationalityLogicLayer nationalityLogicLayer)
        {
            this.playerLogicLayer = playerLogicLayer;
            this.teamsLogicLayer = teamsLogicLayer;
            this.nationalityLogicLayer = nationalityLogicLayer;
        }

        public void OnGet(int id)
        {
            var player = playerLogicLayer.GetPlayerById(new Player(id));
            PlayerDTO = new PlayerDTO(player);

            var teams = teamsLogicLayer.GetAllTeams();
            Teams = new SelectList(teams, "Id", "Name", PlayerDTO.TeamDTO.Id);

            var nationalities = nationalityLogicLayer.GetAllNationalities();
            Nationalities = new SelectList(nationalities, "Id", "Name", PlayerDTO.NationalityId);
        }

        public ActionResult OnPost()
        {
            var player = new Player(PlayerDTO.Id, PlayerDTO.Name, PlayerDTO.NationalityId, PlayerDTO.DateOfBirth,
                                    new Team(Convert.ToInt32(PlayerDTO.TeamDTO.Id)));
            playerLogicLayer.UpdatePlayer(player);
            TempData["success"] = "Player updated successfully";
            return RedirectToPage("/Players/Player");
        }
    }
}
