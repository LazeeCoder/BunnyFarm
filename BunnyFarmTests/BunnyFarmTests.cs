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
        private List<IBunny> mockBunnies;

        [TestInitialize]
        public void Initialize()
        {
            mockBunnies = new List<IBunny>();

            mockBunnies.Add(new Bunny { Age = 1, Color = BunnyColor.SPOTTED, Sex = BunnySex.MALE, IsRadioActive = false, Name = "Test Male" });
            mockBunnies.Add(new Bunny { Age = 1, Color = BunnyColor.BLACK, Sex = BunnySex.FEMALE, IsRadioActive = false, Name = "Test Female" });
        }


        [TestMethod]
        public void AMaleAndFemaleBunnyWillCreateANewBunnyUponAging()
        {
            Farm myFarm = new Farm(mockBunnies);

            myFarm.AgeBunnies();

            Assert.AreEqual(3, myFarm.Bunnies.Count);


        }
    }
}
