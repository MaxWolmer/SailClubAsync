using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using SailClubLibrary.Services;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class IndexModel : PageModel
    {
        private IMemberRepository mRepo;

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortFilterCriteria { get; set; }

        public List<Member> Members { get; set; }

        public IndexModel(IMemberRepository memberRepository)
        {
            mRepo = memberRepository;
            SortBy = "asc";
        }

        //Hvis vi skal vise noget bruger vi OnGet() metode.
        //Man kan bruge OnPost hvis man skal gemme noget tror jeg?
        //Der er i hvert fald de to metoder man kan bruge i denne slags fil vi er i.
        public void OnGet(string searchTerm)
        {
            List<Member> allMembers = mRepo.GetAllMembers();
            if (string.IsNullOrEmpty(searchTerm))
            {
                Members = allMembers;
            }
            else
            {
                List<Member> searchResults = new List<Member>();
                foreach (Member member in allMembers)
                {
                    if (member.PhoneNumber != null && member.PhoneNumber.Contains(searchTerm) ||
                        member.FirstName != null && member.FirstName.ToLower().Contains(searchTerm.ToLower()))
                    {
                        searchResults.Add(member);
                    }
                }
                Members = searchResults;
                Members = SortMembers(Members);
            }
            //Members = mRepo.GetAllMembers();
        }

        public string Toggle(string column)
        {
            if (SortOrder == "asc" && SortBy == column)
            {
                return "desc";
            }
            return "asc";
        }

        List<Member> SortMembers(List<Member> members)
        {
            switch (SortBy)
            {
                case "PhoneNumber":
                    members.Sort();
                    break;
                case "FirstName":
                    members.Sort(new MemberCompareName());
                    break;
                default:
                    break;
            }
            if (SortOrder != "asc") Members.Reverse();

            return members;
        }

        //public IActionResult GetMember(string phoneNumber)
        //{
        //    mRepo.SearchMember(phoneNumber);
        //    return RedirectToPage("Index");
        //}
    }
}
