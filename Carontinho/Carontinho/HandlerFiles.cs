using Carontinho.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Carontinho
{
    public class HandlerFiles : IHandlerFiles;
    {
        private readonly ILogger<HandlerFiles> _logger;
        private readonly string _path = ConfigurationManager.AppSettings["FilePath"];

        public HandlerFiles(ILogger<HandlerFiles> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> GetFile()
        {
            _logger.LogInformation("*** Searching for files in folder *** ");

            string[] fileEntries = Directory.GetFiles(_path);
            var files = new List<string>();
            foreach (string file in fileEntries)
            {
                var fileName = file.Substring(_path.Length + 1);
                _logger.LogInformation($"*** Find file {fileName} ***");
                files.Add(fileName);
            }
            return files;
        }
    }
}
