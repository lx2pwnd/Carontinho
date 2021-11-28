using Carontinho.Interface;
using Microsoft.Extensions.Logging;

namespace Carontinho
{
    public class Startup 
    {
        private readonly IReader _reader;
        private readonly ILogger<Startup> _logger;

        public Startup(ILogger<Startup> logger, IReader reader)
        {
            _logger = logger;
            _reader = reader;
        }

        public void Run()
        {
            _reader.ReadCSV();
        }
    }
}
