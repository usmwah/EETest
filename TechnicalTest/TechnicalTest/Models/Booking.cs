using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Models
{
    public class Booking
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public double Price { get; set; }
        public bool Deposit { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }        

    }
}
