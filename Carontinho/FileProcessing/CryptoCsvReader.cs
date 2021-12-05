using Carontinho.Interface;
using Carontinho.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Carontinho.FileProcessing
{
    public class CryptoCsvReader : ICryptoCsvReader
    {
        private readonly IHandlerFiles _handlerFiles;
        private readonly ILogger<CryptoCsvReader> _logger;
        private readonly string _path = ConfigurationManager.AppSettings["InputFilePath"];


        public CryptoCsvReader(IHandlerFiles handlerFiles, ILogger<CryptoCsvReader> logger)
        {
            _handlerFiles = handlerFiles;
            _logger = logger;
        }

        public IEnumerable<IEnumerable<CryptoFileModel>> ReadCSV()
        {
            var files = _handlerFiles.GetFiles();

            var allMappedFiles = new List<List<CryptoFileModel>>();

            foreach (var file in files)
            {
                _logger.LogInformation($"Mapping file: {file.Substring(_path.Length+1)}");
                allMappedFiles.Add(getCsvModel(file));
            }

            return allMappedFiles;
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
