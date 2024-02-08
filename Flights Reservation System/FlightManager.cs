using Project_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class FlightManager
    {
        public int numFlights;
        protected int maxFlights;
        public Flight[] flightList;
        private int numBookings;
        private int maxBookings;
        private Booking[] bookingList;

        public FlightManager(int max, int maxBookings)
        {
            this.numFlights = 0;
            this.maxFlights = max;
            flightList = new Flight[max];
            this.numBookings = 0;
            bookingList = new Booking[max];
        }

        public int GenerateFlightID()               // Method to generate a flightID
        {
            return 2000 + numFlights + 1;           // We want the flight ID's to start at 2000.
        }

        public int GenerateUniqueFlightID()         // Method to have a unique ID.
        {                                           // We don't want the same flight ID.
            int newFlightID;
            do
            {
                newFlightID = GenerateFlightID();
            } while (FlightIDExists(newFlightID));

            return newFlightID;                     // Once we have a unique ID, method exits the loop and returns a uniqueID.
        }

        public void AddFlight(string origin, string destination, int maxSeats)                      // Method to add a flight.
        {
            int newFlightID = GenerateUniqueFlightID();                                             // Generate a unique ID so we don't have duplicate ID's.
            if (numFlights < maxFlights)                                                            // Check if the number of flights we have is still less than
            {                                                                                       // the maximum number of flights we can have.
                flightList[numFlights] = new Flight(newFlightID, origin, destination, maxSeats);    // Create a new flight object.
                numFlights++;                                                                       // Increment the counts of existing flights.
                Console.WriteLine("Flight added successfully.");                                    // Inform the user that the addition of flight is successful.
            }
            else
            {
                Console.WriteLine("Flight list is full. Cannot add more flights.");                 // Inform the user if the flight is full.
            }
        }



        public bool FlightIDExists(int flightID)          // Method for us to know if a Flight ID is already existing.
        {
            for (int i = 0; i < numFlights; i++)          // Iterates in the existing flights in the flightList array.
            {
                if (flightList[i].flightID == flightID)   // Check if there is a match in our flight ID's.
                {
                    return true;                          // Flight with the same ID already exists
                }
            }
            return false;                                 // Flight with the given ID does not exist
        }

        public string ViewFlights()                             // Method to view our flights.
        {
            if (numFlights == 0)                                // If we don't have existing flights,
            {                                                   // inform the user that there is no
                return "No flights available.";                 // available flights.   
            }
            string s = " === * LIST OF ALL FLIGHTS * === ";
            for (int i = 0; i < numFlights; i++)                // Iterates through the existing flights in our flightList array.
            {
                s = s + "\n" + flightList[i].ToString();
                s = s + "\n";
            }
            return s;                                           // Print all the details of the flights we have.
        }

        public bool DeleteFlight(int flightID)            // Method to Delete a flight using their flightID
        {
            int flightIndex = -1;                         // Initialize a variable to store the index. Set to -1 to indicate that the flight was not found.
            for (int i = 0; i < numFlights; i++)          // Find the index of the flight with the specified ID
            {
                if (flightList[i].flightID == flightID)   // Check if we have a match in our flightID.
                {
                    flightIndex = i;                      // Flight with specified ID is found.
                    break;                                // Terminate the loop.
                }
            }

            if (flightIndex == -1)                                                         // Check if the flightIndex is still -1 after the loop.
            {
                Console.WriteLine("Flight not found. Please provide a valid flight ID.");  // If it is, there's no flight was found using the specified flight ID.
                return false;                                                              // return the logic as false.
            }

            if (FlightHasBookings(flightID))                                                                 // If flight has bookings,
            {                                                                                                // we cannot delete it.
                Console.WriteLine("Cannot delete the flight. There are customers booked on this flight.");   // Inform the user about it.
                return false;
            }

            if (flightList[flightIndex].PassengerCount >= 1)                                                 // If there is a passenger in the specific flight
            {                                                                                                // we cannot delete it too.
                Console.WriteLine("Cannot delete the flight. There's a customer who booked this flight.");   // Inform the user that we cannot delete it.
                return false;
            }

            for (int i = 0; i < numBookings; i++)
            {
                if (bookingList[i] != null && bookingList[i].BookedFlight != null &&
                    bookingList[i].BookedFlight.flightID == flightID)
                {
                    bookingList[i].BookedFlight.RemoveBooking(bookingList[i]);
                    bookingList[i].BookedCustomer.RemoveBooking(bookingList[i]);
                    // Remove the booking by shifting the remaining elements.
                    for (int j = i; j < numBookings - 1; j++)
                    {
                        bookingList[j] = bookingList[j + 1];
                    }
                    numBookings--;                                                         // Decrease the number of bookings.
                    i--;                                                                   // Adjust the index since we shifted the elements.
                }
            }

            for (int i = flightIndex; i < numFlights - 1; i++)
            {
                flightList[i] = flightList[i + 1];
            }

            // If the flight is found; 
            numFlights--;                                                                  // Decrement the number of flights we have.
            Console.WriteLine("Flight successfully deleted!");                             // Inform the user that the flight was successfully deleted.
            return true;
        }

        private bool FlightHasBookings(int flightID)                    // Method to see if Flight has bookings.
        {
            for (int i = 0; i < numBookings; i++)                       // Iterate through bookings to check if the flight has any.
            {
                if (bookingList[i] != null &&
                    bookingList[i].BookedFlight != null &&
                    bookingList[i].BookedFlight.flightID == flightID)
                {
                    return true;                                        // Flight has bookings.
                }
            }
            return false;                                               // Flight has no bookings.
        }

        public Flight GetFlightById(int flightId)           // Method to get a flight using the Flight ID.
        {
            for (int i = 0; i < numFlights; i++)            // Iterates to the existing flights we have in the array.
            {
                if (flightList[i].flightID == flightId)     // Check if we have a match in our flight ID.
                {
                    return flightList[i];                   // Return the flight with the specified ID.
                }
            }
            return null;                                    // Flight with the specified ID not found.
        }

        public string ViewParticularFlight(int flightID)           // Method to View a Particular FLight.
        {
            for (int i = 0; i < numFlights; i++)                   // Iterates to the existing flights we have in the array.
            {
                if (flightList[i].flightID == flightID)            // Check if we have a match in our flight ID.
                {
                    return $"Flight Details:\n{flightList[i]}\n";  // Return the flight details.
                }
            }
            return "Flight not found.";                            // Inform the user that we don't have the specified flight.
        }
    }
}