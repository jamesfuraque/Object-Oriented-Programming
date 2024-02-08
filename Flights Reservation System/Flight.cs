using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class Flight
    {
        public int flightID;
        public string flightOrigin;
        public string flightDestination;
        public int MaxSeats { get; set; }
        public int PassengerCount { get; set; }
        private List<Booking> bookings = new List<Booking>();

        public Flight(int flightID, string origin, string destination, int maxSeats)
        {
            this.flightID = flightID;
            this.flightOrigin = origin;
            this.flightDestination = destination;
            this.MaxSeats = maxSeats;
            this.PassengerCount = 0;                              // Initialize passenger count to 0
        }

        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);                                // Add the booking to the list of bookings for this flight
            Console.WriteLine("Booking added to the flight successfully.");
        }

        public void RemoveBooking(Booking booking)
        {
            bookings.Remove(booking);                             // Remove the booking from the list of bookings for this flight
            PassengerCount--;
            Console.WriteLine("Booking removed successfully!");
        }

        public override string ToString()                         // Method to show all the flight details thru string.
        {
            string flightFormattedID = flightID.ToString("D4");   // Format the Flight ID
            string s = "\nFlightID: " + flightFormattedID;        // Show the Flight ID
            s = s + "\nOrigin: " + flightOrigin;                  // Show the Origin of the flight
            s = s + "\nDestination: " + flightDestination;        // Show the Destination of the flight
            s = s + "\nMax Seats: " + MaxSeats;                   // Show the Maximum Capacity of the seats.
            s = s + "\nPassenger Count: " + PassengerCount;       // Show how many passengers are already there.   
            return s;
        }
    }
}