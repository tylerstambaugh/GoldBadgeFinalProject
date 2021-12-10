using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Lib
{
    class ClaimRepo
    {

        // manage the local "claims" objects and have their CRUD operations / helper methods in this class.
        private readonly List<Claim> _claimRepo = new List<Claim>();

        //Create
        public bool CreateClaim(Claim c)
        {
            if (c != null)
            {
                int repoLengthBeforeAdd = _claimRepo.Count;
                _claimRepo.Add(c);
                int repoLengthAfterAdd = _claimRepo.Count;
                if(repoLengthBeforeAdd == repoLengthAfterAdd - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false ;
            }
        }

        //Read (out) single/multiple claims.

        // Update a claim

        //Delete a claim

        //Seed Data?

    }
}
