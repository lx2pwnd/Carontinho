using Carontinho.Model;
using System.Collections.Generic;

namespace Carontinho.Interface
{
    public interface ICryptoCsvWriter
    {
        void WriteCSV(IDictionary<string, List<CryptoFileModel>> assetDictionary);
    }
}
