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
        string userInput;
        Inventory userInventory;
        public Game()
        {

        }
        public void SetUpGame()
        {
            userInterface.DisplayRules();
            Time gameLength = SetUpGameLength();
            Console.Clear();
            todaysForecast = dailyForecast.GetTheDaysWeather();
            PlayGame(gameLength);
        }
        public Time SetUpGameLength()
        {
            Time gameLength = new Time(userInterface.GetPlayTime());
            return gameLength;
        }
        public void PlayGame(Time gameLength)
        {
            TakeTurn();
            gameLength.PassageOfDay();
            todaysForecast = dailyForecast.GetTheDaysWeather();
        }
        public void TakeTurn()
        {
            userInventory = player.ObtainInventoryStatus();
            userInput = userInterface.AskWhatToDo(userInventory);
            userInterface.CheckWhatToDo(userInput);
        }
    }
}
