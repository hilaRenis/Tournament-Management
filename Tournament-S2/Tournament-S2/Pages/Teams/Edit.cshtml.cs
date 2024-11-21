using BLL.TeamBLL;
using BLL.TournamentBLL;
using BLL.Models;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Tournament_Web_Application.Pages.Teams
{
    [Authorize(Policy = "ADMIN")]
    public class EditModel : PageModel
    {
        private TeamLogicLayer teamLogicLayer;

        [BindProperty]
        public TeamDTO TeamDTO { get; set; }

        public EditModel(TeamLogicLayer teamLogicLayer)
        {
            this.teamLogicLayer = teamLogicLayer;
        }

        public void OnGet(int id)
        {
            var team = teamLogicLayer.GetTeamById(new Team(id));
            TeamDTO = new TeamDTO(team);
        }

        public ActionResult OnPost()
        {
            var team = new Team(TeamDTO.Id, TeamDTO.Name);
            teamLogicLayer.UpdateTeam(team);
            TempData["success"] = "Team updated successfully";
            return RedirectToPage("/Teams/Team");
        }
    }
}
