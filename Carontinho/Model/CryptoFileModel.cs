using CsvHelper.Configuration.Attributes;
using System;

namespace Carontinho.Model
{
    public class CryptoFileModel
    {
        [Name("Timestamp (UTC)")]
        public DateTime TimestampUTC {get; set;}
        [Name("Transaction Description")]
        public string TransactionDescription {get; set;}
        [Name("Currency")]
        public string Currency {get; set;}
        [Name("Amount")]
        public float Amount {get; set;}
        [Name("To Currency")]
        public string ToCurrency {get; set;}
        [Name("To Amount")]
        public string ToAmount {get; set;}
        [Name("Native Currency")]
        public string NativeCurrency {get; set;}
        [Name("Native Amount")]
        public float NativeAmount {get; set;}
        [Name("Native Amount (in USD)")]
        public float NativeAmountIn_USD {get; set;}
        [Name("Transaction Kind")]
        public string TransactionKind {get; set;}
    }
}
