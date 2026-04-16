using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class DeleteMemberModel : PageModel
    {
        private IMemberRepository _repo;
        public Member DeleteMember { get; set; }
        public DeleteMemberModel(IMemberRepository memberRepository)
        {
            _repo = memberRepository;
        }

        public IActionResult OnGet(string phoneNumber)
        {
            DeleteMember = _repo.SearchMember(phoneNumber);
            return Page();
        }

        public IActionResult OnPostDelete(string phoneNumber)
        {
            _repo.RemoveMember(phoneNumber);
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
