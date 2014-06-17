using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BunnyFarm;

namespace BunnyFarmTests
{
    [TestClass]
    public class BunnyTests
    {
        private Bunny myFirstBunny;

        [TestInitialize]
        public void InitializeBunny()
        {
            myFirstBunny = new Bunny();
        }

        [TestMethod]
        public void MyFirstBunnyHasAName()
        {
            Assert.IsNotNull(myFirstBunny.Name);
        }

        [TestMethod]
        public void MyFirstBunnyHasAnAge()
        {
            Assert.IsInstanceOfType(myFirstBunny.Age, typeof(int));
        }

        [TestMethod]
        public void MyFirstBunnysAgesIsBetweenZeroAndTen()
        {
            Assert.IsTrue(myFirstBunny.Age > -1 && myFirstBunny.Age < 11);
        }

        [TestMethod]
        public void MyFirstBunnyHasASex()
        {
            Assert.IsInstanceOfType(myFirstBunny.Sex, typeof(BunnySex));
        }

        [TestMethod]
        public void MyFirstBunnyHasAColor()
        {
            Assert.IsInstanceOfType(myFirstBunny.Color, typeof(BunnyColor));
        }

        [TestMethod]
        public void MyFirstBunnyCanBeRadioActive()
        {
            Assert.IsInstanceOfType(myFirstBunny.IsRadioActive, typeof(bool));
        }
    }
}
