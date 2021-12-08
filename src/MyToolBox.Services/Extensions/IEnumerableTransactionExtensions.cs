using CalculosPlusvalias.Infrastructure.Enums;
using CalculosPlusvalias.Services;
using System.Collections.Generic;
using System.Linq;

namespace CalculosPlusvalias.Infrastructure.Extensions
{
    public static class TransactionExtensions
    {
        public static Transaction GetNextNotSoldBuy(this IEnumerable<Transaction> transactions) 
            => transactions
                .Where(x => x.RemainingNumber > 0 && x.Operation == OperationTypesEnum.Buy)
                .OrderBy(x => x.Date)
                .FirstOrDefault() ?? throw new System.ArgumentNullException(nameof(transactions));

        public static bool IsCompensable(this IEnumerable<Transaction> transactions, Transaction saleToCompensate)
            => !transactions.Where(x => x.Operation == OperationTypesEnum.Buy && saleToCompensate.Date < x.Date)
                .Any(x => (saleToCompensate.Date - x.Date).TotalDays <= 60);
    }
}
