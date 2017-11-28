using System;
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

        public int startingCustomers = 100; //how many customers the player automatically starts with
        public int startingPopularity = 3;  //how aware customers are at the start of the game, fluctuating down to 1
        public double satisfiedCustomerCount;
        public double popularCustomerCount;
        public double customerChance;
        public double baseIceCubePreference = 20;
        public double baseCustomerPayment = 0.85;   //default what a customer will pay on a average weather day
        public double baseExtraCustomerChance = 7;  //7% chance increase per extra friendliness of a customer stopping by
        public int minimumForCustomerRemoval = 6; //random number between 4-10, if equal to this or less will remove customer from list
        public double customerCentQuality = 0.50;
        public double customerIceQuality = 7;
        Random randomThirstiness = new Random();
        Random randomFlavor = new Random();
        Random randomAttitude = new Random();
        Random randomPopularity = new Random();
        Random randomRainValue = new Random();
        Random randomCustomerChance = new Random();
        public double storeRandomValue;

        public BusinessTransactions()
        {

        }
        public List<Customer> CalculateBaseCustomerChance(List<Customer> customers, Conditions dailyWeather)
        {
            customerChance = (dailyWeather.temperature/2)/100;   //divide by 100 to make percentage
            if (dailyWeather.isRaining)
            {
                customerChance -= randomRainValue.Next(15, 35);
            }
            if (customerChance < 5)
            {
                customerChance = 5;
            }
            foreach (Customer customer in customers.ToList())
            {
                customer.percentChanceOfBuying = customerChance;
            }
            return customers;
        }
        public List<Customer> CalculateExtraCustomerChance(List<Customer> customers, Conditions dailyWeather)
        {
            foreach (Customer customer in customers.ToList())
            {
                if (customer.friendlyness > 5)
                {
                    customer.percentChanceOfBuying += baseExtraCustomerChance * (customer.friendlyness - 5);
                }
            }
            return customers;
        }
        public List<Customer> CalculateCostChance(List<Customer> customers, Conditions dailyWeather, Recipe recipe)
        {
            storeRandomValue = 0;
            if (dailyWeather.isRaining)
            {
                storeRandomValue = randomRainValue.Next(20, 51);
            }
            customerChance = (recipe.price - Math.Floor((baseCustomerPayment * ((dailyWeather.temperature * 3) / (dailyWeather.temperature + 50)) - storeRandomValue) * 100) / 100)/10; // every /10 cents increases or decreases customer chance
            foreach (Customer customer in customers.ToList())
            {
                customer.percentChanceOfBuying += customerChance;
            }
            return customers;
        }
        public void RunCustomerPurchases(List<Customer> customers, Inventory userInventory, Conditions dailyWeather, Recipe recipe)
        {
            customers = CalculateBaseCustomerChance(customers, dailyWeather);
            customers = CalculateExtraCustomerChance(customers, dailyWeather);
            customers = CalculateCostChance(customers, dailyWeather, recipe);
            foreach (Customer customer in customers.ToList())
            {
                if(randomCustomerChance.Next(101) <= customerChance)
                {
                    userInventory.moneyCount += recipe.price;
                    customer.hasPurchasedToday = true;
                    testCustomerSatisfaction(customer, dailyWeather, recipe);
                }
            }

        }
        public Customer testCustomerSatisfaction(Customer customer, Conditions dailyWeather, Recipe recipe)
        {
            int customerSatisfaction = 0;
            customerSatisfaction += testCustomerFlavor(customer, dailyWeather, recipe);
            customerSatisfaction += testCustomerPricing(customer, dailyWeather, recipe);
            customerSatisfaction += testCustomerBeverageTemperature(customer, dailyWeather, recipe);
            if (customerSatisfaction >= 2)
            {
                customer.isPleased = true;
            }
            if (customerSatisfaction < 0)
            {
                customer.isDispleased = true;
            }
            return customer;
        }
        public int testCustomerFlavor(Customer customer, Conditions dailyWeather, Recipe recipe)
        {
            if (customer.flavorPreference < 5)
            {
                if (recipe.lemonsUsed > 10 - customer.flavorPreference && recipe.sugarUsed <= 1 + customer.flavorPreference)
                {
                    return 1;
                }
            }
            else if (customer.flavorPreference > 5)
            {
                if (recipe.sugarUsed > 10 - customer.flavorPreference && recipe.lemonsUsed <= 1 + customer.flavorPreference)
                {
                    return 1;
                }
            }
            else
            {
                if (recipe.lemonsUsed == customer.flavorPreference && recipe.sugarUsed == customer.flavorPreference)
                {
                    return 1;
                }
            }
            return 0;
        }
        public int testCustomerPricing(Customer customer, Conditions dailyWeather, Recipe recipe)
        {
            if ((recipe.price - Math.Floor((baseCustomerPayment * ((dailyWeather.temperature * 3) / (dailyWeather.temperature + 50)) - storeRandomValue) * 100) / 100) / 10 > customerCentQuality)
            {
                return -1;  //customer paid more than 50 cents for the lemonade, reduce satisfaction
            }
            else if ((recipe.price - Math.Floor((baseCustomerPayment * ((dailyWeather.temperature * 3) / (dailyWeather.temperature + 50)) - storeRandomValue) * 100) / 100) / 10 < customerCentQuality)
            {
                return 1;   //customer paid less than 50 cents, increase satisfaction
            }
                return 0;
        }
        public int testCustomerBeverageTemperature(Customer customer, Conditions dailyWeather, Recipe recipe)
        {
            if (baseIceCubePreference * (dailyWeather.temperature / 100) <= recipe.iceUsed + 3 && baseIceCubePreference * (dailyWeather.temperature / 100) >= recipe.iceUsed - 3)
            {
                return 1;
            }
            else if (baseIceCubePreference * (dailyWeather.temperature / 100) >= recipe.iceUsed + customerIceQuality || baseIceCubePreference * (dailyWeather.temperature / 100) <= recipe.iceUsed - customerIceQuality)
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
            foreach (Customer customer in customers.ToList())
            {
                if (customer.hasPurchasedToday && customer.isPleased)
                {
                    satisfiedCustomerCount += 1;
                    customer.friendlyness += 3;
                    customer.awareOfLemonadeStand += 1;
                    if (customer.friendlyness > 10)
                    {
                        customer.awareOfLemonadeStand += 1;
                        customer.friendlyness = 10;
                    }
                }
                if (customer.hasPurchasedToday && customer.isDispleased)
                {
                    customer.friendlyness -= 5;
                    if (customer.friendlyness < 1)
                    {
                        customer.friendlyness = 1;
                    }
                    customer.awareOfLemonadeStand -= 5;
                    if (customer.awareOfLemonadeStand < 1)
                    {
                        customer.awareOfLemonadeStand = 1;
                    }
                }
                customer.hasPurchasedToday = false;
                customer.isPleased = false;
                customer.isDispleased = false;
                if (randomAttitude.Next(4, 11) <= minimumForCustomerRemoval && customer.friendlyness == 1)
                {
                    customers.Remove(customer);
                }
            }
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
            userInterface.DisplayAddedCustomersFromSatisfaction(satisfiedCustomerCount);
            return customers;
        }
        public List<Customer> AddPopularCustomers(List<Customer> customers, Interface userInterface)
        {
            popularCustomerCount = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customer.awareOfLemonadeStand > 5)
                {
                    for (int j = 5; j < customer.awareOfLemonadeStand; j++)
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
