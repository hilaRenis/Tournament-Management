using BLL.Models;
using BLL.TeamBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tournament_Web_Application.Pages.Teams
{
    [Authorize(Policy = "ADMIN")]
    public class TeamModel : PageModel
    {
        private TeamLogicLayer teamsLogicLayer;
        public List<Team> Teams;

        public TeamModel(TeamLogicLayer teamsLogicLayer)
        {
            this.teamsLogicLayer = teamsLogicLayer;
        }

        public void OnGet()
        {
            Teams = teamsLogicLayer.GetAllTeams();
        }
    }
}
