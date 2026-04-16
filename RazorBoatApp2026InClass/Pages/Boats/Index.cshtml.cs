using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Compare;
using SailClubLibrary.Compare.Boats;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private IBoatRepoAsync bRepo;
        public List<Boat> Boats { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        public IndexModel(IBoatRepoAsync boatRepository)
        {
            bRepo = boatRepository;
        }

        //Hvis vi skal vise noget bruger vi OnGet() metode.
        //Man kan bruge OnPost hvis man skal gemme noget tror jeg?
        //Der er i hvert fald de to metoder man kan bruge i denne slags fil vi er i.
        //Opdatering: Jeg huskede rigtigt.
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = bRepo.FilterBoats(FilterCriteria);
            }
            else
                Boats = await bRepo.GetAllBoats();
            Boats = BoatSort(Boats);
        }

        private List<Boat> BoatSort(List<Boat> boats)
        {
            switch (SortBy)
            {
                case "Id":
                    boats.Sort();
                    break;
                case "SailNumber":
                    boats.Sort(new BoatCompareBySailNumber());
                    break;
                case "YearOfConstruction":
                    boats.Sort(new BoatCompareByYear());
                    break;
                default:
                    break;
            }
            return boats;
        }
    }
}
