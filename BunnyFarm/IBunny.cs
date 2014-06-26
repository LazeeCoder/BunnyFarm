using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BunnyFarm
{
    public interface IBunny
    {
        string Name { get; set; }

        int Age { get; set; }

        BunnySex Sex { get; set; }

        BunnyColor Color { get; set; }

        bool IsRadioActive { get; set; }

        BunnyState State { get; set; }

        void AgeOneYear();

        Bunny CreateBunny(IBunny daddyBunny);
    }
}
