using BLL.TeamBLL;
using BLL.Models;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Tournament_Web_Application.Pages.Teams
{
    [Authorize(Policy = "ADMIN")]
    public class CreateModel : PageModel
    {
        private TeamLogicLayer teamLogicLayer;
        [BindProperty]
        public TeamDTO TeamDTO { get; set; }

        public CreateModel(TeamLogicLayer teamLogicLayer)
        {
            this.teamLogicLayer = teamLogicLayer;
        }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            bool created = teamLogicLayer.AddNewTeam(new Team(TeamDTO.Id, TeamDTO.Name));
            if (created == false)
            {
                ModelState.AddModelError("Team.Name", $"Team with name {TeamDTO.Name} exists! Please, choose a new one.");
                return Page();
            }
            else
            {
                TempData["success"] = "Team created successfully";
                return RedirectToPage("/Teams/Team");
            }
        }
    }
}
