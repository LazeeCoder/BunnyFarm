using BunnyFarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyFarmConsole
{
    class Program
    {
        static Farm myFarm;
        static void Main(string[] args)
        {
            Console.WriteLine("Hit any key to Begin?");

            Console.ReadLine();

            myFarm = new Farm(CreateFiveBunnies());

            do
            {
                Console.WriteLine("Current Bunny Population: "+ myFarm.Bunnies.Count.ToString() + "\n");
                
                PrintBunnies();

                myFarm.AgeBunnies();

                RemoveDeceasedBunnies();


                Console.WriteLine("\nHit a key to progress One year.");
                Console.ReadLine();

            } while (myFarm.Bunnies.Count != 0);


        }

        private static void RemoveDeceasedBunnies()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (IBunny bunny in myFarm.Bunnies.Where(b => b.State == BunnyState.DECEASED))
            {
                Console.WriteLine(bunny.Name + " Has died and will be disposed of.");
            }

            myFarm.RemoveDeceasedBunnies();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintBunnies()
        {
            foreach (IBunny bunny in myFarm.Bunnies)
            {
                if (bunny.State == BunnyState.NEWBORN)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(bunny.ToString() + " Was Born!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (bunny.IsRadioActive)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(bunny.ToString() + " Is RadioActive");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(bunny.ToString());
                    System.Threading.Thread.Sleep(250);
                }
            }
        }

        private static List<IBunny> CreateFiveBunnies()
        {
            List<IBunny> initialPopulation = new List<IBunny>();

            for (int i = 0; i < 5; i++)
            {
                initialPopulation.Add(new Bunny());
            }

            return initialPopulation;
        }

    }
}
