using Carontinho.Model;
using System.Collections.Generic;

namespace Carontinho.Interface
{
    public interface ICryptoCsvReader
    {
        IEnumerable<IEnumerable<CryptoFileModel>> ReadCSV();
    }
}