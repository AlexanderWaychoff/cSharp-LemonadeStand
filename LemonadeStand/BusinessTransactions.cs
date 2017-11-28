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

                customer = new Customer(randomThirstiness.Next(1,11), randomFlavor.Next(1,11), randomAttitude.Next(5,11), startingPopularity - randomPopularity.Next(0,3));
                customers.Add(customer);
            }
            return customers;
        }
    }
}
