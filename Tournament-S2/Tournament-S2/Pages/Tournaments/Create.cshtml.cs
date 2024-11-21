using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;
using BLL.TournamentBLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Enum;
using BLL.DTO;
using BLL.TournamentTypeBLL;
using BLL.LocationBLL;

namespace Tournament_Web_Application.Pages.Tournaments
{

    [Authorize]
    public class CreateModel : PageModel
    {
        private TournamentLogicLayer tournamentLogicLayer;
        private TournamentTypeLogicLayer tournamentTypeLogicLayer;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SelectList TournamentType { get; set; }

        [BindProperty]
        public TournamentDTO TournamentDTO { get; set; }

        public CreateModel(TournamentLogicLayer tournamentLogicLayer, IHttpContextAccessor httpContextAccessor, TournamentTypeLogicLayer tournamentTypeLogicLayer)
        {
            this.tournamentLogicLayer = tournamentLogicLayer;
            this.httpContextAccessor = httpContextAccessor;
            this.tournamentTypeLogicLayer = tournamentTypeLogicLayer;
        }

        public void OnGet()
        {
            var tournamentTypes = tournamentTypeLogicLayer.GetAllTournamentType();
            TournamentType = new SelectList(tournamentTypes.Select(t => new TournamentTypeDTO(t)), "Id", "Name");
        }

        public ActionResult OnPost()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
            var user = new BLL.Models.Users { Id = Convert.ToInt32(userId) };
            bool created = tournamentLogicLayer.AddNewTournament(new Tournament(0, TournamentDTO.TournamentName,
                           TournamentDTO.EntryFee, TournamentDTO.PrizePool, TournamentDTO.TournamentTypeId, Convert.ToInt32(userId)),user);

            if (created == false)
            {
                ModelState.AddModelError("Tournament.TournamentName", $"Tournament with name {TournamentDTO.TournamentName} exists! Please, choose a new one.");
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
