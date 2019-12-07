using System;
using System.Collections.Generic;
using static System.Configuration.ConfigurationManager;
using static System.Configuration.ConfigurationUserLevel;

namespace Cached.Classes
{
    /// <summary>
    /// Simple example for loaded data once then each time
    /// data is requested the cached version is retrieved for
    /// Application data.
    ///
    /// NOTE
    /// * The Customer part is not advised, here only for
    ///   discussion in the TechNet article.
    /// </summary>
    public sealed class CachedInformation
    {
        private static readonly Lazy<CachedInformation> Lazy =
            new Lazy<CachedInformation>(() =>
                new CachedInformation());

        public static CachedInformation Instance => Lazy.Value;

        public Customer Customer { get; set; }

        private readonly string _configurationFolder;
        private readonly List<Application> _applications;
        public List<Application> Applications => _applications;
        public string ConfigurationFolder => _configurationFolder;

        /// <summary>
        /// Called once
        /// </summary>
        protected CachedInformation()
        {
            var fileOperations = new FileOperations();

            _applications = fileOperations.LoadApplicationData(
                Properties.Settings.Default.AppDataFile);

            Customer = new Customer();

            /*
             * Get configuration folder name for where user settings are stored.
             * This does not mean the folder exists so before attempting to access
             * use Directory.Exists
             */
            _configurationFolder = OpenExeConfiguration(
                PerUserRoamingAndLocal).FilePath.Replace("\\user.config", "");

        }
    }
}
