using CalculosPlusvalias.Infrastructure.Enums;
using CalculosPlusvalias.Services.Services.GainCalculators;
using System;

namespace CalculosPlusvalias.Services.Factories
{
    internal static class GainCalculatorFactory
    {
        internal static GainCalculator GetGainCalculator(SoldOperationTypeEnum soldOperationTypeEnum)
            => soldOperationTypeEnum switch
            {
                SoldOperationTypeEnum.BoughtNumberGreaterThanSoldNumber => new SaleTransactionOvercoveredByBoughtTransaction(),
                SoldOperationTypeEnum.BoughtNumberLowerThanSoldNumber => new SaleTransactionPartiallyCoveredByBoughtTransaction(),
                SoldOperationTypeEnum.BoughtNumberEqualsToSoldNumber => new SaleTransactionExactlyCoveredByBoughtTransaction(),
                _ => throw new ArgumentException($"Invalid sold operation type")
            };
    }

    
}
