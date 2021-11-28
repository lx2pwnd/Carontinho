using Carontinho.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Carontinho
{
    public class HandlerFiles : IHandlerFiles
    {
        private readonly ILogger<HandlerFiles> _logger;
        private readonly string _path = ConfigurationManager.AppSettings["FilePath"];

        public HandlerFiles(ILogger<HandlerFiles> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> GetFiles()
        {
            _logger.LogInformation("*** Searching for files in folder *** ");

            string[] fileEntries = Directory.GetFiles(_path);
            _logger.LogInformation($"*** Files found: {fileEntries.Length} ***");

            var files = new List<string>();
            foreach (string file in fileEntries)
                files.Add(file);
            
            return files;
        }
    }
}
