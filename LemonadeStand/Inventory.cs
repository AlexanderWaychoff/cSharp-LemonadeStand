﻿using System;
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

        double startingFunds = 20.00;
        //int startingLemons = 0;
        //int startingSugar = 0;
        //int startingIce = 0;
        //int startingCups = 0;
        public Inventory(int startingLemons, int startingSugar, int startingIce, int startingCups)
        {
            money = new Money(startingFunds);
            //this.moneyCount = money.;
            this.lemonCount = startingLemons;
            this.sugarCount = startingSugar;
            this.iceCount = startingIce;
            this.cupsCount = startingCups;
            //Lemon lemons = new Lemon();
            //Sugar sugar = new Sugar();
            //Ice ice = new Ice();
            //Cup cups = new Cup();

        }
    }
}
