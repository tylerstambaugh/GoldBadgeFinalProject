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
        public bool RemoveDoorFromBadge(int badgeNumber, string doorToRemove)
        {
            if (doorToRemove != null)
            {
                List<string> newListOfDoors = new List<string>();
                List<string> listOfOriginalDoors = _badgeRepo[badgeNumber];

                foreach(string door in listOfOriginalDoors)
                {
                    if (door != doorToRemove)
                    {
                        newListOfDoors.Add(door);
                    }
                }
                _badgeRepo[badgeNumber] = newListOfDoors;
                return true;
            }
            else
            {
            return false;
            }
        }

        public bool AddDoorToBadge(int badgeNumber, string doorToAdd)
        {
            if (doorToAdd != null)
            {
                List<string> listOfDoors = _badgeRepo[badgeNumber];
                listOfDoors.Add(doorToAdd);
                _badgeRepo[badgeNumber] = listOfDoors;

                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
