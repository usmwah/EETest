using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechnicalTest.Generators;
using TechnicalTest.Models;

namespace TechnicalTest.PageObjects
{
    public class BookingPage: BasePage
    {
        private string bookingPageUrl = ConfigurationManager.AppSettings["WebsiteUrl"];

        private IWebElement FirstName => Driver.FindElement(By.Id("firstname"));
        private IWebElement Surname => Driver.FindElement(By.Id("lastname"));
        private IWebElement Price => Driver.FindElement(By.Id("totalprice"));
        private SelectElement DepositPaid => new SelectElement(Driver.FindElement(By.Id("depositpaid")));
        private IWebElement CheckIn => Driver.FindElement(By.Id("checkin"));
        private IWebElement CheckOut => Driver.FindElement(By.Id("checkout"));
        private IWebElement SaveButton => Driver.FindElement(By.CssSelector("input[value=' Save ']"));     

        public IEnumerable<BookingListItem> bookingListItems => Driver.FindElements(By.CssSelector(".row[id]"))
            .Select(s=> new BookingListItem() {
                FirstName = s.FindElements(By.CssSelector("p")).ElementAt(0),
                Surname = s.FindElements(By.CssSelector("p")).ElementAt(1),
                Price = s.FindElements(By.CssSelector("p")).ElementAt(2),
                Deposit = s.FindElements(By.CssSelector("p")).ElementAt(3),
                CheckIn = s.FindElements(By.CssSelector("p")).ElementAt(4),
                CheckOut = s.FindElements(By.CssSelector("p")).ElementAt(5), 
                Delete = s.FindElement(By.CssSelector("input"))
            });
          
        public BookingPage(IWebDriver webDriver) : base (webDriver)
        {

        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(bookingPageUrl);
            Driver.Manage().Window.Maximize();          
        }

        public void CreateBooking(Booking bookingData)
        {            
            FirstName.SendKeys(bookingData.FirstName);
            Surname.SendKeys(bookingData.Surname);
            Price.SendKeys(bookingData.Price.ToString());            
            DepositPaid.SelectByText(bookingData.Deposit.ToString().ToLower());
            CheckIn.SendKeys(bookingData.CheckIn.ToString("yyyy-MM-dd"));
            CheckOut.SendKeys(bookingData.CheckOut.ToString("yyyy-MM-dd"));
            int oldBookingcount = bookingListItems.Count();
            SaveButton.Click();
           
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => 
                FirstName.GetAttribute("value") == "" &&
                bookingListItems.Count() != oldBookingcount
            );           
        }

        public void DeleteBooking(int index)
        {            
            bookingListItems.ElementAt(index).Delete.Click();         
        }



    }
}
