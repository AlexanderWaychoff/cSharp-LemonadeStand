﻿using System;
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

        private string cloudiness;
        private bool isRaining;
        private int temperature;
        Random randomNumber = new Random();
        Conditions todaysWeather = new Conditions("slightly cloudy", false, 75);
        public Weather()
        {

        }
        public List<string> GetTheDaysWeather()
        {
            List<string> allWeather = new List<string>();
            cloudiness = DetermineCloudCover();
            isRaining = IsRaining(cloudiness);
            temperature = DetermineTemperature(isRaining);
            todaysWeather = new Conditions(cloudiness, isRaining, temperature);
            Console.WriteLine("The sky is {0} and it {1}.  The temperature is {2}.", todaysWeather.cloudiness, isRaining ? "is raining" : "is not raining", temperature);
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
        public int DetermineTemperature(bool isRaining)
        {
            int yesterdayTemperature = todaysWeather.temperature;
            int temperature = randomNumber.Next(minTemperature, maxTemperature);

            //if (Math.Abs(yesterdayTemperature - temperature) >= 20)//20 is max temperature change in a single day
            //{ add later if temperature fluctuates too much

            //}
            if (isRaining)
            {
                temperature -= randomNumber.Next(7, 20);
            }
            return temperature;
        }
    }
}
