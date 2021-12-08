using System;

namespace CalculosPlusvalias.Services.Services.GainCalculators
{
    internal sealed class SaleTransactionOvercoveredByBoughtTransaction : GainCalculator
    {
        internal override float GetCalculatedGain(Transaction sale, Transaction buy)
        {
            var totalBoughtCost = sale.RemainingNumber * buy.UnitCost();
            var totalSellGain = sale.RemainingNumber * sale.UnitCost();
            buy.RemainingNumber -= Math.Abs(sale.RemainingNumber);
            sale.RemainingNumber = 0;
            return Math.Abs(totalSellGain) - Math.Abs(totalBoughtCost);
        }
    }
}
