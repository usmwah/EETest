using System.Configuration;

namespace TechnicalTest.Configuration
{
    internal static class Config
    {  
        static Config()
        {
            Instance = (DriverSection)ConfigurationManager.GetSection("Driver");
        }

        public static DriverSection Instance
        {
            get;
        }
    }
}
