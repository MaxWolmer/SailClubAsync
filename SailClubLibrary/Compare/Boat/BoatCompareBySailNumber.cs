using SailClubLibrary.Models;

namespace SailClubLibrary.Compare.Boats
{
    public class BoatCompareBySailNumber : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null && y == null) return 0;
            if (x != null && y == null) return 1;
            if (x == null && y != null) return -1;

            // Use string.Compare to compare SailNumber, handling possible nulls
            return string.Compare(x.SailNumber, y.SailNumber, StringComparison.Ordinal);
        }
    }
}