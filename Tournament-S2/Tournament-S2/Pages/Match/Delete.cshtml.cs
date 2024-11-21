using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using BLL.MatchBLL;
using BLL.Models;
using BLL.DTO;
namespace Tournament_Web_Application.Pages.Match
{

    [Authorize]
    public class DeleteModel : PageModel
    {
        private MatchLogicLayer matchLogicLayer;

        [BindProperty]
        public MatchDTO MatchDTO { get; set; }

        public DeleteModel(MatchLogicLayer matchLogicLayer)
        {
            this.matchLogicLayer = matchLogicLayer;
        }

        public void OnGet(int id)
        {
            var match = matchLogicLayer.GetMatchById(new Matches(id));
            MatchDTO = new MatchDTO(match);
        }

        public ActionResult OnPost()
        {
            var match = new Matches(MatchDTO.Id);
            matchLogicLayer.DeleteMatch(match);
            TempData["success"] = "Match deleted successfully";
            return RedirectToPage("/Match/Match");
        }
    }
}
