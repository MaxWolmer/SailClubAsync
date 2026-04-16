using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class BoatCompareByID : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null && y == null) return 0;
            if (x != null && y == null) return 1;
            if (x == null && y != null) return -1;

            if (x.Id > y.Id) return 1;
            if (x.Id < y.Id) return -1;

            return 0;
        }
    }
}