using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechnicalTest.Configuration;

namespace TechnicalTest.Core.Resolvers
{
    internal class ChromeResolver : IDriverResolver
    {
        public string Name
        {
            get
            {
                return DriverTypes.Chrome;
            }
        }

        public IWebDriver Resolve(IDriverInfo driverInfo)
        {
            return new ChromeDriver();
        }
    }
}
