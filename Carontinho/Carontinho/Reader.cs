using Carontinho.Interface;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.IO;

namespace Carontinho
{
    public class Reader : IReader
    {
        private readonly ILogger<Reader> _logger;
        private readonly string _path = ConfigurationManager.AppSettings["FilePath"];

        public Reader(ILogger<Reader> logger)
        {
            _logger = logger;
        }

        public void ReadCSV()
        {
            _logger.LogInformation("*** Searching for files in folder *** ");

            string[] fileEntries = Directory.GetFiles(_path);
            foreach (string file in fileEntries)
            {

                var fileName = file.Substring(_path.Length + 1);
                _logger.LogInformation($"*** Find file {fileName} ***");
            }

        }
    }
}
