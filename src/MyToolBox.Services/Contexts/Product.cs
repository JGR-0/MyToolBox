using CalculosPlusvalias.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculosPlusvalias.Services.Contexts
{
    public class Product
    {
        public Product(string name, string isin, IEnumerable<Transaction> transactions)
        {
            Name = name;
            ISIN = isin;
            Transactions = transactions ?? new List<Transaction>();
            ResetCalculus();
            foreach(var sale in Sales)
            {
                var gain = new Gain(sale, Buys);
                Gains = Gains.Append(gain);
            }
        }

        #region Public
        public string Name { get; private set; }
        public string ISIN { get; private set; }
        public IEnumerable<Transaction> Transactions { get; private set; }
        public IEnumerable<Transaction> Buys { get; private set; }
        public IEnumerable<Transaction> Sales { get; private set; }
        public IEnumerable<Gain> Gains { get; private set; }
        public IEnumerable<IGrouping<int, Gain>> GainsPerYear => Gains.Where(x => x.Compensable).GroupBy(x => x.SaleTransaction.Date.Year);
        public IEnumerable<Transaction> CurrentYearSales => Sales.Where(x => x.Date.Year == DateTime.Now.Year);
        #endregion

        #region Private
        private void ResetBuys() => Buys = Transactions.Where(x => x.Operation == OperationTypesEnum.Buy);
        private void ResetSells() => Sales = Transactions.Where(x => x.Operation == OperationTypesEnum.Sell);
        private void ResetGains() => Gains = new List<Gain>();

        private void ResetCalculus()
        {
            ResetBuys();
            ResetSells();
            ResetGains();
        } 
        #endregion
    }
}
