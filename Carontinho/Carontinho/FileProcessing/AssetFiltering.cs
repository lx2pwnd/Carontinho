using Carontinho.Interface;
using Carontinho.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carontinho.FileProcessing
{
    public class AssetFiltering : IAssetFiltering
    {
        private readonly ILogger<AssetFiltering> _logger;

        public AssetFiltering(ILogger<AssetFiltering> logger)
        {
            _logger = logger; 
        }

        public IDictionary<string, List<CryptoFileModel>> FilterAllAssets(IEnumerable<IEnumerable<CryptoFileModel>> mappedFiles)
        {
            var assetDictionary = new Dictionary<string, List<CryptoFileModel>>();

            foreach (var mappedFile in mappedFiles)
            {
                var groupedAsset = mappedFile
                              .GroupBy(c => c.Currency)
                              .OrderBy(x => x.Key)
                              .ToDictionary(x => x.Key, x=>x.ToList());

                foreach (var asset in groupedAsset)
                {
                    if (!assetDictionary.ContainsKey(asset.Key))
                        assetDictionary.Add(asset.Key, asset.Value);
                    else
                        assetDictionary[asset.Key].AddRange(asset.Value);
                }
            }

            return assetDictionary;
        }
    }
}
