using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBoatApp2026InClass.Pages.Boats;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class ChooseBoatModel : PageModel
    {
        private Dictionary<string, Boat> _boats;
        private IBoatRepository _repo;

        public List<Boat> Boats { get; set; }
        [BindProperty]
        public Boat NewBoat { get; set; }
        public string FilterCriteria { get; set; }

        public ChooseBoatModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = _repo.FilterBoats(FilterCriteria);
            }
            else
            Boats = _repo.GetAllBoats();
        }
    }
}
