using CalculosPlusvalias.Services;
using CalculosPlusvalias.Services.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CalculosPlusvaliasDeGiro.Tests
{
    [TestClass]
    public class CalculateGainsTests
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [TestMethod]
        public void CalculateGainsFromSells_BuyNumberEqualsToSellNumber()
        {
            var buy = new Transaction()
            {
                Date = new System.DateTime(2020, 3, 1),
                OriginalNumber = 10,
                RemainingNumber = 10,
                LocalUnitPrice = 1,
                Comission = 0,
                ExchangeRate = 1
            };
            var sell = new Transaction()
            {
                Date = new System.DateTime(2020, 4, 1),
                OriginalNumber = -10,
                RemainingNumber = -10,
                LocalUnitPrice = 2,
                Comission = 0,
                ExchangeRate = 1
            };
            var transactions = new List<Transaction>() { buy, sell};
            var product = new Product("Foo", "Bar",transactions);
            Assert.AreEqual(1, product.Gains.Count());
            Assert.AreEqual(10, product.Gains.First().TotalGain);
        }

        [TestMethod]
        public void CalculateGainsFromSells_BuyNumberGreaterThanSellNumber()
        {
            var buy = new Transaction()
            {
                Date = new System.DateTime(2020, 3, 1),
                OriginalNumber = 10,
                RemainingNumber = 10,
                LocalUnitPrice = 1,
                Comission = 0,
                ExchangeRate = 1
            };
            var sell = new Transaction()
            {
                Date = new System.DateTime(2020, 4, 1),
                OriginalNumber = -5,
                RemainingNumber = -5,
                LocalUnitPrice = 2,
                Comission = 0,
                ExchangeRate = 1
            };
            var transactions = new List<Transaction>() { buy, sell };
            var product = new Product("Foo", "Bar", transactions);
            Assert.AreEqual(1, product.Gains.Count());
            Assert.AreEqual(5, product.Gains.First().TotalGain);
        }

        [TestMethod]
        public void CalculateGainsFromSells_BuyNumberLowerThanSellNumber()
        {
            var buy = new Transaction()
            {
                Date = new System.DateTime(2020, 3, 1),
                OriginalNumber = 10,
                RemainingNumber = 10,
                LocalUnitPrice = 1,
                Comission = 0,
                ExchangeRate = 1
            };
            var buy_2 = new Transaction()
            {
                Date = new System.DateTime(2020, 3, 15),
                OriginalNumber = 5,
                RemainingNumber = 5,
                LocalUnitPrice = 2,
                Comission = 0,
                ExchangeRate = 1
            };
            var sell = new Transaction()
            {
                Date = new System.DateTime(2020, 4, 1),
                OriginalNumber = -15,
                RemainingNumber = -15,
                LocalUnitPrice = 2,
                Comission = 0,
                ExchangeRate = 1
            };
            var transactions = new List<Transaction>() { buy, buy_2, sell };
            var product = new Product("Foo", "Bar", transactions);
            Assert.AreEqual(1, product.Gains.Count());
            Assert.AreEqual(10, product.Gains.First().TotalGain);
        }

        [TestMethod]
        public void CalculateGainsFromSells_BuyNumberLowerThanSellNumber_2()
        {
            var buy = new Transaction()
            {
                Date = new System.DateTime(2020, 3, 1),
                OriginalNumber = 10,
                RemainingNumber = 10,
                LocalUnitPrice = 1,
                Comission = 0,
                ExchangeRate = 1
            };
            var buy_2 = new Transaction()
            {
                Date = new System.DateTime(2020, 3, 15),
                OriginalNumber = 5,
                RemainingNumber = 5,
                LocalUnitPrice = 3,
                Comission = 0,
                ExchangeRate = 1
            };
            var sell = new Transaction()
            {
                Date = new System.DateTime(2020, 4, 1),
                OriginalNumber = -15,
                RemainingNumber = -15,
                LocalUnitPrice = 2,
                Comission = 0,
                ExchangeRate = 1
            };
            var transactions = new List<Transaction>() { buy, buy_2, sell };
            var product = new Product("Foo", "Bar", transactions);
            Assert.AreEqual(1, product.Gains.Count());
            Assert.AreEqual(5, product.Gains.First().TotalGain);
        }
    }
}
