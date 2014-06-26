using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyFarm
{
    public enum BunnySex
    {
        MALE,
        FEMALE
    }

    public enum BunnyColor
    {
        WHITE,
        BROWN,
        BLACK,
        SPOTTED
    }

    public enum BunnyState
    {
        NEWBORN,
        MATURE,
        DECEASED
    }

    public class Bunny : IBunny
    {
        #region Constants/Privates/Properties

        private const int MINIMUM_START_AGE = 0;
        private const int MAXIMUM_START_AGE = 10;
        private const int RADIO_ACTIVE_TRAIT = 0;
        private const int LEGAL_BREADING_AGE = 1;
        private static Random random = new Random(DateTime.Now.Millisecond);


        private string[] FIRST_NAMES = { "Thumper", "Jumper", "Ragnaros", "Reginald", "LeeRoy", "Peter" };
        private string[] LAST_NAMES = { "Jones", "Vader", "Smith", "CottonTail", "Jenkins" };

        public string Name { get; set; }

        public int Age { get; set; }

        public BunnySex Sex { get; set; }

        public BunnyColor Color { get; set; }

        public bool IsRadioActive { get; set; }

        public BunnyState State { get; set; }

        #endregion

        #region Constructors

        public Bunny()
        {
            Name = GetBunnyName();
            Age = GetRandom(MINIMUM_START_AGE, MAXIMUM_START_AGE);
            Sex = GetBunnySex();
            Color = (BunnyColor)GetRandom(0, Enum.GetValues(typeof(BunnyColor)).Length);
            IsRadioActive = HasRadioActiveTrait();
            State = BunnyState.MATURE;
        }

        #endregion

        #region Public Methods

        public void AgeOneYear()
        {
            AgeBunny();
            KillOldBunnies();
        }

        public Bunny CreateBunny(IBunny daddyBunny)
        {
            if (this.Sex == BunnySex.FEMALE && this.Age > LEGAL_BREADING_AGE && !this.IsRadioActive
                && daddyBunny.Sex == BunnySex.MALE && daddyBunny.Age > LEGAL_BREADING_AGE && !daddyBunny.IsRadioActive)
            {
                return new Bunny { Age = 0, Color = this.Color, Sex = GetBunnySex(), Name = GetBunnyName(), State = BunnyState.NEWBORN };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Private Methods

        private string GetBunnyName()
        {
            return FIRST_NAMES[GetRandom(0, FIRST_NAMES.Length)] + " " + LAST_NAMES[GetRandom(0, LAST_NAMES.Length)];
        }

        private BunnySex GetBunnySex()
        {
            return (BunnySex)GetRandom(0, Enum.GetValues(typeof(BunnySex)).Length);
        }

        private bool HasRadioActiveTrait()
        {
            int radioActiveGene = GetRandom(0, 50);
            return radioActiveGene == RADIO_ACTIVE_TRAIT; // a 0 in 50 = 2% chance of getting trait
        }

        private int GetRandom(int minValue, int maxValue)
        {
            //Random random = new Random(DateTime.Now.Millisecond);

            return random.Next(minValue, maxValue);
        }

        private void AgeBunny()
        {
            Age += 1;
            State = BunnyState.MATURE;
        }

        private void KillOldBunnies()
        {
            if (IsOldNormalBunny() || IsOldRadioActiveBunny())
            {
                State = BunnyState.DECEASED;
            }
        }

        private bool IsOldRadioActiveBunny()
        {
            return Age > 50 && IsRadioActive;
        }

        private bool IsOldNormalBunny()
        {
            return Age > 10 && !IsRadioActive;
        }

        #endregion

        public override string ToString()
        {
            return Name + " Age: " + Age.ToString() +
                " Color: " + Color.ToString() + " Sex: " + Sex.ToString();
        }
    }
}
