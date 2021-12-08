using System;

namespace CalculosPlusvalias.Services.Services.GainCalculators
{
    internal sealed class SaleTransactionPartiallyCoveredByBoughtTransaction : GainCalculator
    {
        internal override float GetCalculatedGain(Transaction sale, Transaction buy)
        {
            var totalBoughtCost = buy.RemainingNumber * buy.UnitCost();
            var totalSellGain = buy.RemainingNumber * sale.UnitCost();
            sale.RemainingNumber += Math.Abs(buy.RemainingNumber);
            buy.RemainingNumber = 0;
            return Math.Abs(totalSellGain) - Math.Abs(totalBoughtCost);
        }
    }
}
