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
    public class CreateModel : PageModel
    {
        private PlayerLogicLayer playerLogicLayer;
        private TeamLogicLayer teamsLogicLayer;
        private NationalityLogicLayer nationalityLogicLayer;
        
        public SelectList Teams { get; set; }

        public SelectList Nationalities { get; set; }

        [BindProperty]
        public PlayerDTO PlayerDTO { get; set; }

        public CreateModel(PlayerLogicLayer playerLogicLayer, TeamLogicLayer teamsLogicLayer, NationalityLogicLayer nationalityLogicLayer)
        {
            this.playerLogicLayer = playerLogicLayer;
            this.teamsLogicLayer = teamsLogicLayer;
            this.nationalityLogicLayer = nationalityLogicLayer;
        }

        public void OnGet()
        {
            var teams = teamsLogicLayer.GetAllTeams();
            Teams = new SelectList(teams, "Id", "Name");

            var nationalities = nationalityLogicLayer.GetAllNationalities();
            Nationalities = new SelectList(nationalities.Select(t => new NationalityDTO(t)), "Id", "Name");
        }

        public ActionResult OnPost()
        {
            playerLogicLayer.AddNewPlayer(new Player(PlayerDTO.Id, PlayerDTO.Name, PlayerDTO.NationalityId, PlayerDTO.DateOfBirth,
                                                     new Team(Convert.ToInt32(PlayerDTO.TeamDTO.Id))));
            TempData["success"] = "Player created successfully";
            return RedirectToPage("/Players/Player");
        }
    }
}
