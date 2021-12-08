using CalculosPlusvalias.Infrastructure.Enums;
using CalculosPlusvalias.Infrastructure.Extensions;
using CalculosPlusvalias.Services.Factories;
using System;
using System.Collections.Generic;

namespace CalculosPlusvalias.Services.Contexts
{
    public class Gain
    {
        public Gain(Transaction saleReferenceTransaction, IEnumerable<Transaction> buyTransactionsStatus)
        {
            SaleTransaction = saleReferenceTransaction ?? throw new ArgumentNullException(nameof(saleReferenceTransaction));
            BuyTransactionsStatus = buyTransactionsStatus ?? new List<Transaction>();
            TotalGain = CalculateTotalGain();
            Compensable = BuyTransactionsStatus.IsCompensable(SaleTransaction);
        }

        public IEnumerable<Transaction> BuyTransactionsStatus { get; private set; }
        public Transaction SaleTransaction { get; private set; }
        public float TotalGain { get; private set; }
        public bool Compensable { get; private set; }

        private float CalculateTotalGain()
        {
            if (SaleTransaction.Operation != OperationTypesEnum.Sell)
            {
                throw new ArgumentException("Invalid operation type to calculate gains.");
            }

            float gain = 0;

            while (SaleTransaction.RemainingNumber != 0)
            {
                var nextNotCompletlySoldBuy = BuyTransactionsStatus.GetNextNotSoldBuy();
                var soldOperationType = GetSoldOperationType(SaleTransaction.RemainingNumber, nextNotCompletlySoldBuy.RemainingNumber);
                var gainCalculator = GainCalculatorFactory.GetGainCalculator(soldOperationType);
                gain += gainCalculator.GetCalculatedGain(SaleTransaction, nextNotCompletlySoldBuy);
            }

            return gain;
        }

        private static SoldOperationTypeEnum GetSoldOperationType(float soldNumber, float buyNumber)
        {
            if (Math.Abs(buyNumber) < Math.Abs(soldNumber))
            {
                return SoldOperationTypeEnum.BoughtNumberLowerThanSoldNumber;
            }
            else if (Math.Abs(buyNumber) > Math.Abs(soldNumber))
            {
                return SoldOperationTypeEnum.BoughtNumberGreaterThanSoldNumber;
            }
            else
            {
                return SoldOperationTypeEnum.BoughtNumberEqualsToSoldNumber;
            }
        }
    }
}
