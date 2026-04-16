using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class MemberCompareName : IComparer<Member>
    {
        public int Compare(Member? x, Member? y)
        {
            if (x == null && y == null) return 0;
            if (x != null && y == null) return 1;
            if (x == null && y != null) return -1;

            return string.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal);
        }
    }
}