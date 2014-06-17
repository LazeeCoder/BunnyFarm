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
    public class Bunny
    {
        private const int MINIMUM_START_AGE = 0;
        private const int MAXIMUM_START_AGE = 10;
        private const int RADIO_ACTIVE_TRAIT = 0;

        private string[] FIRST_NAMES = { "Thumper", "Jumper", "Ragnaros", "Reginald", "LeeRoy", "Peter" };
        private string[] LAST_NAMES = { "Jones", "Vader", "Smith", "CottonTail", "Jenkins" };

        public string Name { get; set; }

        public Bunny()
        {
            Name = FIRST_NAMES[GetRandom(0, FIRST_NAMES.Length)] + " " + LAST_NAMES[GetRandom(0, LAST_NAMES.Length)];
            Age = GetRandom(MINIMUM_START_AGE, MAXIMUM_START_AGE);
            Sex = (BunnySex)GetRandom(0, Enum.GetValues(typeof(BunnySex)).Length);
            Color = (BunnyColor)GetRandom(0, Enum.GetValues(typeof(BunnyColor)).Length);
            IsRadioActive = HasRadioActiveTrait();

        }

        private bool HasRadioActiveTrait()
        {
            int radioActiveGene = GetRandom(0,50);
            return radioActiveGene == RADIO_ACTIVE_TRAIT; // a 0 in 50 = 2% chance of getting trait
        }

        public int Age { get; set; }

        public BunnySex Sex { get; set; }

        public BunnyColor Color { get; set; }

        public bool IsRadioActive { get; set; }

        public int GetRandom(int minValue, int maxValue)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            return random.Next(minValue, maxValue);
        }
    }
}
