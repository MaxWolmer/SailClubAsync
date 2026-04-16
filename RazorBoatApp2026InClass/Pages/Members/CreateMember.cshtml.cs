using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class CreateMemberModel : PageModel
    {
        private Dictionary<string, Member> _members;
        private IMemberRepository _repo;

        private IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public Member NewMember { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        public CreateMemberModel(IMemberRepository memberRepository, IWebHostEnvironment webHost)
        {
            _repo = memberRepository;
            webHostEnvironment = webHost;

        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (Photo != null)
            {
                if (NewMember.MemberImage != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images/MemberImages", NewMember.MemberImage);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                NewMember.MemberImage = ProcessUploadedFile();
            }

            _repo.AddMember(NewMember);
            return RedirectToPage("Index");
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/MemberImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
