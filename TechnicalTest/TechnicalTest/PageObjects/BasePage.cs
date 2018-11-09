using OpenQA.Selenium;

namespace TechnicalTest.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

    }
}
