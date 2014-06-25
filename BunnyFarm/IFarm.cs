using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyFarm
{
    public interface IFarm
    {
        List<IBunny> Bunnies { get; set; }
        void AgeBunnies();
    }
}
