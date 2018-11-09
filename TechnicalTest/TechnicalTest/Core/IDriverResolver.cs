using OpenQA.Selenium;
using TechnicalTest.Configuration;

namespace TechnicalTest.Core
{
    public interface IDriverResolver
    {
        string Name { get; }
        IWebDriver Resolve(IDriverInfo driverInfo);
    }
}
