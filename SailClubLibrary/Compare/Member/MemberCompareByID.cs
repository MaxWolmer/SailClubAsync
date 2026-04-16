using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SailClubLibrary.Models;

namespace SailClubLibrary.Compare.Members
{
    public class MemberCompareByID : IComparer<Member>
    {
        public int Compare(Member? x,Member? y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}
