using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        Money money;

        public int lemonCount;
        public int sugarCount;
        public int iceCount;
        public int cupsCount;
        public double moneyCount;
        public double dailyProfit;
        public double overallProfit;

        double startingFunds = 20.00;

        public Inventory(int startingLemons, int startingSugar, int startingIce, int startingCups)
        {
            money = new Money(startingFunds);
            this.moneyCount = startingFunds;
            this.lemonCount = startingLemons;
            this.sugarCount = startingSugar;
            this.iceCount = startingIce;
            this.cupsCount = startingCups;
            this.dailyProfit = 0;
            this.overallProfit = 0;
        }
        public double CalculateDailyProfit(Inventory userInventory, Interface userInterface)
        {
            userInventory.dailyProfit = userInventory.dailyProfit - userInterface.ConvertToDecimal(userInventory.moneyCount.ToString("0.00"));
            return userInventory.dailyProfit;
        }
        public double CalculateOverallProfit(Inventory userInventory)
        {
            userInventory.overallProfit += userInventory.dailyProfit;
            return userInventory.overallProfit;
        }
        //public void ReduceOverallProfit(Inventory userInventory)
        //{
        //    userInventory.overallProfit -= 0;//subtract based on stock expenses
        //}
        
    }
}
