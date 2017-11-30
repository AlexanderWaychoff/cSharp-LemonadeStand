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
        Store store = new Store();
        Weather dailyForecast = new Weather();
        Recipe recipe = new Recipe(4, 4, 20, 1.00);
        Conditions todaysForecast;
        Inventory userInventory;
        BusinessTransactions customerSales = new BusinessTransactions();
        SQL highScore = new SQL();

        string userInput;
        List<Customer> customers = new List<Customer>();
        List<Conditions> forecast = new List<Conditions>();
        public Game()
        {

        }
        public void SetUpGame()
        {
            highScore.ObtainHighScores();
            highScore.CloseConnection();
            Console.ReadKey();
            userInterface.DisplayRules();
            Time gameLength = SetUpGameLength();
            Console.Clear();
            forecast = dailyForecast.CreateForecast();
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
            TakeTurns(gameLength, todaysForecast, customers);
            userInterface.ClearScreen();
            ShowFinalScore();
        }
        public void TakeTurns(Time gameLength, Conditions todaysForecast, List<Customer> customers)
        {
            for (int i = 1; i > 0; i--)//gameLength.gameDays
            {
                userInterface.DisplayRemainingDays(i);
                userInterface.DisplayForecast(forecast);
                todaysForecast = forecast[0];
                userInterface.DisplayTotalCustomers(customers);
                userInventory = player.ObtainInventoryStatus();
                store = ChangeStorePrices();
                userInput = userInterface.AskWhatToDo(userInventory, player, store, recipe);
                //start of turn ^^\\end of turn vv
                userInterface.ClearScreen();
                gameLength.PassageOfDay();
                customers = customerSales.RunCustomerPurchases(customers, userInventory, todaysForecast, recipe, userInterface, player);
                CalculateAllProfit(userInventory, userInterface);
                dailyForecast.GetNextDaysForecast(forecast);
                userInterface.DisplayProfit(userInventory);
                customers = customerSales.CalculateAddedCustomers(customers, userInterface);
                player.AgeLemons(userInventory);
                player.AnnounceIceMeltage(userInventory);
                userInventory.dailyProfit = 0;
                userInterface.Pause();
            }
        }
        public Store ChangeStorePrices()
        {
            return store.UpdateStore();
        }
        public double CalculateAllProfit(Inventory userInventory, Interface userInterface)
        {
            //userInventory.CalculateDailyProfit(userInventory, userInterface);
            userInventory.CalculateOverallProfit(userInventory);
            return userInventory.overallProfit;
        }
        public void ShowFinalScore()
        {
            userInterface.DisplayFinalTotal(userInventory);
        }
    }
}
