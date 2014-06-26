using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BunnyFarm;
using System.Collections.Generic;
using Moq;

namespace BunnyFarmTests
{
    [TestClass]
    public class BunnyFarmTests
    {

        private static List<IBunny> CreateOneYearOldPairOfBunnies()
        {
            return new List<IBunny>() 
            { 
                new Bunny 
                { 
                    Age = 1, 
                    Color = BunnyColor.SPOTTED, 
                    Sex = BunnySex.MALE, 
                    IsRadioActive = false, 
                    Name = "Test Male" 
                }, 
                new Bunny 
                { 
                    Age = 1, 
                    Color = BunnyColor.BLACK, 
                    Sex = BunnySex.FEMALE, 
                    IsRadioActive = false, 
                    Name = "Test Female" 
                } 
            };
        }

        private static List<IBunny> CreateOneOldAndOneYoungBunny()
        {
            return new List<IBunny>() 
            {
                new Bunny
                {
                    Age = 10
                },
                new Bunny
                {
                    Age = 0
                }
            };
        }


        [TestMethod]
        public void AMaleAndFemaleBunnyWillCreateANewBunnyUponAging()
        {
            List<IBunny> mockBunnies = CreateOneYearOldPairOfBunnies();

            Farm myFarm = new Farm(mockBunnies);

            myFarm.AgeBunnies();

            Assert.AreEqual(3, myFarm.Bunnies.Count);
        }

        [TestMethod]
        public void DeceasedBunniesAreRemovedFromTheFarm()
        {
            Farm myFarm = new Farm(CreateOneOldAndOneYoungBunny());

            myFarm.AgeBunnies();

            myFarm.RemoveDeceasedBunnies();

            Assert.AreEqual(1, myFarm.Bunnies.Count);
        }

    }
}
