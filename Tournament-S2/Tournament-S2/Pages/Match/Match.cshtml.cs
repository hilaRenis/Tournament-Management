using BLL.MatchBLL;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using BLL.TournamentBLL;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.DTO;
using Microsoft.AspNetCore.Http;


namespace Tournament_Web_Application.Pages.Match
{

    [Authorize]
    public class MatchModel : PageModel
    {
        private MatchLogicLayer matchLogicLayer;
        private TournamentLogicLayer tournamentLogicLayer;
        private IHttpContextAccessor httpContextAccessor;

        public SelectList Tournaments { get; set; }
        public List<Matches> matches;

        [BindProperty]
        public MatchDTO MatchDTO { get; set; }

        public MatchModel(MatchLogicLayer matchLogicLayer, TournamentLogicLayer tournamentLogicLayer, IHttpContextAccessor httpContextAccessor)
        {
            this.matchLogicLayer = matchLogicLayer;
            this.tournamentLogicLayer = tournamentLogicLayer;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            matches = matchLogicLayer.GetAllMatches();

            var role = httpContextAccessor.HttpContext.User.FindFirst("Role").Value;
            var userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst("Id").Value);
            BLL.Models.Users user = new BLL.Models.Users(userId, role);
            var tournaments = tournamentLogicLayer.GetAllTournaments(user);
            Tournaments = new SelectList(tournaments.Select(t => new TournamentDTO(t)), "Id", "TournamentName");
        }

        public ActionResult OnPost()
        {
            var tournament = tournamentLogicLayer.GetTournamentById(new Tournament(MatchDTO.TournamentId));

            bool created = matchLogicLayer.GenerateRoundRobinMatches(tournament);

            if (created == false)
            {
                return Page();
            }
            else
            {
                TempData["success"] = "Matches created successfully";
                return RedirectToPage("/Match/Match");
            }
        }
    }
}
