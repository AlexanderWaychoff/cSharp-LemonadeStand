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

        private int lemonCount;
        private int sugarCount;
        private int iceCount;
        private int cupsCount;
        private double moneyCount;
        private double dailyProfit;
        private double overallProfit;

        private double startingFunds = 20.00;

        public int LemonCount
        {
            get
            {
                return lemonCount;
            }
            set
            {
                lemonCount = value;
            }
        }
        public int SugarCount
        {
            get
            {
                return sugarCount;
            }
            set
            {
                sugarCount = value;
            }
        }
        public int IceCount
        {
            get
            {
                return iceCount;
            }
            set
            {
                iceCount = value;
            }
        }
        public int CupsCount
        {
            get
            {
                return cupsCount;
            }
            set
            {
                cupsCount = value;
            }
        }
        public double MoneyCount
        {
            get
            {
                return moneyCount;
            }
            set
            {
                moneyCount = value;
            }
        }
        public double DailyProfit
        {
            get
            {
                return dailyProfit;
            }
            set
            {
                dailyProfit = value;
            }
        }
        public double OverallProfit
        {
            get
            {
                return overallProfit;
            }
            set
            {
                overallProfit = value;
            }
        }

        public Inventory(int startingLemons, int startingSugar, int startingIce, int startingCups)
        {
            money = new Money(startingFunds);
            this.MoneyCount = startingFunds;
            this.LemonCount = startingLemons;
            this.SugarCount = startingSugar;
            this.IceCount = startingIce;
            this.CupsCount = startingCups;
            this.DailyProfit = 0;
            this.overallProfit = 0;
        }
        public double CalculateDailyProfit(Inventory userInventory, Interface userInterface)
        {
            userInventory.DailyProfit = userInventory.DailyProfit - userInterface.ConvertToDecimal(userInventory.MoneyCount.ToString("0.00"));
            return userInventory.DailyProfit;
        }
        public double CalculateOverallProfit(Inventory userInventory)
        {
            userInventory.OverallProfit += userInventory.DailyProfit;
            return userInventory.OverallProfit;
        }
        //public void ReduceOverallProfit(Inventory userInventory)
        //{
        //    userInventory.overallProfit -= 0;//subtract based on stock expenses
        //}
        
    }
}
