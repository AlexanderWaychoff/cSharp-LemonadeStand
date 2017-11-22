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
        private int gauranteedRain = 3;
        private int maxTemperature = 110;
        private int minTemperature = 65;
        private bool isRaining = false;
        Random randomNumber = new Random();
        public Weather()
        {

        }
        public List<string> GetTheDaysWeather()
        {
            List<string> allWeather = new List<string>();
            allWeather.Add(DetermineCloudCover());
            IsRaining(allWeather[0]);
            Console.WriteLine("The sky is {0}.", allWeather[0]);
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
            return odds;
        }
        public bool IsRaining(string clouds)
        {
            int indexOfSky = weatherType.IndexOf(clouds);
            int catchRandomNumber;
            if (indexOfSky > possiblyAdjustRainChance)
            {
                catchRandomNumber = randomNumber.Next(10);
                if (indexOfSky == gauranteedRain)
                {
                    if (catchRandomNumber < 9) //< 9 = 90% chance of rain on the worst weather
                    {
                        return true;
                    }
                }
                else
                {
                    if (catchRandomNumber < 5) //< 5 = 50% chance of rain on conditions slightly worse than the worst
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string DetermineTemperature()
        {
            int temperature = randomNumber.Next(minTemperature, maxTemperature);
            //reduce if raining is true
            return "1";
        }
    }
}
