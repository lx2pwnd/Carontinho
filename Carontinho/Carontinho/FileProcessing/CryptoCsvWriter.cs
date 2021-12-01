using Carontinho.Interface;
using Carontinho.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            CreateSubFolder();
        }

        private void CreateSubFolder()
        {
            var folderName = DateTime.Now.ToString("yyyy_mm_dd_hhmmss");
            var path = $"{_path}\\{folderName}";
            if (Directory.Exists(path))
            {
                _logger.LogWarning("*** That path exists already ***");
                return;
            }

            Directory.CreateDirectory(path);
        }
    }
}
