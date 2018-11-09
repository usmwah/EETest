using Bogus;
using System;
using TechnicalTest.Generators;


namespace TechnicalTest.Models

{
    public class BookingDataGenerator : IGenerator<Booking>
    {
        private readonly Faker<Booking> faker;
        public BookingDataGenerator()
        {
            this.faker = new Faker<Booking>()
                .RuleFor(f => f.FirstName, f => f.Name.FirstName())
                .RuleFor(f => f.Surname, f => f.Name.LastName())
                .RuleFor(f => f.Price, f => Math.Round(f.Random.Double(10,30)))
                .RuleFor(f => f.Deposit, f => false)
                .RuleFor(f => f.CheckIn, f => DateTime.Today)
                .RuleFor(f => f.CheckOut, f => DateTime.Today);
        }
        public Booking Generate()
        {
            return this.faker.Generate();
        }
    }
}
