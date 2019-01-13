namespace AtolTest
{
    public interface ILogger
    {
        /// <summary>
        /// Write event to log
        /// </summary>
        /// <param name="message">Set of messsages for logging</param>
        void LogEvent(params string[] message);
    }
}