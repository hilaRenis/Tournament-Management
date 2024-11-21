using BLL.TournamentBLL;
using BLL.Models;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Tournament_Web_Application.Pages.Tournaments
{

    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly TournamentLogicLayer tournamentLogicLayer;

        [BindProperty]
        public TournamentDTO TournamentDTO { get; set; }

        public DeleteModel(TournamentLogicLayer tournamentLogicLayer) 
        {
            this.tournamentLogicLayer = tournamentLogicLayer;
        }

        public void OnGet(int id)
        {
            var tournament = tournamentLogicLayer.GetTournamentById(new Tournament(id));
            TournamentDTO = new TournamentDTO(tournament);
        }

        public ActionResult OnPost()
        {
            var tournament = new Tournament(TournamentDTO.Id);
            tournamentLogicLayer.DeleteTournament(tournament);
            TempData["success"] = "Tournament deleted successfully";
            return RedirectToPage("/Tournaments/Tournament");
        }
    }
}
