using Microsoft.VisualStudio.TestTools.UnitTesting;
using TugasBesarKPL;
using System;

namespace TugasBesarKPL.Tests
{
    [TestClass]
    public class DiscountModuleTests
    {
        [TestMethod]
        public void FridayDiscount_ShouldReturn20PercentOff()
        {
            DiscountModule discount = new DiscountModule();

            double result = discount.CalculateDiscount(
                100000,
                DayOfWeek.Friday
            );

            Assert.AreEqual(80000, result);
        }
    }
}