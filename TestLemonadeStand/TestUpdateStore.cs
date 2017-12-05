using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace TestLemonadeStand
{
    [TestClass]
    public class TestUpdateStore
    {
        [TestMethod]
        public void UpdateStore_LemonsPrice_isNotBaseLemonPrice()
        { 
            //Arrange
            Store store = new Store();
            double baseLemonPrice = store.Lemons10;
            //Act
            store.UpdateStore();
            //Assert
            Assert.AreNotEqual(baseLemonPrice, store.Lemons10);
        }
        [TestMethod]
        public void UpdateStore_SugarPrice_isNotBaseSugarPrice()
        {
            //Arrange
            Store store = new Store();
            double baseSugarPrice = store.Sugar10;
            //Act
            store.UpdateStore();
            //Assert
            Assert.AreNotEqual(baseSugarPrice, store.Sugar10);
        }
    }
}
