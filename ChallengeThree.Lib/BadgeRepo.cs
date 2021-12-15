﻿using System;
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

        //Takes a badge built in the UI and adds it to the list after checking that the ID doesn't already exist.

        public bool CreateBadge(Badge b)
        {
            int countBeforeAdd = _badgeRepo.Count;
            if (!_badgeRepo.ContainsKey(b.BadgeId) && b != null)
            {
                _badgeRepo.Add(b.BadgeId, b.Doors);
                if (countBeforeAdd == (_badgeRepo.Count - 1))
                return true;
            }
            return false;
        }

        //just returns the field (dictionary of badges) above to the UI for handling.
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeRepo;
        }

        //checks to see if the badge exists and if the door exists on that badge before removing it.
        public bool RemoveDoorFromBadge(int badgeNumber, string doorToRemove)
        {
            if (_badgeRepo.ContainsKey(badgeNumber) && doorToRemove != null && _badgeRepo[badgeNumber].Contains(doorToRemove))
            {
                _badgeRepo[badgeNumber].Remove(doorToRemove);
                return true;
             }
            else
            {
                return false;
            }
             
        }

        //returns true if it can find the badge and add the string to the list of existing doors, otherwise returns false.
        public bool AddDoorToBadge(int badgeNumber, string doorToAdd)
        {
            if (_badgeRepo.ContainsKey(badgeNumber) && doorToAdd != null)
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


        //returns true if the local repo has the badge and sets the "value" of the dictionary item equal to an empty list of type string, else returns false.
        public bool DemoveAllDoorsFromBadge(int badgeNumber)
        {
            if (_badgeRepo.ContainsKey(badgeNumber))
            {
                List<string> emtpyListOfDoors = new List<string>();
                _badgeRepo[badgeNumber] = emtpyListOfDoors;
                return true;
            }
            else
            {
                return false;
            }

        }

        //helper method to see if a badge exists in the dictionary.
        public bool BadgeExists(int badgeNumber)
        {
            if (_badgeRepo.ContainsKey(badgeNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
