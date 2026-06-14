using Microsoft.VisualStudio.TestTools.UnitTesting;
using TugasBesarKPL;
using System;
using System.Threading.Tasks;

namespace TugasBesarKPL.Tests
{
    [TestClass]
    public class PaymentModuleTests
    {
        [TestMethod]
        public async Task VerifyPaymentAsync_ShouldThrowException_WhenAmountZero()
        {
            // Arrange
            var payment = new PaymentModule();

            try
            {
                // Act
                await payment.VerifyPaymentAsync(0);

                // If it reaches this line, it means NO exception was thrown
                Assert.Fail("The test should have thrown an ArgumentException, but it didn't.");
            }
            catch (ArgumentException)
            {
                // Assert: The exception was caught, so the test passes!
                // You can even check the error message if you want:
                // Assert.AreEqual("Amount cannot be zero", ex.Message);
            }
            catch (Exception ex)
            {
                // This catches the WRONG type of exception
                Assert.Fail($"Expected ArgumentException but got {ex.GetType().Name}");
            }
        }
    }
}
