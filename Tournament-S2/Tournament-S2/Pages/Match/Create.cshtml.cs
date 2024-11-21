using BLL.Models;
using BLL.MatchBLL;
using BLL.TeamBLL;
using BLL.TournamentBLL;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using BLL.LocationBLL;

namespace Tournament_Web_Application.Pages.Match
{

    [Authorize]
    public class CreateModel : PageModel
    {
        private MatchLogicLayer matchLogicLayer;
        private TeamLogicLayer teamsLogicLayer;
        private LocationLogicLayer locationLogicLayer;
        private TournamentLogicLayer tournamentLogicLayer;
        private IHttpContextAccessor httpContextAccessor;

        public SelectList Teams { get; set; }
        public SelectList Tournaments { get; set; }
        public SelectList Locations { get; set; }


        [BindProperty]
        public MatchDTO MatchDTO { get; set; }

        public CreateModel(MatchLogicLayer matchLogicLayer, TeamLogicLayer teamsLogicLayer, TournamentLogicLayer tournamentLogicLayer, IHttpContextAccessor httpContextAccessor, LocationLogicLayer locationLogicLayer)
        {
            this.matchLogicLayer = matchLogicLayer;
            this.teamsLogicLayer = teamsLogicLayer;
            this.tournamentLogicLayer = tournamentLogicLayer;
            this.httpContextAccessor = httpContextAccessor;
            this.locationLogicLayer = locationLogicLayer;
        }

        public void OnGet()
        {
            LoadData();
        }

        public ActionResult OnPost()
        {
            if (MatchDTO.Team1Id == MatchDTO.Team2Id)
            {
                ModelState.AddModelError("MatchDTO.Team2Id", $"Please, choose another team.");
            }
            else
            {
                var team1 = teamsLogicLayer.GetTeamById(new Team(MatchDTO.Team1Id));
                var team2 = teamsLogicLayer.GetTeamById(new Team(MatchDTO.Team2Id));
                var tournament = tournamentLogicLayer.GetTournamentById(new Tournament(MatchDTO.TournamentId));
                var match = new Matches(MatchDTO.Id, MatchDTO.DateOfMatch, MatchDTO.TournamentId,
                                        tournament.TournamentName, MatchDTO.Team1Id, team1.Name, MatchDTO.Team2Id, team2.Name, MatchDTO.LocationId);
                if (!matchLogicLayer.AddNewMatch(match))
                {
                    ModelState.AddModelError("MatchDTO.DateOfMatch", $"Cannot create match with past date or overlaping matches.");
                }
                else
                {
                    TempData["success"] = "Match created successfully";
                    return RedirectToPage("/Match/Match");
                }
            }

            LoadData();
            return Page();
        }

        private void LoadData()
        {
            var role = httpContextAccessor.HttpContext.User.FindFirst("Role").Value;
            var userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst("Id").Value);
            BLL.Models.Users user = new BLL.Models.Users(userId, role);

            var teams = teamsLogicLayer.GetAllTeams();
            Teams = new SelectList(teams.Select(t => new TeamDTO(t)), "Id", "Name");

            var locations = locationLogicLayer.GetAllLocation();
            Locations = new SelectList(locations.Select(t => new LocationDTO(t)), "Id", "Name");

            var tournaments = tournamentLogicLayer.GetAllTournaments(user);
            Tournaments = new SelectList(tournaments.Select(t => new TournamentDTO(t)), "Id", "TournamentName");
        }
    }
}
