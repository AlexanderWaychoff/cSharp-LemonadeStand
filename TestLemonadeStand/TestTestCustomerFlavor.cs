using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace TestLemonadeStand
{
    [TestClass]
    public class TestTestCustomerFlavor
    {
        [TestMethod]
        public void TestCustomerFlavor_CustomerFlavor_Neutral()
        {

            //Arrange
            BusinessTransactions sales = new BusinessTransactions();
            Recipe recipe = new Recipe(5, 5, 20, 1.00);
            Conditions weather = new Conditions("overcast", false, 85);
            Customer customer = new Customer(7, 5, 7, 5, false);
            int result;
            //Act
            result = sales.testCustomerFlavor(customer, weather, recipe);
            //Assert
            Assert.AreNotEqual(result, 0);
        }
        [TestMethod]
        public void TestCustomerFlavor_CustomerFlavor_Approved()
        {

            //Arrange
            BusinessTransactions sales = new BusinessTransactions();
            Recipe recipe = new Recipe(4, 4, 20, 1.00);
            Conditions weather = new Conditions("overcast", false, 85);
            Customer customer = new Customer(5, 5, 7, 5, false);
            int result;
            //Act
            result = sales.testCustomerFlavor(customer, weather, recipe);
            //Assert
            Assert.AreNotEqual(result, 1);
        }
    }
}
