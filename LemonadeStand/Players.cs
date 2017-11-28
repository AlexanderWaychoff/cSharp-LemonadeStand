using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Players
    {
        int nearlyBadLemons;
        int spoiledLemons;


        double priceMultiplier;

        Inventory playerInventory = new Inventory(900, 900, 900, 900); //starting items count

        List<Lemon> totalLemons = new List<Lemon>();
        Lemon lemon;
        List<Sugar> totalSugar = new List<Sugar>();
        Sugar sugar;
        List<Ice> totalIceCubes = new List<Ice>();
        Ice iceCube;
        List<Cup> totalCups = new List<Cup>();
        Cup cup;

        public Players()
        {
            //Inventory playerInventory = new Inventory(startingLemons, startingSugar, startingIce, startingCups);
        }
        public Inventory ObtainInventoryStatus()
        {
            return playerInventory;
        }
        public double CalculateLemonSugarMultiplier (Store store, double amountBought)
        {
            if (amountBought == 0)
            {
                return 0;
            }
            else if (amountBought == 10)
            {
                return store.times1Multiplier;
            }
            else if (amountBought == 50)
            {
                return store.times5Multiplier;
            }
            else
            {
                return store.times10Multiplier;
            }
        }
        public double CalculateIceCupsMultiplier(Store store, double amountBought)
        {
            if (amountBought == 0)
            {
                return 0;
            }
            else if (amountBought == 100)
            {
                return store.times1Multiplier;
            }
            else if (amountBought == 500)
            {
                return store.times5Multiplier;
            }
            else
            {
                return store.times10Multiplier;
            }
        }
        public void BuyLemons(Inventory userInventory, Store store, double boughtLemons)
        {
            priceMultiplier = CalculateLemonSugarMultiplier(store, boughtLemons);
            if (playerInventory.moneyCount - store.lemons10 * priceMultiplier < 0)
            {
                Console.WriteLine("\n**You can't afford to buy " + boughtLemons + " lemons.**\n");
            }
            else
            {
                playerInventory.moneyCount -= store.lemons10 * priceMultiplier;
                for (double i = boughtLemons; i > 0; i--)
                {
                    lemon = new Lemon();
                    totalLemons.Add(lemon);
                }
                userInventory.lemonCount = totalLemons.Count;
            }
        }
        public void BuySugar(Inventory userInventory, Store store, double boughtSugar)
        {
            priceMultiplier = CalculateLemonSugarMultiplier(store, boughtSugar);
            if (playerInventory.moneyCount - store.sugar10 * priceMultiplier < 0)
            {
                Console.WriteLine("\n**You can't afford to buy " + boughtSugar + " cups of sugar.**\n");
            }
            else
            {
                playerInventory.moneyCount -= store.sugar10 * priceMultiplier;
                for (double i = boughtSugar; i > 0; i--)
                {
                    sugar = new Sugar();
                    totalSugar.Add(sugar);
                }
                userInventory.sugarCount = totalSugar.Count;
            }
        }
        public void BuyIce(Inventory userInventory, Store store, double boughtIce)
        {
            priceMultiplier = CalculateIceCupsMultiplier(store, boughtIce);
            if (playerInventory.moneyCount - store.ice100 * priceMultiplier < 0)
            {
                Console.WriteLine("\n**You can't afford to buy " + boughtIce + " ice cubes.**\n");
            }
            else
            {
                playerInventory.moneyCount -= store.ice100 * priceMultiplier;
                for (double i = boughtIce; i > 0; i--)
                {
                    iceCube = new Ice();
                    totalIceCubes.Add(iceCube);
                }
                userInventory.iceCount = totalIceCubes.Count;
            }
        }
        public void BuyCups(Inventory userInventory, Store store, double boughtCups)
        {
            priceMultiplier = CalculateIceCupsMultiplier(store, boughtCups);
            if (playerInventory.moneyCount - store.cups100 * priceMultiplier < 0)
            {
                Console.WriteLine("\n**You can't afford to buy " + boughtCups + " cups.**\n");
            }
            else
            {
                playerInventory.moneyCount -= store.cups100 * priceMultiplier;
                for (double i = boughtCups; i > 0; i--)
                {
                    cup = new Cup();
                    totalCups.Add(cup);
                }
                userInventory.cupsCount = totalCups.Count;
            }
        }
        public void AgeLemons(Inventory userInventory)
        {
            foreach (Lemon lemon in totalLemons.ToList())
            {
                lemon.spoilTime -= 1;
                if (lemon.spoilTime > 0)
                {
                    lemon.lemonStatus = lemon.lemonDetail[lemon.spoilTime - 1];
                }
            }
            TestLemonSpoilage(userInventory);
        }
        public void TestLemonSpoilage(Inventory userInventory)
        {
            foreach (Lemon lemon in totalLemons.ToList())
            {
                if (lemon.spoilTime == 1)
                {
                    nearlyBadLemons += 1;
                }
                if (lemon.spoilTime == 0)
                {
                    spoiledLemons += 1;
                    totalLemons.Remove(lemon);
                }
            }
            userInventory.lemonCount = totalLemons.Count;
            AnnounceLemonSpoilage(nearlyBadLemons, spoiledLemons);
            nearlyBadLemons = 0;
            spoiledLemons = 0;
        }
        public void AnnounceLemonSpoilage(int nearlyBadLemons, int spoiledLemons)
        {
            if (!(spoiledLemons == 0))
            {
                Console.Write("\n**" + spoiledLemons + " were thrown out due to spoilage.**\n");
            }
            if(!(nearlyBadLemons == 0))
            {
                Console.Write("\n**" + nearlyBadLemons + " are currently " + lemon.lemonStatus + " and will spoil if not used by tomorrow.**\n");
            }
        }
        public void AnnounceIceMeltage(Inventory userInventory)
        {
            if (totalIceCubes.Count > 0)
            {
                Console.WriteLine("\n**You had " + totalIceCubes.Count + " unused ice cubes which are now melted.**\n");
            }
            totalIceCubes.Clear();
            userInventory.iceCount = totalIceCubes.Count;
        }
    }
}
