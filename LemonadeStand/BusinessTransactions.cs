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
        public int minimumForCustomerRemoval = 6; //random number between 4-10, if equal to this or less will remove customer from list
        Random randomThirstiness = new Random();
        Random randomFlavor = new Random();
        Random randomAttitude = new Random();
        Random randomPopularity = new Random();

        public BusinessTransactions()
        {

        }
        public void RunCustomerPurchases()
        {

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
                if (customer.hasPurchasedToday && !(customer.isPleased))
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
