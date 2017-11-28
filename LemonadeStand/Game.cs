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
        Recipe recipe = new Recipe(4, 4, 20, 1.00);
        Conditions todaysForecast;
        Inventory userInventory;
        BusinessTransactions customerSales = new BusinessTransactions();

        string userInput;
        List<Customer> customers = new List<Customer>();
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
            customers = customerSales.SetUpCustomerBase();
            TakeTurn(gameLength, todaysForecast, customers);
            userInterface.ClearScreen();
        }
        public void TakeTurn(Time gameLength, Conditions todaysForecast, List<Customer> customers)
        {
            for (int i = 5; i > 0; i--)   //gameLength.gameDays
            {
                userInterface.DisplayRemainingDays(i);
                todaysForecast = dailyForecast.GetTheDaysWeather();
                userInterface.DisplayTotalCustomers(customers);
                userInventory = player.ObtainInventoryStatus();
                store = ChangeStorePrices();
                userInput = userInterface.AskWhatToDo(userInventory, player, store, recipe);
                customers = customerSales.RunCustomerPurchases(customers, userInventory, todaysForecast, recipe);

                customers = customerSales.CalculateAddedCustomers(customers, userInterface);
                userInterface.ClearScreen();
                gameLength.PassageOfDay();
                player.AgeLemons(userInventory);
                player.AnnounceIceMeltage(userInventory);

            }
        }
        public Store ChangeStorePrices()
        {
            return store.UpdateStore();
        }
    }
}
