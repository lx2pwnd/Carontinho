using Carontinho.Model;
using System.Collections.Generic;
using System.Linq;

namespace Carontinho.Interface
{
    public interface IAssetFiltering
    {
        IDictionary<string, List<CryptoFileModel>> FilterAllAssets(IEnumerable<IEnumerable<CryptoFileModel>> mappedFiles);
    }
}
