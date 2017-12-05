using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;
using System.Collections.Generic;

namespace TestLemonadeStand
{
    [TestClass]
    public class TestTestLemonSpoilage
    {
        [TestMethod]
        public void TestLemonSpoilage_ReduceLemonCount_LemonListReduced()
        {
            //arrange
            Player player = new Player();
            Lemon lemon = new Lemon();
            lemon.daysToSpoil = 0;
            lemon.spoilTime = 0;
            player.totalLemons.Add(lemon);
            Inventory userInventory = new Inventory(1, 0, 0, 0);
            //Act
            player.TestLemonSpoilage(userInventory);
            //assert
            Assert.AreEqual(0, player.totalLemons.Count);
        }
        [TestMethod]
        public void TestLemonSpoilage_SameLemonCount_LemonListStaysSame()
        {
            //arrange
            Player player = new Player();
            Lemon lemon = new Lemon();
            lemon.daysToSpoil = 2;
            lemon.spoilTime = 2;
            player.totalLemons.Add(lemon);
            Inventory userInventory = new Inventory(1, 0, 0, 0);
            //Act
            player.TestLemonSpoilage(userInventory);
            //assert
            Assert.AreEqual(1, player.totalLemons.Count);
        }
    }
}
