using BLL.TournamentBLL;
using BLL.Models;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using BLL.TournamentTypeBLL;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.LocationBLL;

namespace Tournament_Web_Application.Pages.Tournaments
{

    [Authorize]
    public class EditModel : PageModel
    {
        private TournamentLogicLayer tournamentLogicLayer;
        private TournamentTypeLogicLayer tournamentTypeLogicLayer;

        public SelectList TournamentsType { get; set; }

        [BindProperty]
        public TournamentDTO TournamentDTO { get; set; }

        public EditModel(TournamentLogicLayer tournamentLogicLayer, TournamentTypeLogicLayer tournamentTypeLogicLayer)
        {
            this.tournamentLogicLayer = tournamentLogicLayer;
            this.tournamentTypeLogicLayer = tournamentTypeLogicLayer;
        }

        public void OnGet(int id)
        {
            var tournament = tournamentLogicLayer.GetTournamentById(new Tournament(id));
            TournamentDTO = new TournamentDTO(tournament);

            var tournamentTypes = tournamentTypeLogicLayer.GetAllTournamentType();
            TournamentsType = new SelectList(tournamentTypes, "Id", "Name", TournamentDTO.TournamentTypeId);
        }

        public ActionResult OnPost()
        {
            var tournament = new Tournament(TournamentDTO.Id, TournamentDTO.TournamentName, TournamentDTO.EntryFee,
                TournamentDTO.PrizePool, TournamentDTO.TournamentTypeId, TournamentDTO.UserId);
            tournamentLogicLayer.UpdateTournament(tournament);
            TempData["success"] = "Tournament updated successfully";
            return RedirectToPage("/Tournaments/Tournament");
        }
    }
}
