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

        Inventory userInventory = new Inventory(0, 0, 0, 0); //starting items count

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
            return userInventory;
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
            if (this.userInventory.moneyCount - store.lemons10 * priceMultiplier < 0)
            {
                Console.WriteLine("\n**You can't afford to buy " + boughtLemons + " lemons.**\n");
            }
            else
            {
                userInventory.moneyCount -= store.lemons10 * priceMultiplier;
                userInventory.overallProfit -= store.lemons10 * priceMultiplier;
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
            if (this.userInventory.moneyCount - store.sugar10 * priceMultiplier < 0)
            {
                Console.WriteLine("\n**You can't afford to buy " + boughtSugar + " cups of sugar.**\n");
            }
            else
            {
                userInventory.moneyCount -= store.sugar10 * priceMultiplier;
                userInventory.overallProfit -= store.sugar10 * priceMultiplier;
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
            if (this.userInventory.moneyCount - store.ice100 * priceMultiplier < 0)
            {
                Console.WriteLine("\n**You can't afford to buy " + boughtIce + " ice cubes.**\n");
            }
            else
            {
                userInventory.moneyCount -= store.ice100 * priceMultiplier;
                userInventory.overallProfit -= store.ice100 * priceMultiplier;
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
            if (this.userInventory.moneyCount - store.cups100 * priceMultiplier < 0)
            {
                Console.WriteLine("\n**You can't afford to buy " + boughtCups + " cups.**\n");
            }
            else
            {
                userInventory.moneyCount -= store.cups100 * priceMultiplier;
                userInventory.overallProfit -= store.cups100 * priceMultiplier;
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
                Console.Write("\n**" + spoiledLemons + " lemon(s) were thrown out due to spoilage.**\n");
            }
            if(!(nearlyBadLemons == 0))
            {
                Console.Write("\n**" + nearlyBadLemons + " lemon(s) are currently " + lemon.lemonStatus + " and will spoil if not used by tomorrow.**\n");
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
        public Pitcher CreatePitcher (Recipe recipe, Inventory userInventory, Pitcher pitcher)
        {
            if (userInventory.lemonCount >= recipe.lemonsUsed && userInventory.sugarCount >= recipe.sugarUsed && userInventory.iceCount >= recipe.iceUsed && userInventory.cupsCount>= pitcher.CupsPerPitcher)
            {
                pitcher = new Pitcher(RemoveUsedLemons(recipe, userInventory), RemoveUsedSugar(recipe, userInventory), RemoveUsedIce(recipe, userInventory), pitcher.CupsPerPitcher, true);
            }
            else
            {
                pitcher = new Pitcher(0, 0, 0, 0, false);
            }
            return pitcher;
        }
        public double RemoveUsedLemons(Recipe recipe, Inventory userInventory)
        {
            bool removeLemon;
            for (int i = recipe.lemonsUsed; i > 0; i--)
            {
                userInventory.lemonCount -= 1;
                removeLemon = true;
                for (int j = totalLemons.Count - 1; j >= 0; j--)
                {
                    if (removeLemon)
                    {
                        if (totalLemons[j].spoilTime == 1)
                        {
                            removeLemon = false;
                            totalLemons.RemoveAt(j);
                            j -= 1;
                            break;
                        }
                    }
                }
                if (removeLemon)
                {
                    for (int k = totalLemons.Count - 1; k > 0; k--)
                    {
                        if (removeLemon)
                        {
                            if (totalLemons[k].spoilTime == 2)
                            {
                                removeLemon = false;
                                totalLemons.RemoveAt(k);
                                k -= 1;
                                break;
                            }
                        }
                    }
                }

                if(removeLemon)
                {
                    totalLemons.RemoveAt(0);
                    removeLemon = false;
                }
            }
            return recipe.lemonsUsed;
        }
        public double RemoveUsedSugar(Recipe recipe, Inventory userInventory)
        {
            for (double i = recipe.sugarUsed; i > 0; i--)
            {
                userInventory.sugarCount -= 1;
                totalSugar.RemoveAt(0);
            }
            return recipe.sugarUsed;
        }
        public double RemoveUsedIce(Recipe recipe, Inventory userInventory)
        {
            for (double i = recipe.iceUsed; i > 0; i--)
            {
                userInventory.iceCount -= 1;
                totalIceCubes.RemoveAt(0);
            }
            return recipe.iceUsed;
        }
        public void RemoveUsedCup(Recipe recipe, Inventory userInventory)
        {
                userInventory.cupsCount -= 1;
                totalCups.RemoveAt(0);
        }
    }
}
