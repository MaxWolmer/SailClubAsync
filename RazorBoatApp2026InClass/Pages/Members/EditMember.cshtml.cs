using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class EditMemberModel : PageModel
    {
        private IMemberRepository _repo;
        [BindProperty]
        public Member MemberToUpdate { get; set; }
        public EditMemberModel(IMemberRepository memberRepository)
        {
            _repo = memberRepository;
        }
        public void OnGet(string phoneNumber)
        {
            MemberToUpdate = _repo.SearchMember(phoneNumber);
        }
        public IActionResult OnPostUpdate()
        {
            _repo.UpdateMember(MemberToUpdate);
            return RedirectToPage("Index");
        }
        public IActionResult OnPostDelete()
        {
            _repo.RemoveMember(MemberToUpdate.PhoneNumber);
            return RedirectToPage("Index");
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
