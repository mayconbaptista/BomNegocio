
namespace BomNegocio.API.Logging
{
    public class CustomLogger : ILogger
    {
        public string _loggerName;
        public readonly CustomLoggerProviderConfiguration _loggerConfig;

        public CustomLogger(string name, CustomLoggerProviderConfiguration config)
        {
            _loggerName = name;
            _loggerConfig = config;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $"{logLevel.ToString()} {eventId.Id} - {formatter(state, exception)}";

            
        }

        private void EscreverTextoNoArquivo (string mensagem)
        {
            string camminhoArquivoLog = @"C:\Users\maycon.batista\Documents\bomNegocio_log.txt";

            using(StreamWriter streamWriter = new StreamWriter(camminhoArquivoLog, true)) 
            {
                try
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();
                }catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
