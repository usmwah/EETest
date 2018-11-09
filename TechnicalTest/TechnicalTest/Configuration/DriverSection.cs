using System.Configuration;

namespace TechnicalTest.Configuration
{
    public class DriverSection : ConfigurationSection, IDriverInfo
    { 
        [ConfigurationProperty("driverType", IsRequired = true)]
        public string DriverType
        {
            get { return (string)this["driverType"]; }
        }
    
    }
}
