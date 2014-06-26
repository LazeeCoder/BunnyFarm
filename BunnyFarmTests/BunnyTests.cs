using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BunnyFarm;

namespace BunnyFarmTests
{
    [TestClass]
    public class BunnyTests
    {
        #region TestSetup

        private Bunny myFirstBunny;

        [TestInitialize]
        public void InitializeBunny()
        {
            myFirstBunny = new Bunny();
        }

        #endregion

        #region Property Tests

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

        #endregion

        #region Aging Tests

        [TestMethod]
        public void MyBunnyCanAgeOneYear()
        {
            int age = myFirstBunny.Age;

            myFirstBunny.AgeOneYear();

            Assert.AreEqual(age + 1, myFirstBunny.Age);
        }

        [TestMethod]
        public void ABunnyWillBecomeDeceasedOnceItTurnsEleven()
        {
            Bunny oldBunny = new Bunny();
            oldBunny.Age = 10;
            oldBunny.AgeOneYear();
            Assert.AreEqual(BunnyState.DECEASED, oldBunny.State);
        }

        [TestMethod]
        public void BabyBunniesBecomeMatureAfterAging()
        {
            Bunny babyBunny = CreateFemale().CreateBunny(CreateMale());
            babyBunny.AgeOneYear();

            Assert.AreEqual(BunnyState.MATURE, babyBunny.State);
        }

        [TestMethod]
        public void RadioActiveBunniesLiveForFiftyYears()
        {
            Bunny radioActiveBunny = CreateRadioActiveBunny(10);

            for (int i = 0; i < 40; i++)
            {
                radioActiveBunny.AgeOneYear();
                Assert.AreEqual(BunnyState.MATURE, radioActiveBunny.State);
            }

            Assert.AreEqual(50, radioActiveBunny.Age);
        }

        [TestMethod]
        public void RadioActiveBunniesBecomeDeceasedAfterFiftyYears()
        {
            Bunny oldRadioActiveBunny = CreateRadioActiveBunny(50);

            oldRadioActiveBunny.AgeOneYear();

            Assert.AreEqual(BunnyState.DECEASED, oldRadioActiveBunny.State);
            Assert.AreEqual(51, oldRadioActiveBunny.Age);
        }


        #endregion

        #region Reproductive Tests

        [TestMethod]
        public void AFemaleBunnyOlderThanOneCanMakeABunnyWithAMaleBunny()
        {
            Bunny male = CreateMale();
            Bunny female = CreateFemale();

            Bunny babyBunny = female.CreateBunny(male);

            Assert.IsNotNull(babyBunny);
            Assert.AreEqual(female.Color, babyBunny.Color);
            Assert.AreEqual(BunnyState.NEWBORN, babyBunny.State);
        }

        [TestMethod]
        public void RadioActiveBunniesDoNotReproduce()
        {
            Bunny female = CreateFemale();
            Bunny radioActive = CreateRadioActiveBunny(2);

            radioActive.Sex = BunnySex.MALE;

            Bunny noBaby = female.CreateBunny(radioActive);

            Assert.IsNull(noBaby);
        }

        [TestMethod]
        public void FemaleRadioActiveBunniesDoNotReproduce()
        {
            Bunny radioActiveFemale = CreateFemale();
            radioActiveFemale.IsRadioActive = true;

            Bunny noBabyBunny = radioActiveFemale.CreateBunny(CreateMale());

            Assert.IsNull(noBabyBunny);
        }

        #endregion

        [TestMethod]
        public void MyBunnysToStringMethodReturnsData()
        {
            Assert.AreEqual(myFirstBunny.Name + " Age: " + myFirstBunny.Age.ToString()
                        + " Color: " + myFirstBunny.Color.ToString() + " Sex: " + myFirstBunny.Sex.ToString(),
                        myFirstBunny.ToString());
        }

        #region Private Methods

        private static Bunny CreateMale()
        {
            Bunny male = new Bunny
            {
                Age = 2,
                Color = BunnyColor.SPOTTED,
                Sex = BunnySex.MALE,
                IsRadioActive = false,
                Name = "Test Male"
            };
            return male;
        }

        private static Bunny CreateFemale()
        {
            Bunny female = new Bunny
            {
                Age = 2,
                Color = BunnyColor.BLACK,
                Sex = BunnySex.FEMALE,
                IsRadioActive = false,
                Name = "Test Female"
            };
            return female;
        }

        private static Bunny CreateRadioActiveBunny(int age)
        {
            Bunny oldRadioActiveBunny = new Bunny
            {
                Age = age,
                IsRadioActive = true
            };
            return oldRadioActiveBunny;
        }

        #endregion
    }
}
