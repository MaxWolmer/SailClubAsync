using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class BoatCompareByYear : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null && y == null) return 0;
            if (x != null && y == null) return 1;
            if (x == null && y != null) return -1;

            return string.Compare(x.YearOfConstruction, y.YearOfConstruction, StringComparison.Ordinal);
        }
    }
}