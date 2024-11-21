using BLL.TeamBLL;
using BLL.Models;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Tournament_Web_Application.Pages.Teams
{
    [Authorize(Policy = "ADMIN")]
    public class DeleteModel : PageModel
    {
        private TeamLogicLayer teamLogicLayer;

        [BindProperty]
        public TeamDTO TeamDTO { get; set; }

        public DeleteModel(TeamLogicLayer teamLogicLayer)
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
            var team = new Team(TeamDTO.Id);
            teamLogicLayer.DeleteTeam(team);
            TempData["success"] = "Team deleted successfully";
            return RedirectToPage("/Teams/Team");
        }
    }
}
