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

        //Read (out) multiple claims.
        public Queue<Claim> GetAllClaims()
        {
            return _claimRepo;
        }

        //read out next claim
        public Claim GetNextClaim()
        {
            if (_claimRepo.Count > 0)
            {
                return _claimRepo.Peek();
            }
            else
            {
                return null;
            }
        }

        //Delete a claim
        public bool HandleClaim()
        {
            if (_claimRepo.Count > 0)
            {
                _claimRepo.Dequeue();
                return true;
            }
            else
            {
                return false;
            }

        }

        //return true if the claim date is less than 30 days after the incident date. 
        public bool IsClaimValid(DateTime incidentDate, DateTime claimDate)
        {
            if (claimDate > incidentDate.AddDays(30))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SeedData()
        {
            Claim claimOne = new Claim(1, (Claim.ClaimType)1, "TestClaim 1", 4250.00m, new DateTime(2021, 01, 15), new DateTime(2021, 12, 07), true);
            Claim claimTwo = new Claim(2, (Claim.ClaimType)2, "TestClaim 2", 1654.90m, new DateTime(2021, 11, 25), new DateTime(2021, 12, 07), true);
            Claim claimThree = new Claim(3, (Claim.ClaimType)3, "TestClaim 3", 478.00m, new DateTime(2021, 11, 15), new DateTime(2021, 12, 04), true);
            _claimRepo.Enqueue(claimOne);
            _claimRepo.Enqueue(claimTwo);
            _claimRepo.Enqueue(claimThree);

        }
       
        
    }
}
