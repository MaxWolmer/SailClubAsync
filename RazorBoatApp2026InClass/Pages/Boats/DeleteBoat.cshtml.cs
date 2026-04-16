using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoatRepoAsync _repo;
        public Boat DeleteBoat { get; set; }
        public DeleteBoatModel(IBoatRepoAsync boatRepository)
        {
            _repo = boatRepository;
        }
        public async Task<IActionResult> OnGetAsync(string sailNumber)
        {
            DeleteBoat = await _repo.SearchBoat(sailNumber);
            return Page();
        }
        public IActionResult OnPostDelete(string sailNumber)
        {
            _repo.RemoveBoat(sailNumber);
            return RedirectToPage("Index");
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
