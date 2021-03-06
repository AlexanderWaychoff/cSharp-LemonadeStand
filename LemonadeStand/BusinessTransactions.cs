﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class BusinessTransactions
    {
        List<Customer> customers = new List<Customer>();
        Customer customer;

        private int startingCustomers = 100; //how many customers the player automatically starts with
        private int startingPopularity = 3;  //how aware customers are at the start of the game, fluctuating down to 1
        private double satisfiedCustomerCount;
        private double popularCustomerCount;
        private double customerChance;
        private double baseIceCubePreference = 20;
        private double baseCustomerPayment = 0.85;   //default what a customer will pay on a average weather day
        private double baseExtraCustomerChance = 7;  //7% chance increase per extra friendliness of a customer stopping by
        private int minimumForCustomerRemoval = 6; //random number between 4-10, if equal to this or less will remove customer from list
        private int weatherPriceMultiplier = 6;
        private int weatherPriceAdditive = 250;
        private int weatherPriceDividedEffect = 6; //per this many cents over/under, decrease/increase chance of customer buying by 1%
        private double customerCentQuality = 0.50;
        private double customerIceQuality = 7;
        Random randomThirstiness = new Random();
        Random randomFlavor = new Random();
        Random randomAttitude = new Random();
        Random randomPopularity = new Random();
        Random randomRainValue = new Random();
        Random randomCustomerChance = new Random();
        private double storeRandomValue;

        public BusinessTransactions()
        {

        }
        public List<Customer> CalculateBaseCustomerChance(List<Customer> customers, Conditions dailyWeather)
        {
            customerChance = (dailyWeather.Temperature/2);   //divide by 100 to make percentage
            if (dailyWeather.IsRaining)
            {
                customerChance -= randomRainValue.Next(15, 35);
            }
            if (customerChance < 5)
            {
                customerChance = 5;
            }
            for (int i = customers.Count; i > 0; i--)
            {
                customers[i - 1].PercentChanceOfBuying = customerChance;
            }
            return customers;
        }
        public List<Customer> CalculateExtraCustomerChance(List<Customer> customers, Conditions dailyWeather)
        {
            for (int i = customers.Count; i > 0; i--)
            {
                if (customers[i - 1].Friendlyness > 5)
                {
                    customers[i - 1].PercentChanceOfBuying += baseExtraCustomerChance * (customers[i - 1].Friendlyness - 5);
                }
                if (customers[i - 1].Friendlyness <= 4)
                {
                    customers[i - 1].PercentChanceOfBuying -= baseExtraCustomerChance * (4 - customers[i - 1].Friendlyness);
                }
            }
            return customers;
        }
        public List<Customer> CalculateCostChance(List<Customer> customers, Conditions dailyWeather, Recipe recipe)
        {
            storeRandomValue = 0;
            if (dailyWeather.IsRaining)
            {
                storeRandomValue = randomRainValue.Next(20, 51);
            }
            customerChance = 100 * ((Math.Floor(((baseCustomerPayment * ((dailyWeather.Temperature * weatherPriceMultiplier) / (dailyWeather.Temperature + weatherPriceAdditive)) - (storeRandomValue / 100))) * 100) / 100 - recipe.Price) / weatherPriceDividedEffect);
            for (int i = customers.Count; i > 0; i--)
            {
                customers[i - 1].PercentChanceOfBuying += customerChance;
            }
            return customers;
        }
        public List<Customer> RunCustomerPurchases(List<Customer> customers, Inventory userInventory, Conditions dailyWeather, Recipe recipe, Interface userInterface, Player player)
        {
            Pitcher pitcher = new Pitcher(0, 0, 0, 0, true);
            int totalCustomerPurchases = 0;
            customers = CalculateBaseCustomerChance(customers, dailyWeather);
            customers = CalculateExtraCustomerChance(customers, dailyWeather);
            customers = CalculateCostChance(customers, dailyWeather, recipe);
            for (int i = customers.Count; i > 0; i--)
            {
                if(randomCustomerChance.Next(101) <= customer.PercentChanceOfBuying)
                {
                    if (pitcher.HasEnoughStock && pitcher.CupsLeft == 0)
                    {
                        pitcher = player.CreatePitcher(recipe, userInventory, pitcher);
                    }
                    if (pitcher.HasEnoughStock && pitcher.CupsLeft > 0)
                    {
                        totalCustomerPurchases += 1;
                        userInventory.MoneyCount += recipe.Price;
                        userInventory.DailyProfit += recipe.Price;
                        pitcher.CupsLeft -= 1;
                        player.RemoveUsedCup(recipe, userInventory);
                        customers[i - 1].HasPurchasedToday = true;
                        customers[i - 1] = testCustomerSatisfaction(customers[i - 1], dailyWeather, recipe);
                    }
                }
            }
            userInterface.DisplayTotalSales(totalCustomerPurchases);
            return customers;
        }
        public Customer testCustomerSatisfaction(Customer customer, Conditions dailyWeather, Recipe recipe)
        {
            int customerSatisfaction = 0;
            customerSatisfaction += testCustomerFlavor(customer, dailyWeather, recipe);
            customerSatisfaction += testCustomerPricing(customer, dailyWeather, recipe);
            customerSatisfaction += testCustomerBeverageTemperature(customer, dailyWeather, recipe);
            if (customerSatisfaction >= 2)
            {
                customer.IsPleased = true;
            }
            if (customerSatisfaction < 0)
            {
                customer.IsDispleased = true;
            }
            return customer;
        }
        public int testCustomerFlavor(Customer customer, Conditions dailyWeather, Recipe recipe)
        {
            if (customer.FlavorPreference < 5)
            {
                if (recipe.LemonsUsed > 10 - customer.FlavorPreference && recipe.SugarUsed <= 1 + customer.FlavorPreference)
                {
                    return 1;
                }
            }
            else if (customer.FlavorPreference > 5)
            {
                if (recipe.SugarUsed > 1 + customer.FlavorPreference && recipe.LemonsUsed <= 10 - customer.FlavorPreference)
                {
                    return 1;
                }
            }
            else
            {
                if (recipe.LemonsUsed == customer.FlavorPreference && recipe.SugarUsed == customer.FlavorPreference)
                {
                    return 1;
                }
            }
            if (recipe.LemonsUsed <= 3 && recipe.SugarUsed <= 3)
            {
                return -1;
            }
            if (recipe.LemonsUsed == 1 || recipe.SugarUsed == 1)
            {
                return -1;
            }
            return 0;
        }
        public int testCustomerPricing(Customer customer, Conditions dailyWeather, Recipe recipe)
        {
            if ((Math.Floor((baseCustomerPayment * ((dailyWeather.Temperature * 3) / (dailyWeather.Temperature + 50)) - storeRandomValue) * 100) / 100) / 10 - recipe.Price > customerCentQuality)
            {
                return -1;  //customer paid more than 50 cents difference for the lemonade, reduce satisfaction
            }
            else if ((Math.Floor((baseCustomerPayment * ((dailyWeather.Temperature * 3) / (dailyWeather.Temperature + 50)) - storeRandomValue) * 100) / 100) / 10 - recipe.Price < customerCentQuality)
            {
                return 1;   //customer paid less than 50 cents difference, increase satisfaction
            }
                return 0;
        }
        public int testCustomerBeverageTemperature(Customer customer, Conditions dailyWeather, Recipe recipe)
        {
            if (baseIceCubePreference * (dailyWeather.Temperature / 75) <= recipe.IceUsed + 3 && baseIceCubePreference * (dailyWeather.Temperature / 75) >= recipe.IceUsed - 3)
            {
                return 1;
            }
            else if (baseIceCubePreference * (dailyWeather.Temperature / 75) >= recipe.IceUsed + customerIceQuality || baseIceCubePreference * (dailyWeather.Temperature / 75) <= recipe.IceUsed - customerIceQuality)
            {
                return -1;
            }
            return 0;
        }
        public List<Customer> SetUpCustomerBase()
        {
            for (int i = startingCustomers; i > 0; i--)
            {

                customer = new Customer(randomThirstiness.Next(1,11), randomFlavor.Next(1,11), randomAttitude.Next(4,11), startingPopularity - randomPopularity.Next(0,3), false);
                customers.Add(customer);
            }
            return customers;
        }
        public List<Customer> CalculateAddedCustomers(List<Customer> customers, Interface userInterface)
        {
            satisfiedCustomerCount = 0;
            double dissatisfiedCustomerCount = 0;
            for (int i = customers.Count; i > 0; i--)
            {
                if (customers[i - 1].HasPurchasedToday && customers[i - 1].IsPleased)
                {
                    satisfiedCustomerCount += 1;
                    customers[i - 1].Friendlyness += 3;
                    customers[i - 1].AwareOfLemonadeStand += 1;
                    if (customers[i - 1].Friendlyness > 10)
                    {
                        customers[i - 1].AwareOfLemonadeStand += 1;
                        customers[i - 1].Friendlyness = 10;
                    }
                }
                if (customers[i - 1].HasPurchasedToday && customers[i - 1].IsDispleased)
                {
                    dissatisfiedCustomerCount += 1;
                    customers[i - 1].Friendlyness -= 5;
                    if (customers[i - 1].Friendlyness < 1)
                    {
                        customers[i - 1].Friendlyness = 1;
                    }
                    customers[i - 1].AwareOfLemonadeStand -= 5;
                    if (customers[i - 1].AwareOfLemonadeStand < 1)
                    {
                        customers[i - 1].AwareOfLemonadeStand = 1;
                    }
                }
                customers[i - 1].HasPurchasedToday = false;
                customers[i - 1].IsPleased = false;
                customers[i - 1].IsDispleased = false;
                if (randomAttitude.Next(4, 11) <= minimumForCustomerRemoval && customers[i - 1].Friendlyness == 1)
                {
                    customers.Remove(customers[i - 1]);
                    i -= 1;
                }
            }
            userInterface.DisplayCustomerSatisfaction(satisfiedCustomerCount);
            userInterface.DisplayCustomerDissatisfaction(dissatisfiedCustomerCount);
            customers = AddPopularCustomers(customers, userInterface);
            return AddSatisfiedCustomers(customers, satisfiedCustomerCount, userInterface);
        }
        public List<Customer> AddSatisfiedCustomers (List<Customer> customers, double satisfiedCustomerCount, Interface userInterface)
        {
            for (double i = Math.Floor(satisfiedCustomerCount/3); i > 0; i--)
            {
                customer = new Customer(randomThirstiness.Next(1, 11), randomFlavor.Next(1, 11), randomAttitude.Next(5, 11), startingPopularity - randomPopularity.Next(0, 3), false);
                customers.Add(customer);
            }
            userInterface.DisplayAddedCustomersFromSatisfaction(Math.Floor(satisfiedCustomerCount));
            return customers;
        }
        public List<Customer> AddPopularCustomers(List<Customer> customers, Interface userInterface)
        {
            popularCustomerCount = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].AwareOfLemonadeStand > 5)
                {
                    for (int j = 5; j < customers[i].AwareOfLemonadeStand; j++)
                    {
                        popularCustomerCount += 1;
                        customer = new Customer(randomThirstiness.Next(1, 11), randomFlavor.Next(1, 11), randomAttitude.Next(6, 11), startingPopularity - randomPopularity.Next(0, 3), false);
                        customers.Add(customer);
                    }
                }
            }
            userInterface.DisplayAddedCustomersFromPopularity(popularCustomerCount);
            return customers;
        }
    }
}
