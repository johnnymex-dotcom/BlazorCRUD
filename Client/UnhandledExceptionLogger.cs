using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text;


namespace BlazorCRUD.Client
{
    public class UnhandledExceptionLogger : TextWriter
    {
        private readonly TextWriter _consoleErrorLogger;
        private readonly ILogger _logger;

        public override Encoding Encoding => Encoding.UTF8;

        public UnhandledExceptionLogger(ILogger logger)
        {
            _logger = logger;
            _consoleErrorLogger = Console.Error;
            Console.SetError(this);
        }

        public override void WriteLine(string value)
        {
            _logger.LogCritical(value);
            // Must also route thru original logger to trigger error window.
            _consoleErrorLogger.WriteLine(value);
        }
    }
}

