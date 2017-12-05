using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace TestLemonadeStand
{
    [TestClass]
    public class TestConvertToDecimal
    {
        [TestMethod]
        public void ConvertToDecimal_DecimalString_ReturnNumber()
        {
            //arrange
            Interface innerface = new Interface();
            string decimalString = "11.27";
            //act
            double justDecimal = innerface.ConvertToDecimal(decimalString);
            //assert
            Assert.AreEqual(11.27, justDecimal);
        }
    }
}
