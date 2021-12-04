using Carontinho.Interface;
using Carontinho.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace Carontinho.FileProcessing
{
    public class CryptoCsvWriter : ICryptoCsvWriter
    {
        private readonly ILogger<CryptoCsvWriter> _logger;
        private readonly string _path = ConfigurationManager.AppSettings["OutputFilePath"];


        public CryptoCsvWriter(ILogger<CryptoCsvWriter> logger)
        {
            _logger = logger;
        }

        public void WriteCSV(IDictionary<string, List<CryptoFileModel>> assetDictionary)
        {
            var path = CreateSubFolder();

            foreach (var asset in assetDictionary)
            {
                try
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ",",
                    };
                    var fileName = $"{path}\\{asset.Key}_transactions_record_{DateTime.Now.ToString("yyyy_mm_dd_hhmmss")}.csv";
                    using (var writer = new StreamWriter(fileName))
                    using (var csv = new CsvWriter(writer, config))
                    {
                        csv.WriteRecords(assetDictionary[asset.Key]);
                    }
                }
                catch
                { 
                    _logger.LogWarning($"*** Error during the generation for the asset: {asset.Key} ***"); 
                };
            }
        }

        private string CreateSubFolder()
        {
            var folderName = DateTime.Now.ToString("yyyy_MM_dd_hhmmss");
            var path = $"{_path}\\{folderName}";
            if (Directory.Exists(path))
            {
                _logger.LogWarning("*** That path exists already ***");
                return path;
            }

            Directory.CreateDirectory(path);
            return path;
        }
    }
}
