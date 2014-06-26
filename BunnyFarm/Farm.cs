using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyFarm
{
    public class Farm : IFarm
    {
        private const int LEGAL_BREADING_AGE = 1;

        public List<IBunny> Bunnies { get; set; }

        public Farm()
        {

        }

        public Farm(List<IBunny> bunnies)
        {
            Bunnies = bunnies;
        }

        public void AgeBunnies()
        {
            foreach (IBunny bunny in Bunnies)
            {
                bunny.AgeOneYear();
            }

            ReproduceBunnies();
        }

        private void ReproduceBunnies()
        {
            if (Bunnies.Count(b => b.Age > LEGAL_BREADING_AGE && b.Sex == BunnySex.MALE  && !b.IsRadioActive) > 0)
            {
                foreach (IBunny bunny in Bunnies.Where(b => b.Sex == BunnySex.FEMALE 
                            && b.Age > LEGAL_BREADING_AGE && !b.IsRadioActive).ToList<IBunny>())
                {
                    Bunnies.Add(bunny.CreateBunny(Bunnies.First(b => b.Age > 1 && b.Sex == BunnySex.MALE)));
                }
            }

        }

        public void RemoveDeceasedBunnies()
        {
            Bunnies.RemoveAll(b => b.State == BunnyState.DECEASED);
        }
    }
}
