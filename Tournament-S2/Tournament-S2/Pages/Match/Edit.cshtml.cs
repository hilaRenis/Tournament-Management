using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using BLL.MatchBLL;
using BLL.Models;
using BLL.TeamBLL;
using BLL.TournamentBLL;
using BLL.DTO;
using BLL.LocationBLL;

namespace Tournament_Web_Application.Pages.Match
{
    [Authorize]
    public class EditModel : PageModel
    {
        private MatchLogicLayer matchLogicLayer;
        private TeamLogicLayer teamsLogicLayer;
        private LocationLogicLayer locationLogicLayer;
        private TournamentLogicLayer tournamentLogicLayer;
        private IHttpContextAccessor httpContextAccessor;


        public SelectList Team1 { get; set; }
        public SelectList Team2 { get; set; }
        public SelectList Tournaments { get; set; }
        public SelectList Locations { get; set; }


        [BindProperty]
        public MatchDTO MatchDTO { get; set; }

        public EditModel(MatchLogicLayer matchLogicLayer, TeamLogicLayer teamsLogicLayer, TournamentLogicLayer tournamentLogicLayer, IHttpContextAccessor httpContextAccessor, LocationLogicLayer locationLogicLayer)
        {
            this.matchLogicLayer = matchLogicLayer;
            this.teamsLogicLayer = teamsLogicLayer;
            this.tournamentLogicLayer = tournamentLogicLayer;
            this.httpContextAccessor = httpContextAccessor;
            this.locationLogicLayer = locationLogicLayer;
        }

        public void OnGet(int id)
        {
            var match = matchLogicLayer.GetMatchById(new Matches(id));
            MatchDTO = new MatchDTO(match);

            LoadData();
        }

        public ActionResult OnPost()
        {
            if (MatchDTO.Team1Id == MatchDTO.Team2Id)
            {
                ModelState.AddModelError("MatchDTO.Team2.Id", $"Please, choose another team.");
            }
            else
            {
                var team1 = teamsLogicLayer.GetTeamById(new Team(MatchDTO.Team1Id));
                var team2 = teamsLogicLayer.GetTeamById(new Team(MatchDTO.Team2Id));
                var tournament = tournamentLogicLayer.GetTournamentById(new Tournament(MatchDTO.TournamentId));
                var updatedMatch = new Matches(MatchDTO.Id, MatchDTO.DateOfMatch, MatchDTO.TournamentId,
                                                tournament.TournamentName, MatchDTO.Team1Id, team1.Name, MatchDTO.Team2Id, team2.Name, MatchDTO.LocationId);
                if (!matchLogicLayer.UpdateMatch(updatedMatch))
                {
                    ModelState.AddModelError("MatchDTO.DateOfMatch", $"Cannot update match that has already occurred");
                    LoadData();
                    return Page();
                }
                TempData["success"] = "Match updated successfully";
                return RedirectToPage("/Match/Match");
            }
            LoadData();
            return Page();
        }

        private void LoadData()
        {
            var teams = teamsLogicLayer.GetAllTeams();
            Team1 = new SelectList(teams, "Id", "Name", MatchDTO.Team1Id);
            Team2 = new SelectList(teams, "Id", "Name", MatchDTO.Team2Id);

            var role = httpContextAccessor.HttpContext.User.FindFirst("Role").Value;
            var userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst("Id").Value);
            BLL.Models.Users user = new BLL.Models.Users(userId, role);

            var tournaments = tournamentLogicLayer.GetAllTournaments(user);
            Tournaments = new SelectList(tournaments, "Id", "TournamentName", MatchDTO.TournamentId);

            var locations = locationLogicLayer.GetAllLocation();
            Locations = new SelectList(locations, "Id", "Name", MatchDTO.LocationId);
        }
    }
}
