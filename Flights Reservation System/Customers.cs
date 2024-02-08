using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal abstract class Customers
    {
        public int customerID;
        public string customerFirstName;
        public string customerLastName;
        public string customerPhone;
        public int customerAge;
        private List<Booking> bookings = new List<Booking>();

        public Customers(int customerID, string customerFirstName, string customerLastName, string customerPhone, int cAge)
        {
            this.customerID = customerID;
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.customerPhone = customerPhone;
            this.customerAge = cAge;
        }

        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);                              // Add the booking to the list of bookings
        }

        public void RemoveBooking(Booking booking)
        {
            bookings.Remove(booking);                           // Remove the booking from the list of bookings
            Console.WriteLine("Booking removed successfully.");
        }


        public override string ToString()                                                    // Method to show all the Customer's details thru string.
        {
            string formattedID = customerID.ToString("D4");                                  // Format the Customer ID
            string s = "\nCustomer's ID: " + formattedID;                                    // Show the Customer ID
            s += "\nCustomer's Full name: " + customerFirstName + " " + customerLastName;    // Show the Full Name of the customer, combine the First Name and Last Name
            s += "\nPhone #: " + customerPhone;                                              // Show the Phone Number of the customer.
            s += "\n\n[[  BOOKINGS  ]]";                                                            // Show the Bookings they have.
            if (bookings.Count == 0)                                                     // If they don't have booking,
            {
                s += "\nNo bookings available.";                                         // Inform the user that they don't have booking.
            }
            else
            {
                foreach (var booking in bookings)
                {
                    s += $"\nBooking Number: {booking.BookingNumber}" +
                         $"\n\n[[  FLIGHTS  ]] {booking.BookedFlight}" +
                         $"\nDate: {booking.Date}";
                }
            }
            return s;
        }
    }
}