using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Interface
    {
        int characterNumber;
        string userInput;
        double userNumber;

        public string cancelOption = "cancel";

        public string stockOption = "stock";
        public string recipeOption = "recipe";
        public string startOption = "start";

        public string lemonsOption = "lemons";
        public string sugarOption = "sugar";
        public string iceOption = "ice";
        public string cupsOption = "cups";

        public Interface()
        {

        }
        public void DisplayRules()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("**Welcome to Lemonade Stand!**\n");
            Console.WriteLine("In this game your goal is to sell as much lemonade as you can and at the best profitable price while also carefully managing your stock of lemons, sugar, ice and cups.\n");
            Console.WriteLine("You'll have between 7-21 days to get the highest score.  Good luck!\n");
        }
        public int GetPlayTime()
        {
            Func<string, bool> playTimeRange = VerifyTime;
            userInput = VerifyInput("How many in-game days would you like this game to be? (type a number between " + Time.minimumDays + " and " + Time.maximumDays + ")", playTimeRange);
            return ConvertToInt(userInput);
        }

        public int ConvertToInt(string character)
        {
            characterNumber = Convert.ToInt32(character);
            return characterNumber;
        }
        public string AskWhatToDo(Inventory userInventory, Player player, Store store)
        {
            Func<string, bool> whatToDoOption = VerifyWhatToDo;
            Console.WriteLine("You currently have $" + userInventory.moneyCount.ToString("0.00") + ".  Your current stock contains " + userInventory.lemonCount + " lemons, " + userInventory.sugarCount + " cups of sugar, " + userInventory.iceCount + " ice cubes and " + userInventory.cupsCount + " plastic cups.\n");
            userInput = VerifyInput("What would you like to do?  Type '" + stockOption + "' to check and buy items for your stock, '" + recipeOption + "' to adjust the items used in your lemonade, or '" + startOption + "' to start the next day.\n", whatToDoOption); //finish typing options switch recipe/buy stock
            CheckWhatToDo(userInput, userInventory, player, store);
            return userInput;
        }
        public string CheckWhatToDo(string userInput, Inventory userInventory, Player player, Store store)
        {
            if (userInput == stockOption)
            {
                CheckWhatToBuy(userInventory, player, store);
            }
            if (userInput == recipeOption)
            {

            }
            return "0";
        }
        public void CheckWhatToBuy(Inventory userInventory, Player player, Store store)
        {
            Func<string, bool> whichToBuy = VerifyWhichStock;
            userInput = VerifyInput("Would you like to buy '" + lemonsOption + "', '" + sugarOption + "', '" + iceOption + "', or '" + cupsOption + "'?  Or to go back and not buy anything, enter '" + cancelOption + "'.\n", whichToBuy);
            CheckHowManyToBuy(userInput, userInventory, player, store);
        }
        public void CheckHowManyToBuy(string userInput, Inventory userInventory, Player player, Store store)
        {
            Func<string, bool> howMany10to100 = VerifyHowMany10to100;
            Func<string, bool> howMany100to1000 = VerifyHowMany100to1000;
            if (userInput == lemonsOption)
            {
                userNumber = ConvertToInt(VerifyInput("'10' lemons cost $" + store.lemons10.ToString("0.00") + ", '50' lemons cost $" + (store.lemons10 * store.times5Multiplier).ToString("0.00") + ", and '100' lemons cost $" + (store.lemons10 * store.times10Multiplier).ToString("0.00") + ".  How many will you buy?  Or to go back and not buy anything, enter '0'.\n", howMany10to100));
                player.BuyLemons(userInventory, store, userNumber);
                AskWhatToDo(userInventory, player, store);
            }
            if (userInput == sugarOption)
            {
                userNumber = ConvertToInt(VerifyInput("'10' cups of sugar cost $" + store.sugar10.ToString("0.00") + ", '50' cups of sugar cost $" + (store.sugar10 * store.times5Multiplier).ToString("0.00") + ", and '100' cups of sugar cost $" + (store.sugar10 * store.times10Multiplier).ToString("0.00") + ".  How many will you buy?  Or to go back and not buy anything, enter '0'.\n", howMany10to100));
                player.BuySugar(userInventory, store, userNumber);
                AskWhatToDo(userInventory, player, store);
            }
            if (userInput == iceOption)
            {
                userNumber = ConvertToInt(VerifyInput("'100' ice cubes cost $" + store.ice100.ToString("0.00") + ", '500' ice cubes cost $" + (store.ice100 * store.times5Multiplier).ToString("0.00") + ", and '1000' ice cubes cost $" + (store.ice100 * store.times10Multiplier).ToString("0.00") + ".  How many will you buy?  Or to go back and not buy anything, enter '0'.\n", howMany100to1000));
                player.BuyIce(userInventory, store, userNumber);
                AskWhatToDo(userInventory, player, store);
            }
            if (userInput == cupsOption)
            {
                userNumber = ConvertToInt(VerifyInput("'100' cups cost $" + store.cups100.ToString("0.00") + ", '500' cups cost $" + (store.cups100 * store.times5Multiplier).ToString("0.00") + ", and '1000' cups cost $" + (store.cups100 * store.times10Multiplier).ToString("0.00") + ".  How many will you buy?  Or to go back and not buy anything, enter '0'.\n", howMany100to1000));
                player.BuyCups(userInventory, store, userNumber);
                AskWhatToDo(userInventory, player, store);
            }
            if (userInput == cancelOption)
            {
                AskWhatToDo(userInventory, player, store);
            }
        }
        public string VerifyInput(string question, Func<string, bool> validation)
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
        public bool VerifyHowMany10to100(string userInput)
        {
            if (userInput == "10" || userInput == "50" || userInput == "100" || userInput == "0")
            {
                return true;
            }
            return false;
        }
        public bool VerifyHowMany100to1000(string userInput)
        {
            if (userInput == "100" || userInput == "500" || userInput == "1000" || userInput == "0")
            {
                return true;
            }
            return false;
        }
        public bool VerifyWhichStock(string userInput)
        {
            if (userInput == lemonsOption || userInput == sugarOption || userInput == iceOption || userInput == cupsOption || userInput == cancelOption)
            {
                return true;
            }
            return false;
        }
        public bool VerifyTime(string userInput)
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
        public bool VerifyWhatToDo (string userInput)
        {
            if (userInput == stockOption || userInput == recipeOption || userInput == startOption)
            {
                return true;
            }
            return false;
        }
    }
}
