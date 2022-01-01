using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Lib
{

    //CRUD operation on local menu object
    public class MenuRepo
    {
        private readonly List<MenuItem> _menuRepo = new List<MenuItem>();

        public List<MenuItem> GetMenuItems()
        {
            return _menuRepo;
        }

        public bool addItemToMenu(MenuItem m)
        {
            if (m != null)
            {
                _menuRepo.Add(m);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteMenuItem(MenuItem itemToDelete)
        {
            if (itemToDelete != null)
            {
                _menuRepo.Remove(itemToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
