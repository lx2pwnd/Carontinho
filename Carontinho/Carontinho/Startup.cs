using Carontinho.Interface;
using Microsoft.Extensions.Logging;

namespace Carontinho
{
    public class Startup 
    {
        private readonly ICryptoCsvReader _reader;
        private readonly ILogger<Startup> _logger;
        private readonly IAssetFiltering _assetFiltering;

        public Startup(
            ILogger<Startup> logger, 
            ICryptoCsvReader reader,
            IAssetFiltering assetFiltering
            )
        {
            _logger = logger;
            _reader = reader;
            _assetFiltering = assetFiltering;
        }

        public void Run()
        {
            _logger.LogInformation($"*** Starting Elaboration ***");
            var res = _reader.ReadCSV();
            _assetFiltering.FilterAllAssets(res);
        }
    }
}
