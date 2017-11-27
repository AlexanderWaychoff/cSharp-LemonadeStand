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
        Store store = new Store(); //0.75, 1.10, 0.25, 1.20
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
            TakeTurn(gameLength);
            TakeTurn(gameLength);

            TakeTurn(gameLength);
            TakeTurn(gameLength);

            gameLength.PassageOfDay();
            todaysForecast = dailyForecast.GetTheDaysWeather();
        }
        public void TakeTurn(Time gameLength)
        {
            userInventory = player.ObtainInventoryStatus();
            store = ChangeStorePrices();
            userInput = userInterface.AskWhatToDo(userInventory, player, store);
            player.AgeLemons(userInventory);
            //userInterface.CheckWhatToDo(userInput, userInventory, player, store);
        }
        public Store ChangeStorePrices()
        {
            //store = store.UpdateStore();
            return store.UpdateStore();
        }
    }
}
