using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private IBookingRepository bkRepo;
        public List<Booking> Bookings { get; set; }
        public IndexModel(IBookingRepository bookingRepository)
        {
            bkRepo = bookingRepository;
        }
        public void OnGet()
        {
            Bookings = bkRepo.GetAllBookings();
        }
    }
}
