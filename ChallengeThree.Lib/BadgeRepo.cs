using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Lib
{
    //class that defines drud operations on the badge objects, "saving" them to a local collection.

    public class BadgeRepo
    {
        //local list for managing collection of badges
        Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();
        //CRUD and helper methods for working with badge 

        //Create a badge (add to the list)

        public bool CreateBadge(Badge b)
        {
            if (b != null)
            {
                _badgeRepo.Add(b.BadgeId, b.Doors);
                return true;
            }
            return false;
        }

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeRepo;
        }
        public Badge UpdateABadge(Badge b)
        {
            return b;
        }
    }
}
