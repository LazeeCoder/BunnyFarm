using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyFarm
{
    public class Bunny
    {
        public string Name { get; set; }
     
        public Bunny()
        {
            Name = "Frodo";
            Age = 1;
        }

        public int Age { get; set; }
    }
}
