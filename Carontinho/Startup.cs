using Carontinho.Interface;
using Microsoft.Extensions.Logging;

namespace Carontinho
{
    public class Startup 
    {
        private readonly ILogger<Startup> _logger;
        private readonly IAssetFiltering _assetFiltering;
        private readonly ICryptoCsvWriter _cryptoCsvWriter;

        public Startup(
            ILogger<Startup> logger, 
            IAssetFiltering assetFiltering,
            ICryptoCsvWriter cryptoCsvWriter
            )
        {
            _logger = logger;
            _assetFiltering = assetFiltering;
            _cryptoCsvWriter = cryptoCsvWriter;
        }

        public void Run()
        {
            _logger.LogInformation($"*** Starting Elaboration ***");
            var mappedFiles = _assetFiltering.FilterAllAssets();

            _logger.LogInformation("Starting generation files");
            _cryptoCsvWriter.WriteCSV(mappedFiles);
        }
    }
}
