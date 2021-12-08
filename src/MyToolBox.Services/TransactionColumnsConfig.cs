using System;

namespace CalculosPlusvalias.Services
{
    public static class TransactionColumnsConfig
    {
        internal static string Splitter { get; private set; }
        internal static int DateColNumber { get; private set; }
        internal static int TimeColNumber { get; private set; }
        internal static int ProductNameColNumber { get; private set; }
        internal static int ISINColNumber { get; private set; }
        internal static int NumberColNumber { get; private set; }
        internal static int LocalUnitPriceColNumber { get; private set; }
        internal static int ExchangeRateColNumber { get; private set; }
        internal static int ComissionColNumber { get; private set; }
        
        public static void ConfigureTransactionColumnsConfig(
            string splitter
            , int? dateColNumber
            , int? timeColNumber
            , int? productNameColNumber
            , int? iSINColNumber
            , int? numberColNumber
            , int? localUnitPriceColNumber
            , int? exchangeRateColNumber
            , int? comissionColNumber
            )
        {
            Splitter = splitter ?? throw new ArgumentNullException(nameof(splitter));
            DateColNumber = dateColNumber ?? throw new ArgumentNullException(nameof(dateColNumber));
            TimeColNumber = timeColNumber ?? throw new ArgumentNullException(nameof(timeColNumber));
            ProductNameColNumber = productNameColNumber ?? throw new ArgumentNullException(nameof(productNameColNumber));
            ISINColNumber = iSINColNumber ?? throw new ArgumentNullException(nameof(iSINColNumber));
            NumberColNumber = numberColNumber ?? throw new ArgumentNullException(nameof(numberColNumber));
            LocalUnitPriceColNumber = localUnitPriceColNumber ?? throw new ArgumentNullException(nameof(localUnitPriceColNumber));
            ExchangeRateColNumber = exchangeRateColNumber ?? throw new ArgumentNullException(nameof(exchangeRateColNumber));
            ComissionColNumber = comissionColNumber ?? throw new ArgumentNullException(nameof(comissionColNumber));
        }

        private static int GetValueFromConsole(string columnName)
        {
            Console.WriteLine($"Insert the column number for: {columnName}. (First column is 0)");
            if(!int.TryParse(Console.ReadLine(), out int colNumber))
            {
                Console.WriteLine("Value must be a number");
                return GetValueFromConsole(columnName);
            }
            return colNumber;
        }
    }
}
