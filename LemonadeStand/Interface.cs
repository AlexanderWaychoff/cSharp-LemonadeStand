using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Interface
    {
        private int characterNumber;
        private string userInput;
        private double userNumber;

        private string cancelOption = "cancel";

        private string stockOption = "stock";
        private string recipeOption = "recipe";
        private string startOption = "start";

        private string lemonsOption = "lemons";
        private string sugarOption = "sugar";
        private string iceOption = "ice";
        private string cupsOption = "cups";
        private string priceOption = "price";

        public Interface()
        {

        }
        public void ClearScreen()
        {
            Console.Clear();
        }
        public void DisplayRules()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("**Welcome to Lemonade Stand!**\n");
            Console.WriteLine("In this game your goal is to sell as much lemonade as you can and at the best profitable price while also carefully managing your stock of lemons, sugar, ice and cups.\n");
            Console.WriteLine("You'll have between 7-21 days to get the highest score.  Good luck!\n");
        }
        public void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("\nFor each pitcher of lemonade you are using: " + recipe.LemonsUsed + " lemon(s), " + recipe.SugarUsed + " cup(s) of sugar, and " + recipe.IceUsed + " ice cube(s).  You are currently charging $" + recipe.Price.ToString("0.00") + " per cup.\n");
        }
        public void DisplayRemainingDays(int days)
        {
            if (days == 1)
            {
                Console.WriteLine("**This is the final day of your lemonade stand.**\n");
            }
            else
            {
                Console.WriteLine("There are " + days + " days remaining.\n");
            }
        }
        public void DisplayAddedCustomersFromPopularity(double popularCustomerCount)
        {
            if (popularCustomerCount >= 1)
            {
                Console.WriteLine("\nWord has spread from customers pleased about your lemonade stand.  " + popularCustomerCount + " new customers will stop by the next day to check out your lemonade stand.\n");
            }
        }

        internal void Pause()
        {
            Console.WriteLine("\nPress any key to continue to the next day.");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayAddedCustomersFromSatisfaction (double satisfiedCustomerCount)
        {
            if (satisfiedCustomerCount >= 1)
            {
                Console.WriteLine("\nA murmur of general approval about your lemonade quality has spread.  " + Math.Floor(satisfiedCustomerCount / 3) + " new customers will stop by the next day to check out your lemonade stand.\n");
            }
        }
        public void DisplayCustomerSatisfaction(double amount)
        {
            if (amount > 0)
            {
                Console.WriteLine("Of the customers sold to, " + amount + " were satisfied with their drink.");
            }
        }
        public void DisplayCustomerDissatisfaction(double amount)
        {
            if (amount > 0)
            {
                Console.WriteLine("Of the customers sold to, " + amount + " were disappointed with their drink.");
            }
        }
        public void DisplayTotalCustomers (List<Customer> customers)
        {
            Console.WriteLine("\nYou have " + customers.Count + " potential customers.\n");
        }
        public void DisplayTotalSales (int amount)
        {
            Console.WriteLine("\nYou have sold lemonade to " + amount + " customers today.\n");
        }
        public void DisplayProfit(Inventory userInventory)
        {
            Console.WriteLine("You started the day with " + (userInventory.MoneyCount - userInventory.DailyProfit).ToString("0.00") + ".  Today you have earned " + userInventory.DailyProfit.ToString("0.00") + ".");
            Console.WriteLine("You're total net worth so far: " + userInventory.OverallProfit.ToString("0.00"));
        }
        public void DisplayFinalTotal(Inventory userInventory, int gameLength)
        {
            Console.WriteLine("\nYou're total net after " + gameLength + " is: " + userInventory.OverallProfit.ToString("0.00"));
            Console.WriteLine("Thanks for playing!  If you'd like to see if you're score made it in the top 5, start the game again once this closes.  You can press enter at any time to close this game.");
        }
        public void DisplayForecast(List<Conditions>forecast)
        {
            Console.WriteLine("Today's sky is {0} and it is {1}.  The temperature is {2}. \n", forecast[0].Cloudiness, forecast[0].IsRaining ? "raining" : "not raining", forecast[0].Temperature);
            Console.WriteLine("Tomorrow's sky will be {0} and it will {1}.  The temperature will be {2}. \n", forecast[1].Cloudiness, forecast[1].IsRaining ? "rain" : "not rain", forecast[1].Temperature);
            Console.WriteLine("The day after tomorrow's sky will be {0} and it will {1}.  The temperature will be {2}. \n", forecast[2].Cloudiness, forecast[2].IsRaining ? "rain" : "not rain", forecast[2].Temperature);

        }
        public int GetPlayTime()
        {
            Func<string, bool> playTimeRange = VerifyTime;
            userInput = VerifyInput("How many in-game days would you like this game to be? (type a number between " + Time.minimumDays + " and " + Time.maximumDays + ")", playTimeRange);
            return ConvertToInt(userInput);
        }

        private int ConvertToInt(string character)
        {
            characterNumber = Convert.ToInt32(character);
            return characterNumber;
        }
        public double ConvertToDecimal(string character)
        {
            double characterNumber = double.Parse(character);
            return characterNumber;
        }
        public void AskForName(Player player)
        {
            Console.WriteLine("\nPlease enter your name.  At the end you will be able to submit this with your score.\n");
            player.Name = Console.ReadLine();
            
        }
        public string AskWhatToDo(Inventory userInventory, Player player, Store store, Recipe recipe)
        {
            Func<string, bool> whatToDoOption = VerifyWhatToDo;
            Console.WriteLine("You currently have $" + userInventory.MoneyCount.ToString("0.00") + ".  Your current stock contains " + userInventory.LemonCount + " lemons, " + userInventory.SugarCount + " cups of sugar, " + userInventory.IceCount + " ice cubes and " + userInventory.CupsCount + " plastic cups.\n");
            userInput = VerifyInput("What would you like to do?  Type '" + stockOption + "' to check and buy items for your stock, '" + recipeOption + "' to adjust the items used in your lemonade, or '" + startOption + "' to start the next day.\n", whatToDoOption); //finish typing options switch recipe/buy stock
            CheckWhatToDo(userInput, userInventory, player, store, recipe);
            CheckIfEnoughStock(userInventory, player, store, recipe);
            return userInput;
        }
        public string CheckWhatToDo(string userInput, Inventory userInventory, Player player, Store store, Recipe recipe)
        {
            if (userInput == stockOption)
            {
                CheckWhatToBuy(userInventory, player, store, recipe);
            }
            if (userInput == recipeOption)
            {
                CheckRecipe(userInventory, player, store, recipe);
            }
            return "0";
        }
        public void CheckWhatToBuy(Inventory userInventory, Player player, Store store, Recipe recipe)
        {
            Func<string, bool> whichToBuy = VerifyWhichStock;
            userInput = VerifyInput("Would you like to buy '" + lemonsOption + "', '" + sugarOption + "', '" + iceOption + "', or '" + cupsOption + "'?  Or to go back and not buy anything, enter '" + cancelOption + "'.\n", whichToBuy);
            CheckHowManyToBuy(userInput, userInventory, player, store, recipe);
        }
        public void CheckHowManyToBuy(string userInput, Inventory userInventory, Player player, Store store, Recipe recipe)
        {
            Func<string, bool> howMany10to100 = VerifyHowMany10to100;
            Func<string, bool> howMany100to1000 = VerifyHowMany100to1000;
            if (userInput == lemonsOption)
            {
                userNumber = ConvertToInt(VerifyInput("'10' lemons cost $" + store.Lemons10.ToString("0.00") + ", '50' lemons cost $" + (store.Lemons10 * store.Times5Multiplier).ToString("0.00") + ", and '100' lemons cost $" + (store.Lemons10 * store.Times10Multiplier).ToString("0.00") + ".  How many will you buy?  Or to go back and not buy anything, enter '0'.\n", howMany10to100));
                player.BuyLemons(userInventory, store, userNumber);
                CheckWhatToBuy(userInventory, player, store, recipe);
            }
            if (userInput == sugarOption)
            {
                userNumber = ConvertToInt(VerifyInput("'10' cups of sugar cost $" + store.Sugar10.ToString("0.00") + ", '50' cups of sugar cost $" + (store.Sugar10 * store.Times5Multiplier).ToString("0.00") + ", and '100' cups of sugar cost $" + (store.Sugar10 * store.Times10Multiplier).ToString("0.00") + ".  How many will you buy?  Or to go back and not buy anything, enter '0'.\n", howMany10to100));
                player.BuySugar(userInventory, store, userNumber);
                CheckWhatToBuy(userInventory, player, store, recipe);
            }
            if (userInput == iceOption)
            {
                userNumber = ConvertToInt(VerifyInput("'100' ice cubes cost $" + store.Ice100.ToString("0.00") + ", '500' ice cubes cost $" + (store.Ice100 * store.Times5Multiplier).ToString("0.00") + ", and '1000' ice cubes cost $" + (store.Ice100 * store.Times10Multiplier).ToString("0.00") + ".  How many will you buy?  Or to go back and not buy anything, enter '0'.\n", howMany100to1000));
                player.BuyIce(userInventory, store, userNumber);
                CheckWhatToBuy(userInventory, player, store, recipe);
            }
            if (userInput == cupsOption)
            {
                userNumber = ConvertToInt(VerifyInput("'100' cups cost $" + store.Cups100.ToString("0.00") + ", '500' cups cost $" + (store.Cups100 * store.Times5Multiplier).ToString("0.00") + ", and '1000' cups cost $" + (store.Cups100 * store.Times10Multiplier).ToString("0.00") + ".  How many will you buy?  Or to go back and not buy anything, enter '0'.\n", howMany100to1000));
                player.BuyCups(userInventory, store, userNumber);
                CheckWhatToBuy(userInventory, player, store, recipe);
            }
            if (userInput == cancelOption)
            {
                AskWhatToDo(userInventory, player, store, recipe);
            }
        }
        public void CheckIfEnoughStock(Inventory userInventory, Player player, Store store, Recipe recipe)
        {
            if (userInventory.LemonCount < recipe.LemonsUsed || userInventory.SugarCount < recipe.SugarUsed || userInventory.IceCount < recipe.IceUsed || userInventory.CupsCount == 0)
            {
                Console.WriteLine("\n**You don't have enough supplies to make any pitchers of lemonade!**\n\nPress any key to continue.\n");
                Console.ReadKey();
                AskWhatToDo(userInventory, player, store, recipe);
            }
        }
        public void CheckRecipe (Inventory userInventory, Player player, Store store, Recipe recipe)
        {
            Func<string, bool> whichToChange = VerifyWhichToChange;
            DisplayRecipe(recipe);
            userInput = VerifyInput("Would you like to change the '" + priceOption + "' per cup?  Or one of the ingredients: '" + lemonsOption + "', '" + sugarOption + "', or '" + iceOption + "'?  Or to go back and not change anything to this recipe, enter '" + cancelOption + "'.\n", whichToChange);
            ChangeRecipe(userInput, userInventory, player, store, recipe);
        }
        public void ChangeRecipe(string userInput, Inventory userInventory, Player player, Store store, Recipe recipe)
        {
            Func<string, bool> check1To10 = Verify1To10;
            Func<string, bool> check1To50 = Verify1To50;
            Func<string, bool> check5Dollars = VerifyUpTo5;
            if (userInput == lemonsOption)
            {
                userNumber = ConvertToInt(VerifyInput("\nHow many lemons would you like the new recipe to have?  Enter a integer between 1 through 10 (1 being lowest quality, 10 being highest)\n", check1To10));
                recipe.LemonsUsed = Convert.ToInt32(userNumber);
                CheckRecipe(userInventory, player, store, recipe);
            }
            if (userInput == sugarOption)
            {
                userNumber = ConvertToInt(VerifyInput("\nHow many cups of sugar would you like the new recipe to have.  Enter a integer between 1 through 10 (1 being lowest quality, 10 being highest)\n", check1To10));
                recipe.SugarUsed = Convert.ToInt32(userNumber);
                CheckRecipe(userInventory, player, store, recipe);
            }
            if (userInput == iceOption)
            {
                userNumber = ConvertToInt(VerifyInput("\nHow many ice cubes would you like the new recipe to have?  Enter a integer between 1 through 50 (quality depends on how high or low the temperature is; less ice if cold, or more ice if hot)\n", check1To50));
                recipe.IceUsed = Convert.ToInt32(userNumber);
                CheckRecipe(userInventory, player, store, recipe);
            }
            if (userInput == priceOption)
            {
                userNumber = ConvertToDecimal(VerifyInput("\nHow much would you like to charge per cup?  Enter a number between 0.01 and 5.00 (price will affect demand and a customer's willingness to purchase your lemonade based on weather conditions)\n", check5Dollars));
                recipe.Price = userNumber;
                CheckRecipe(userInventory, player, store, recipe);
            }
            if (userInput == cancelOption)
            {
                AskWhatToDo(userInventory, player, store, recipe);
            }
        }
        private string VerifyInput(string question, Func<string, bool> validation)
        {
            string userInput;
            bool isThereBadInput = false;
            do
            {
                if(isThereBadInput)
                {
                    Console.WriteLine("\n**You entered an invalid value.  Please try again.**\n");
                }
                Console.WriteLine(question);
                userInput = Console.ReadLine();
                isThereBadInput = true;
            }
            while (!validation(userInput));
            return userInput;
        }
        private bool VerifyHowMany10to100(string userInput)
        {
            if (userInput == "10" || userInput == "50" || userInput == "100" || userInput == "0")
            {
                return true;
            }
            return false;
        }
        private bool VerifyHowMany100to1000(string userInput)
        {
            if (userInput == "100" || userInput == "500" || userInput == "1000" || userInput == "0")
            {
                return true;
            }
            return false;
        }
        private bool VerifyWhichStock(string userInput)
        {
            if (userInput == lemonsOption || userInput == sugarOption || userInput == iceOption || userInput == cupsOption || userInput == cancelOption)
            {
                return true;
            }
            return false;
        }
        private bool VerifyWhichToChange(string userInput)
        {
            if (userInput == lemonsOption || userInput == sugarOption || userInput == iceOption || userInput == priceOption ||userInput == cancelOption)
            {
                return true;
            }
            return false;
        }
        private bool VerifyTime(string userInput)
        {
            if (userInput.All(char.IsDigit))
            {
                int inputToInt = Convert.ToInt32(userInput);
                if (inputToInt >= Time.minimumDays && inputToInt <= Time.maximumDays)
                {
                    return true;
                }
            }
            return false;
        }
        private bool Verify1To10(string userInput)   //min\max for lemon\sugar per pitcher
        {
            if (userInput.All(char.IsDigit))
            {
                int inputToInt = Convert.ToInt32(userInput);
                if (inputToInt >= 1 && inputToInt <= 10)
                {
                    return true;
                }
            }
            return false;
        }
        private bool Verify1To50(string userInput)   //min\max for ice per pitcher
        {
            if (userInput.All(char.IsDigit))
            {
                int inputToInt = Convert.ToInt32(userInput);
                if (inputToInt >= 1 && inputToInt <= 50)
                {
                    return true;
                }
            }
            return false;
        }
        private bool VerifyUpTo5(string userInput)   //min\max price per cup
        {
            double inputToDouble;
            if (double.TryParse(userInput, out inputToDouble))
            {
                inputToDouble = double.Parse(userInput);
                if (inputToDouble >= 0.01 && inputToDouble <= 5.00)
                {
                    return true;
                }
            }
            return false;
        }
        private bool VerifyWhatToDo (string userInput)
        {
            if (userInput == stockOption || userInput == recipeOption || userInput == startOption)
            {
                return true;
            }
            return false;
        }
    }
}
