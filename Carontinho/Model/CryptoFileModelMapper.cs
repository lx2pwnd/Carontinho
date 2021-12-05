using CsvHelper.Configuration;

namespace Carontinho.Model
{
    public class CryptoFileModelMapper : ClassMap<CryptoFileModel>
    {
        public CryptoFileModelMapper()
        {
            Map(m => m.TimestampUTC).Name("Timestamp (UTC)");
            Map(m => m.TransactionDescription).Name("Transaction Description");
            Map(m => m.Currency).Name("Currency");
            Map(m => m.Amount).Name("Amount");
            Map(m => m.ToCurrency).Name("To Currency");
            Map(m => m.ToAmount).Name("To Amount");
            Map(m => m.NativeCurrency).Name("Native Currency");
            Map(m => m.NativeAmount).Name("Native Amount");
            Map(m => m.NativeAmountIn_USD).Name("Native Amount (in USD)");
            Map(m => m.TransactionKind).Name("Transaction Kind");
        }
    }
}
