using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Lib
{
    public class ClaimRepo
    {

        // manage the local "claims" objects and have their CRUD operations / helper methods in this class.
        private readonly Queue<Claim> _claimRepo = new Queue<Claim>();

        //Create
        public bool CreateClaim(Claim claimToCreate)
        {
            if (claimToCreate != null)
            {
                int repoLengthBeforeAdd = _claimRepo.Count;
                _claimRepo.Enqueue(claimToCreate);
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

        public Queue<Claim> GetAllClaims()
        {
            return _claimRepo;
        }

        //Read (out) single/multiple claims.

        // Update a claim

        //Delete a claim

        //Seed Data?

    }
}
