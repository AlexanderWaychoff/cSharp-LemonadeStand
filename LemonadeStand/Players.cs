using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Players
    {
        int startingLemons = 0;
        int startingSugar = 0;
        int startingIce = 0;
        int startingCups = 0;
        Inventory playerInventory = new Inventory(0, 0, 0, 0); //starting items count
        List<Lemon> lemons = new List<Lemon>();
        Lemon lemon;
        public Players()
        {
            //Inventory playerInventory = new Inventory(startingLemons, startingSugar, startingIce, startingCups);
        }
        public Inventory ObtainInventoryStatus()
        {
            return playerInventory;
        }
        public void BuyLemons(Inventory userInventory)
        {
            //playerInventory.moneyCount -= lemonCost;
            //for (int i = boughtLemons; i > 0; i--)
            //{
            lemon = new Lemon();
            lemons.Add(lemon);
            //}
        }
    }
}
