using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Interface userInterface = new Interface();
        Player player = new Player();
        Weather dailyForecast = new Weather();
        Conditions todaysForecast;
        public Game()
        {

        }
        public void PlayGame()
        {
            userInterface.DisplayRules();
            Time gameLength = SetUpGameLength();
            userInterface.AskWhatToDo();
            gameLength.PassageOfDay();
            Console.WriteLine(gameLength);
            todaysForecast = dailyForecast.GetTheDaysWeather();
        }
        public Time SetUpGameLength()
        {
            Time gameLength = new Time(userInterface.GetPlayTime());
            return gameLength;
        }
        public void DisplayDayStats()
        {

        }
    }
}
