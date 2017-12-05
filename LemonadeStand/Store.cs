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

        private double lemons10;
        private double sugar10;
        private double ice100;
        private double cups100;

        private double times1Multiplier = 1;
        private double times5Multiplier = 4.5;
        private double times10Multiplier = 8.8;

        public double Lemons10
        {
            get
            {
                return lemons10;
            }
            set
            {
                lemons10 = value;
            }
        }
        public double Sugar10
        {
            get
            {
                return sugar10;
            }
            set
            {
                sugar10 = value;
            }
        }
        public double Ice100
        {
            get
            {
                return ice100;
            }
            set
            {
                ice100 = value;
            }
        }
        public double Cups100
        {
            get
            {
                return cups100;
            }
            set
            {
                cups100 = value;
            }
        }
        public double Times1Multiplier
        {
            get
            {
                return times1Multiplier;
            }
        }
        public double Times5Multiplier
        {
            get
            {
                return times5Multiplier;
            }
        }
        public double Times10Multiplier
        {
            get
            {
                return times10Multiplier;
            }
        }


        double baseLemonCost = 0.74; //for 10 lemons
        double baseSugarCost = 1.09; //for 10 cups of sugar
        double baseIceCost = 0.24; //for 100 cubes
        double baseCupCost = 1.19; //for 100 cups
        public Store() //double baseLemonCost, double baseSugarCost, double baseIceCost, double baseCupCost
        {
            this.Lemons10 = baseLemonCost;
            this.Sugar10 = baseSugarCost;
            this.Ice100 = baseIceCost;
            this.Cups100 = baseCupCost;
        }
        public Store UpdateStore()
        {
            randomNumber = new Random();
            randomCents = randomNumber.Next(1, 20);    //random increment
            this.Lemons10 = baseLemonCost + randomCents/100;  //divide by 100 to convert to cents
            randomCents = randomNumber.Next(1, 27);
            this.Sugar10 = baseSugarCost + randomCents/100;
            randomCents = randomNumber.Next(1, 7);
            this.Ice100 = baseIceCost + randomCents/100;
            randomCents = randomNumber.Next(1, 30);
            this.Cups100 = baseCupCost + randomCents/100;
            return this;
        }
    }
}
