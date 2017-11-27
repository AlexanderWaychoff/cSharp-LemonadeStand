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
        double randomCents;

        public double lemons10;
        public double sugar10;
        public double ice100;
        public double cups100;

        public double times1Multiplier = 1;
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
        public Store UpdateStore()
        {
            randomNumber = new Random();
            randomCents = randomNumber.Next(20);    //random increment
            this.lemons10 = baseLemonCost + randomCents/100;  //divide by 100 to convert to cents
            randomCents = randomNumber.Next(27);
            this.sugar10 = baseSugarCost + randomCents/100;
            randomCents = randomNumber.Next(7);
            this.ice100 = baseIceCost + randomCents/100;
            randomCents = randomNumber.Next(30);
            this.cups100 = baseCupCost + randomCents/100;
            return this;
        }
    }
}
