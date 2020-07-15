namespace Amore.Data.Local
{
    /// <summary>
    /// Loads locally stored amore configurations
    /// </summary>
    public interface IAmoreConfigurationLoader
    {
        /// <summary>
        /// Reloads pizze, goodies, etc. from locally stored amore configuration files
        /// </summary>
        void Reload();
    }
}