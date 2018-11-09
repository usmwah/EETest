using NUnit.Framework;
using System.Linq;
using TechnicalTest.Models;
using TechnicalTest.PageObjects;
using TechTalk.SpecFlow;

namespace TechnicalTest.StepDefinitions
{
    [Binding]
    public sealed class BookingManagementSteps
    {
        private BookingPage bookingPage;

        public BookingManagementSteps(BookingPage bookingPage)
        {
            this.bookingPage = bookingPage;
        }


        [Given(@"the user is on hotel bookings page")]
        public void GivenTheUserIsOnHotelBookingsPage()
        {
            bookingPage.Open();
        }


        [When(@"the user creates a new booking")]
        public void WhenTheUserCreatesANewBooking()
        {
            BookingDataGenerator bookingDataGenerator = new BookingDataGenerator();
            Booking bookingData = bookingDataGenerator.Generate();
            bookingPage.CreateBooking(bookingData);

            ScenarioContext.Current["BookingData"] = bookingData;
        }


        [Then(@"the booking is added to the list of bookings")]
        public void ThenTheBookingIsAddedToTheListOfBookings()
        {
            Booking bookingData = (Booking)ScenarioContext.Current["BookingData"];
            Assert.IsNotEmpty(bookingPage.bookingListItems
                .Where(b => b.FirstName.Text == bookingData.FirstName
                    && b.Surname.Text == bookingData.Surname
                    && double.Parse(b.Price.Text) == bookingData.Price
                ));
        }


        [Given(@"there are one or more bookings")]
        public void GivenThereAreOneOrMoreBookings()
        {
            if (bookingPage.bookingListItems.Count() == 0)
            {
                BookingDataGenerator bookingDataGenerator = new BookingDataGenerator();
                Booking bookingData = bookingDataGenerator.Generate();
                bookingPage.CreateBooking(bookingData);
            }
                      
            ScenarioContext.Current["SavedBookingCount"] = bookingPage.bookingListItems.Count();
        }


        [When(@"the user deletes the first booking")]
        public void WhenTheUserDeletesTheFirstBooking()
        {
            bookingPage.DeleteBooking(0);
        }
       

        [Then(@"The number of bookings is reduced by (.*)")]
        public void ThenTheNumberOfBookingsIsReducedBy(int count)
        {            
            int expectedBookings = (int)ScenarioContext.Current["SavedBookingCount"] - count;
            int actualBookings = bookingPage.bookingListItems.Count();            
            Assert.AreEqual(expectedBookings, actualBookings);
        }       
        
    }
}
