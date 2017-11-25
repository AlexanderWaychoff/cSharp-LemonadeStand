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
        string character;
        string stockOption = "stock";
        string recipeOption = "recipe";
        string startOption = "start";
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
            character = VerifyInput("How many in-game days would you like this game to be? (type a number between " + Time.minimumDays + " and " + Time.maximumDays + ")", playTimeRange);
            return ConvertToInt(character);
        }

        public int ConvertToInt(string character)
        {
            characterNumber = Convert.ToInt32(character);
            return characterNumber;
        }
        public string AskWhatToDo()
        {
            Func<string, bool> whatToDoOption = VerifyWhatToDo;
            Console.WriteLine("You currently have 'put money here' money.  Your current stock contains 'lemons' lemons, 'sugar' cups of sugar', 'ice' ice cubes and 'cups' plastic cups.\n");
            character = VerifyInput("What would you like to do?  Type '" + stockOption + "' to check and buy items for your stock, '" + recipeOption + "' to adjust the items used in your lemonade, or '" + startOption + "' to start the next day.", whatToDoOption); //finish typing options switch recipe/buy stock
            return character;
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
