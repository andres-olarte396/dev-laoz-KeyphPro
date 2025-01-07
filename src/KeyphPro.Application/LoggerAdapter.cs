using Serilog;
using KeyphPro.Domain.Services;

namespace KeyphPro.Application
{
    /// <summary>
    /// Logger Adapter
    /// </summary>
    /// <typeparam name="T">
    /// Type of the class
    /// </typeparam>
    /// <seealso cref="KeyphPro.Core.Services.IAppLogger&lt;T&gt;" />
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerAdapter{T}"/> class.
        /// </summary>
        public LoggerAdapter()
        {
            _logger = Log.ForContext<T>();  // Se puede usar el contexto de la clase
        }
        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogInformation(string message)
        {
            _logger.Information(message);
        }
        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }
        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public void LogError(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }
    }
}
