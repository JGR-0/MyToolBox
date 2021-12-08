using CalculosPlusvalias.Services;
using System.Collections.Generic;
using System.Linq;

namespace CalculosPlusvalias.UI.MVC.Models
{
    public class GainsSummaryViewModel
    {
        public GainsSummaryViewModel(IEnumerable<Transaction> transactions)
        {
            Transactions = transactions;
            SetProducts();
        }

        public IEnumerable<Transaction> Transactions { get; private set; }
        public IList<Services.Contexts.Product> Products { get; private set; }

        private void SetProducts()
        {
            Products = new List<Services.Contexts.Product>();
            var transactionsGroupedByISIN = Transactions.GroupBy(x => x.ISIN);

            foreach (var productTransactions in transactionsGroupedByISIN)
            {
                var ISIN = productTransactions.Key;
                var productName = productTransactions.First().ProductName;
                var product = new Services.Contexts.Product(productName, ISIN, productTransactions.ToList());
                Products.Add(product);
            }
        }
    }
}
