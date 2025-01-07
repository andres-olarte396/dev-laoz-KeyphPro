namespace KeyphPro.Domain.Services
{
    /// <summary>
    /// Interface IAppLogger
    /// </summary>
    /// <typeparam name="T">
    /// Type of the class
    /// </typeparam>
    public interface IAppLogger<T>
    {
        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogInformation(string message);
        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogWarning(string message);
        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        void LogError(string message, Exception ex);
    }
}
