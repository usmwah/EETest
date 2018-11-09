using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechnicalTest.Configuration;
using TechnicalTest.Core.Resolvers;

namespace TechnicalTest.Core
{
    public class DriverFactory
    {
        private static List<IDriverResolver> resolvers = new List<IDriverResolver>()
        {
            new ChromeResolver()
        };

        public static List<IDriverResolver> Resolvers
        {
            get { return resolvers; }
            set { resolvers = value; }
        }
        public static IDriverInfo DriverInfo
        {
            get { return Config.Instance; }
        }

        public static IWebDriver Create()
        {
            var driverInfo = Config.Instance;
            return Resolvers
                .First(r => r.Name == driverInfo.DriverType)
                .Resolve(driverInfo);
        }

    }
}
