using Carontinho.Interface;
using Microsoft.Extensions.Logging;

namespace Carontinho
{
    public class Reader : IReader
    {
        private readonly IHandlerFiles _handlerFiles;
        private readonly ILogger<Reader> _logger;

        public Reader(IHandlerFiles handlerFiles, ILogger<Reader> logger)
        {
            _handlerFiles = handlerFiles;
            _logger = logger;
        }

        public void ReadCSV()
        {
            var files = _handlerFiles.GetFiles();

            foreach (var file in files)
            {
                _logger.LogInformation($"Elaborate {file}");
            }
        }
    }
}
