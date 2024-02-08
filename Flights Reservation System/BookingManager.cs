using Project_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class BookingManager
    {
        public int numBookings;
        private int maxBookings;
        private Booking[] bookingList;

        public BookingManager(int max)
        {
            this.numBookings = 0;
            this.maxBookings = max;
            bookingList = new Booking[max];
        }

        public int GenerateBookingNumber()
        {
            return 3000 + numBookings + 1;
        }

        public int GenerateUniqueBookingNumber()                    // Start of GenerateUniqueBookingNumber.
        {
            int newBookingNumber;
            do
            {
                newBookingNumber = GenerateBookingNumber();
            } while (BookingNumberExists(newBookingNumber));

            return newBookingNumber;
        }                                                           // End of GenerateUniqueBookingNumber.

        public bool BookingNumberExists(int bookingNumber)                      // Start of BookingNumberExists method.
        {
            for (int i = 0; i < numBookings; i++)
            {
                if (bookingList[i].BookingNumber == bookingNumber)
                {
                    return true; // Booking with the same number already exists
                }
            }
            return false;        // Booking with the given number does not exist
        }                                                                        // End of BookingNumberExists method.

        public bool MakeBooking(FlightManager flightManager, CustomerManager customerManager)                   //Start of MakeBooking logic
        {
            while (true)
            {                                                        // WHEN ADD BOOKING IS SELECTED:
                Console.WriteLine(flightManager.ViewFlights());      // Show the flights available to the user
                Console.WriteLine(customerManager.ViewCustomers());  // Show the records of customers.

                Console.Write("\nEnter Customer ID: ");              // Ask the user to enter a Customer ID.
                int customerID;
                    if (!int.TryParse(Console.ReadLine(), out customerID))
                    {
                        Console.WriteLine("\nInvalid choice. Please enter a number. \nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                Customers customer = customerManager.GetCustomerById(customerID);

                if (customer == null)
                {
                    Console.WriteLine("Invalid Customer ID. Do you want to continue? (Y/N): ");
                    char continueChoice = Console.ReadKey().KeyChar;
                    if (continueChoice == 'Y' || continueChoice == 'y')
                    {
                        Console.Clear(); // Refresh the console
                        continue;        // Restart the loop
                    }
                    else
                    {
                        return false;    // Exit the method if the user chooses not to continue
                    }
                }

                Console.Write("Enter Flight ID: ");                                         // Ask the user to enter a Flight ID.
                int flightID = Convert.ToInt32(Console.ReadLine());
                Flight flight = flightManager.GetFlightById(flightID);

                if (flight == null)
                {
                    Console.WriteLine("Invalid Flight ID. Do you want to continue? (Y/N): ");
                    char continueChoice = Console.ReadKey().KeyChar;
                    if (continueChoice == 'Y' || continueChoice == 'y')
                    {
                        Console.Clear();                                                    // Refresh the console
                        continue;                                                           // Continue the loop until the user enter's a valid choice.
                    }
                    else
                    {
                        return false;                                                       // Exit the method if the user chooses not to continue.
                    }
                }


                if (flight == null || customer == null)                                     // If the flight and customer doesn't corresponds
                {                                                                           // to what the user entered,
                    Console.WriteLine("Booking failed. Invalid Flight ID or Customer ID."); // we're going to tell the user that the inputs are invalid.
                    return false;
                }

                if (flight.PassengerCount >= flight.MaxSeats)                               // Check if we still have space for our flight.
                {                                                                           // Allow the user if we stil have space for a passenger.
                    Console.WriteLine("Booking failed. The flight is already full.");       // Inform the passenger that we don't have enought space.
                    return false;
                }

                int newBookingNumber = GenerateUniqueBookingNumber();                           // If everything is good, we generate the Booking Number.
                if (numBookings < maxBookings)
                {
                    flight.PassengerCount++;                                                    // We also adding up the number of passengers in that specific flight.
                    bookingList[numBookings] = new Booking(newBookingNumber, flight, customer); // We also add the bookings to the list of our bookings.
                    numBookings++;                                                              // We are adding up the number of bookings.
                    flight.AddBooking(bookingList[numBookings - 1]);
                    customer.AddBooking(bookingList[numBookings - 1]);
                    return true;
                }
                else
                {
                    Console.WriteLine("Booking list is full. Cannot make more bookings.");      // If the booking is full,
                    return false;                                                               // inform the user.
                }
            }
        }                                                                                       // End of MakeBooking logic.

        public string ViewBookings()                             // Start of View Bookings logic.
        {
            if (numBookings == 0)
            {
                return "No bookings available.\n\n";                 // If there's not booking, inform the user.
            }
            string s = " === * LIST OF ALL BOOKINGS * === ";
            for (int i = 0; i < numBookings; i++)
            {
                s = s + "\n" + bookingList[i].ToString();        // This method provides the date, booking details, customer details and flight details.
                s = s + "\n";
            }
            return s;
        }                                                        // End of View Bookings logic.
    }
}