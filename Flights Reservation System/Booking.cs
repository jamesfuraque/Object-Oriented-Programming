using Project_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class Booking
    {
        public string BookingDate { get; }
        public int BookingNumber { get; }
        public Flight BookedFlight { get; }
        public Customers BookedCustomer { get; }
        public DateTime Date { get; private set; }

        public Booking(int bookingNumber, Flight bookedFlight, Customers bookedCustomer)
        {
            BookingDate = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            BookingNumber = bookingNumber;
            BookedFlight = bookedFlight;
            BookedCustomer = bookedCustomer;
            Date = DateTime.Now;
        }

        public override string ToString()                       // Method to make a booking details into a string
        {
            string s = $"\nBooking Number: {BookingNumber}";    // Show the Booking Number
            s += $"\nBooking Date: {BookingDate}\n\n";          // Show the Booking Date
            s += $"FLIGHT DETAILS: {BookedFlight}\n\n";         // Show the Flight Details.
            s += $"CUSTOMER DETAILS: {BookedCustomer}\n";       // Show the Customer Details.
            s += "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*";
            return s;
        }
    }
}