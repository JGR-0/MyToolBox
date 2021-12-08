using CalculosPlusvalias.Infrastructure;
using CalculosPlusvalias.Infrastructure.Enums;
using System;
using System.Globalization;

namespace CalculosPlusvalias.Services
{
    public class Transaction
    {
        public Transaction() { }

        public Transaction(string[] splittedFileLine)
        {
            SetTransaction(splittedFileLine);
        }

        public Transaction(string fileLine)
        {
            var lineSplitted = fileLine.Split(TransactionColumnsConfig.Splitter);
            SetTransaction(lineSplitted);
        }

        private void SetTransaction(string[] fileLine)
        {
            Date = fileLine[TransactionColumnsConfig.DateColNumber].ToDateTimeFormatted(TransactionColumnsConfig.DateFormat);
            Time = fileLine[TransactionColumnsConfig.TimeColNumber].ToTime();
            ProductName = fileLine[TransactionColumnsConfig.ProductNameColNumber];
            ISIN = fileLine[TransactionColumnsConfig.ISINColNumber];
            OriginalNumber = float.Parse(fileLine[TransactionColumnsConfig.NumberColNumber]);
            RemainingNumber = float.Parse(fileLine[TransactionColumnsConfig.NumberColNumber]);
            LocalUnitPrice = float.Parse(fileLine[TransactionColumnsConfig.LocalUnitPriceColNumber]);
            ExchangeRate = float.Parse(fileLine[TransactionColumnsConfig.ExchangeRateColNumber].Replace("€", "").Trim());
            Comission = float.Parse(fileLine[TransactionColumnsConfig.ComissionColNumber].Replace("€", "").Trim());
            UnitComission = Comission / OriginalNumber;

        }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string ProductName { get; set; }
        public string ISIN { get; set; }
        public float OriginalNumber { get; set; }
        public float RemainingNumber { get; set; }
        public float LocalUnitPrice { get; set; }
        public float ExchangeRate { get; set; }
        public float Comission { get; set; }
        public float UnitComission { get; set; }
        public OperationTypesEnum Operation => OriginalNumber > 0 ? OperationTypesEnum.Buy : OperationTypesEnum.Sell;
        public float GetPriceForNumberInEUR(float number) => Math.Abs(number * LocalUnitPrice / ExchangeRate) + Math.Abs(UnitComission);
        public float UnitCost() => Math.Abs(LocalUnitPrice / ExchangeRate) + Math.Abs(UnitComission);
        
        public float TotalEURPrice => GetPriceForNumberInEUR(OriginalNumber);

        public override string ToString()
        {
            return $"Date: {Date}\t Type: {Operation}\t Number: {OriginalNumber} \t Total €: {(TotalEURPrice)}";
        }
    }
}