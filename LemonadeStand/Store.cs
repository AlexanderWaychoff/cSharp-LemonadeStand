using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {
        Random randomNumber;

        public double lemons10;
        public double sugar10;
        public double ice100;
        public double cups100;

        public double times5Multiplier = 4.5;
        public double times10Multiplier = 8.8;

        double baseLemonCost = 0.75; //for 10 lemons
        double baseSugarCost = 1.10; //for 10 cups of sugar
        double baseIceCost = 0.25; //for 100 cubes
        double baseCupCost = 1.20; //for 100 cups
        public Store() //double baseLemonCost, double baseSugarCost, double baseIceCost, double baseCupCost
        {
            this.lemons10 = baseLemonCost;
            this.sugar10 = baseSugarCost;
            this.ice100 = baseIceCost;
            this.cups100 = baseCupCost;
        }

        public double GetLemonPrice()
        {

            return 0.0;
        }
        public Store UpdateStore()
        {
            randomNumber = new Random();
            this.lemons10 = baseLemonCost + randomNumber.Next(20);
            this.sugar10 = baseSugarCost + randomNumber.Next(27);
            this.ice100 = baseIceCost + randomNumber.Next(7);
            this.cups100 = baseCupCost + randomNumber.Next(30);
            return this;
        }
    }
}
