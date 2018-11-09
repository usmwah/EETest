using BoDi;
using OpenQA.Selenium;
using System;
using TechnicalTest.Core;
using TechTalk.SpecFlow;

namespace TechnicalTest.Support
{
    [Binding]
    public sealed class GlobalHooks
    {

        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;

        public GlobalHooks(IObjectContainer container)
        {
            this.objectContainer = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            driver = DriverFactory.Create();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
