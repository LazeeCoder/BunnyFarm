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
        public void CanCreateBunny()
        {
            Assert.IsNotNull(myFirstBunny);
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
        public void MyFirstBunnyIsOlderThanZero()
        {
            Assert.IsTrue(myFirstBunny.Age > 0);
        }

    }
}
