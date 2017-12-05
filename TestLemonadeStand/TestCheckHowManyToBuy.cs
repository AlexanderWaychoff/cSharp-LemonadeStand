using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace TestLemonadeStand
{
    [TestClass]
    public class TestCheckHowManyToBuy
    {
        //[TestMethod]
        //public void CheckHowManyToBuy_Lemons_isLemons()
        //{
        //    //Arrange
        //    string userInput = "lemons";
        //    Inventory userInventory = new Inventory(0, 0, 0, 0);
        //    Player player = new Player();
        //    Store store = new Store();
        //    Recipe recipe = new Recipe(4, 4, 20, 1.00);
        //    Interface innerface = new Interface();
        //    //Act
        //    innerface.CheckHowManyToBuy(userInput, userInventory, player, store, recipe);
        //    //Assert
        //    Assert.AreEqual(userInput, innerface.LemonsOption);
        //}
        //need to comment out console.readlines or writelines for this to work
        [TestMethod]
        public void CheckHowManyToBuy_Lemon_isNotLemons()
        {
            //Arrange
            string userInput = "lemon";
            Inventory userInventory = new Inventory(0, 0, 0, 0);
            Player player = new Player();
            Store store = new Store();
            Recipe recipe = new Recipe(4, 4, 20, 1.00);
            Interface innerface = new Interface();
            //Act
            innerface.CheckHowManyToBuy(userInput, userInventory, player, store, recipe);
            //Assert
            Assert.AreNotEqual(userInput, innerface.LemonsOption);
        }
    }
}
