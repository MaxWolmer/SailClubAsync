using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBookingRepository _repo;
        private IBoatRepository _bRepo;
        private IMemberRepository _mRepo;


        [BindProperty]
        public Booking NewBooking { get; set; }
        [BindProperty]
        public Boat NewBoat { get; set; }
        [BindProperty]
        public Member NewMember { get; set; }
        [BindProperty]
        public int NewId { get; set; }
        [BindProperty]
        public string NewPhone { get; set; }
        [BindProperty]
        public string NewDestination { get; set; }
        [BindProperty]
        public bool NewSailCompleted { get; set; }
        [BindProperty]
        public DateTime NewStartDate{ get; set; }
        [BindProperty]
        public DateTime NewEndDate { get; set; }

        public CreateBookingModel(IBookingRepository bookingRepository, IBoatRepository boatRepository, IMemberRepository memberRepository)
        {
            _repo = bookingRepository;
            _bRepo = boatRepository;
            _mRepo = memberRepository;
        }
        public void OnGet(string SailNumber)
        {
            NewBoat = _bRepo.SearchBoat(SailNumber);
        }

        public IActionResult OnPost(string SailNumber)
        {
            Member m = _mRepo.SearchMember(NewPhone);
            NewBoat = _bRepo.SearchBoat(SailNumber);
            Booking b = new Booking(NewId, NewStartDate, NewEndDate, NewDestination, m, NewBoat);
            _repo.AddBooking(b);
            return RedirectToPage("Index");
        }
    }
}
