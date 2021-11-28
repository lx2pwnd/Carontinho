using Carontinho.Interface;
using Microsoft.Extensions.Logging;

namespace Carontinho
{
    public class Startup 
    {
        private readonly IHandlerFiles _reader;
        private readonly ILogger<Startup> _logger;

        public Startup(ILogger<Startup> logger, IHandlerFiles reader)
        {
            _logger = logger;
            _reader = reader;
        }

        public void Run()
        {
            var files = _reader.GetFile();
        }
    }
}
