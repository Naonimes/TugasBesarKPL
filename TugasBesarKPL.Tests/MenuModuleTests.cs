using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TugasBesarKPL_Solution;

namespace TugasBesarKPL.Tests
{
    [TestClass]
    public class MenuModuleTests
    {
        [TestMethod]
        public void GetCategoryCode_ShouldReturnCorrectCode_WhenCategoryIsMakanan()
        {
            var menu = new MenuModule();

            string code = menu.GetCategoryCode("Makanan");

            Assert.AreEqual("MKN-01", code);
        }

        [TestMethod]
        public void GetCategoryCode_ShouldReturnUnknown_WhenCategoryNotFound()
        {
            var menu = new MenuModule();

            string code = menu.GetCategoryCode("Pizza");

            Assert.AreEqual("UNKNOWN", code);
        }

        [TestMethod]
        public void GetCategoryCode_ShouldThrowException_WhenCategoryEmpty()
        {
            var menu = new MenuModule();

            try
            {
                menu.GetCategoryCode("");
                Assert.Fail("Seharusnya terjadi ArgumentException.");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void AddData_ShouldIncreaseCount_WhenDataIsValid()
        {
            var storage = new MenuModule.DataStorage<string>();

            storage.AddData("Nasi Goreng");

            Assert.AreEqual(1, storage.Count);
        }

        [TestMethod]
        public void AddData_ShouldThrowException_WhenDataIsNull()
        {
            var storage = new MenuModule.DataStorage<string>();

            try
            {
                storage.AddData(null);
                Assert.Fail("Seharusnya terjadi ArgumentNullException.");
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}