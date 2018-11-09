using OpenQA.Selenium;
using System;

namespace TechnicalTest.PageObjects
{
    public class BookingListItem
    {
        public IWebElement FirstName { get; set; }
        public IWebElement Surname { get; set; }
        public IWebElement Price { get; set; }
        public IWebElement Deposit { get; set; }
        public IWebElement CheckIn { get; set; }
        public IWebElement CheckOut { get; set; }
        public IWebElement Delete { get; set; }

    }
}
