using BLL.TournamentBLL;
using BLL.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tournament_Web_Application.Pages.Tournaments
{
    [Authorize]
    public class TournamentModel : PageModel
    {
        private TournamentLogicLayer tournamentLogicLayer;
        public List<Tournament> tournaments;
        private IHttpContextAccessor httpContextAccessor;

        public TournamentModel(TournamentLogicLayer tournamentLogicLayer, 
            IHttpContextAccessor httpContextAccessor)
        {
            this.tournamentLogicLayer = tournamentLogicLayer;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            var role = httpContextAccessor.HttpContext.User.FindFirst("Role").Value;
            var userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst("Id").Value);
            BLL.Models.Users user = new BLL.Models.Users(userId, role);

            tournaments = tournamentLogicLayer.GetAllTournaments(user);
        }

        public ActionResult OnPost()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
            var user = new BLL.Models.Users { Id = Convert.ToInt32(userId) };
            bool created = tournamentLogicLayer.GenerateAutomaticTournament(user);

            if (created == false)
            {
                return Page();
            }
            else
            {
                TempData["success"] = "Tournament created successfully";
                return RedirectToPage("/Tournaments/Tournament");
            }
        }
    }
}
