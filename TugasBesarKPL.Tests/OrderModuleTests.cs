using Microsoft.VisualStudio.TestTools.UnitTesting;
using TugasBesarKPL;
using System;

namespace TugasBesarKPL.Tests
{
    [TestClass]
    public class OrderModuleTests
    {
        [TestMethod]
        public void NextState_ShouldMoveToPaid_WhenCurrentIsDraft()
        {
            var order = new OrderModule();
            order.NextState();
            Assert.AreEqual(OrderModule.OrderState.Paid, order.CurrentState);
        }
    }
}