using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Lib
{
    // class to handle the badge object, defines it's properties and constructors.
    public class Badge
    {
        public int BadgeId { get; set; }
        public List<string> Doors { get; set; }
        //Defined in the assignment but no usage given.
        public string BadgeName { get; set; }

        public Badge() { }

        public Badge(int badgeId, List<string> doors)
        {
            BadgeId = badgeId;
            Doors = doors;
           // BadgeName = badgeName;
        }
    }
}
