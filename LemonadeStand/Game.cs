using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//lines 22, 35, 91, 92

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
        //SQL highScore = new SQL();

        string userInput;
        List<Customer> customers = new List<Customer>();
        List<Conditions> forecast = new List<Conditions>();
        public Game()
        {

        }
        public void SetUpGame()
        {
            userInterface.DisplayRules();
            Time gameLength = SetUpGameLength();
            //highScore.ObtainHighScores();
            userInterface.AskForName(player);
            Console.WriteLine(player.Name);
            Console.Clear();
            forecast = dailyForecast.CreateForecast();
            PlayGame(gameLength);
        }
        private Time SetUpGameLength()
        {
            Time gameLength = new Time(userInterface.GetPlayTime());
            return gameLength;
        }
        private void PlayGame(Time gameLength)
        {
            customers = customerSales.SetUpCustomerBase();
            TakeTurns(gameLength, todaysForecast, customers);
            userInterface.ClearScreen();
            ShowFinalScore(gameLength);
        }
        private void TakeTurns(Time gameLength, Conditions todaysForecast, List<Customer> customers)
        {
            for (int i = gameLength.gameDays; i > 0; i--)
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
                userInventory.DailyProfit = 0;
                userInterface.Pause();
            }
        }
        private Store ChangeStorePrices()
        {
            return store.UpdateStore();
        }
        private double CalculateAllProfit(Inventory userInventory, Interface userInterface)
        {
            //userInventory.CalculateDailyProfit(userInventory, userInterface);
            userInventory.CalculateOverallProfit(userInventory);
            return userInventory.OverallProfit;
        }
        private void ShowFinalScore(Time gameLength)
        {
            //highScore.SubmitHighScore(player, userInventory, gameLength.gameDays);
            //highScore.ObtainHighScores();
            userInterface.DisplayFinalTotal(userInventory, gameLength.gameDays);
        }
    }
}
