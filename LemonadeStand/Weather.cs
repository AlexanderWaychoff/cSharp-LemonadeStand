﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        List<string> weatherConditions = new List<string>() { "clear of clouds", "slightly cloudy", "overcast", "stormy"};
        private int amountOfWeatherConditions = 4;
        private int possiblyAdjustRainChance = 2;
        private int adjustRainChance = 1;
        private int gauranteedRain = 3;
        private int maxTemperature = 110;
        private int minTemperature = 65;

        private string cloudiness;
        private bool isRaining;
        private double temperature;
        Random randomNumber = new Random();
        Conditions todaysWeather = new Conditions("slightly cloudy", false, 75);
        List<Conditions> forecast = new List<Conditions>();
        private int lengthOfForecast = 3;
        public Weather()
        {

        }
        public Conditions GetTheDaysWeather()
        {
            cloudiness = DetermineCloudCover();
            isRaining = IsRaining(cloudiness);
            temperature = DetermineTemperature(isRaining);
            todaysWeather = new Conditions(cloudiness, isRaining, temperature);
            return todaysWeather;
        }
        public string DetermineCloudCover()
        {
            int weatherCondition = randomNumber.Next(amountOfWeatherConditions);
            weatherCondition = ReduceChanceOfRain(weatherCondition);
            return weatherConditions[weatherCondition];
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
            int indexOfSky = weatherConditions.IndexOf(clouds);
            int catchRandomNumber;
            if (indexOfSky >= possiblyAdjustRainChance)
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
        public double DetermineTemperature(bool isRaining)
        {
            double yesterdayTemperature = todaysWeather.Temperature;
            double temperature = randomNumber.Next(minTemperature, maxTemperature);

            if (isRaining)
            {
                temperature -= randomNumber.Next(7, 20);
            }
            return temperature;
        }
        public List<Conditions> CreateForecast()
        {
            for (int i = 0; i < lengthOfForecast; i++)
            {
                forecast.Add(GetTheDaysWeather());
            }
            return forecast;
        }
        public List<Conditions> GetNextDaysForecast(List<Conditions> forecast)
        {
            forecast.RemoveAt(0);
            forecast.Add(GetTheDaysWeather());
            return forecast;
        }
    }
}
