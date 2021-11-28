using Carontinho.Interface;
using Carontinho.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Carontinho
{
    public class CryptoCsvReader : ICryptoCsvReader
    {
        private readonly IHandlerFiles _handlerFiles;
        private readonly ILogger<CryptoCsvReader> _logger;

        public CryptoCsvReader(IHandlerFiles handlerFiles, ILogger<CryptoCsvReader> logger)
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
                var model = getCsvModel(file);
            }
        }

        private List<CryptoFileModel> getCsvModel(string file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
            };
            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();
                csv.Context.RegisterClassMap<CryptoFileModelMapper>();
                return csv.GetRecords<CryptoFileModel>().ToList();
            }
        }
    }
}
