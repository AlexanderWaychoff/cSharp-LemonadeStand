using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        List<string> weatherType = new List<string>() { "clear of clouds", "slightly cloudy", "overcast", "stormy"};
        private int amountOfWeatherConditions = 4;
        private int possiblyAdjustRainChance = 2;
        private int adjustRainChance = 1;
        Random randomNumber = new Random();
        public Weather()
        {

        }
        public List<string> GetTheDaysWeather()
        {
            DetermineCloudCover();
            return weatherType;//remove later
        }
        public string DetermineCloudCover()
        {
            int weatherCondition = randomNumber.Next(amountOfWeatherConditions);
            weatherCondition = ReduceChanceOfRain(weatherCondition);
            return weatherType[weatherCondition];
        }
        public int ReduceChanceOfRain(int odds)
        {
            int catchRandomNumber;
            if(odds > possiblyAdjustRainChance)
            {
                catchRandomNumber = randomNumber.Next(possiblyAdjustRainChance);
                if (catchRandomNumber > adjustRainChance)
                {
                    odds -= adjustRainChance;
                }
            }
            Console.WriteLine(odds);
            return odds;
        }
    }
}
