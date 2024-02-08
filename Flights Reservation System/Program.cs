using Project_OOP;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_OOP
{
    internal class AirlineCoordinator
    {
        private CustomerManager customersManager;
        private FlightManager flightManager;
        private BookingManager bookingManager;

        public AirlineCoordinator()
        {
            customersManager = new CustomerManager(200);
            flightManager = new FlightManager(15, 15);
            bookingManager = new BookingManager(50);
        }

        public void Run()                                                           // MAIN MENU
        {
            while (true)
            {
                Console.WriteLine("* == FLIGH HIGH AIRLINES == *\n\n");
                Console.WriteLine("~ MAIN MENU ~\n");
                Console.WriteLine("1. Customer");                                  // Allows the user to use Customer's Menu.
                Console.WriteLine("2. Flights");                                   // Allows the user to use Flight's Menu.
                Console.WriteLine("3. Booking");                                   // Allows the user to use Booking Menu.
                Console.WriteLine("4. Exit\n\n");                                  // Allows the user to exit the program.

                Console.WriteLine("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int mainChoice))
                {
                    switch (mainChoice)
                    {
                        case 1:
                            RunCustomerMenu();       // Run the Customer Menu
                            break;
                        case 2:
                            RunFlightMenu();         // Run the Flights Menu
                            break;
                        case 3:
                            RunBookingMenu();        // Run the Booking Menu
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Thank you for using Fly High Airline's System!\n\n3");
                            Environment.Exit(0);     // Exit the program.
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");     // If input is wrong, let the user know.
                            Console.WriteLine("\nPress any key to continue.");          // Allow them to continue if they choose any key.
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a number.");
                    Console.WriteLine("Press any key to continue.....");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }                                                                               // END OF MAIN MENU


        private void RunCustomerMenu()                                                 // CUSTOMERS MENU
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("* == FLIGH HIGH AIRLINES == *\n\n");
                Console.WriteLine("~ CUSTOMER'S MENU ~\n");
                Console.WriteLine("1. Add Customer");                                   // Allows the user to add customer.
                Console.WriteLine("2. View Customers");                                 // Allows the user to view the list of customers.
                Console.WriteLine("3. Delete Customer");                                // Allows the user to delete a customer.
                Console.WriteLine("4. Back to Main Menu\n\n");                          // Allows the user to go back to Main Menu.

                Console.WriteLine("Enter your choice: ");                               // Ask the user for their choice.
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nInvalid choice. Please enter a number. \nPress any key to continue.....");
                    Console.ReadKey();
                    continue;
                }
                string firstName, lastName, phone;
                int customerAge;

                switch (choice)
                {
                    case 1:                                                 // Start of Add Customer logic.
                        Console.Clear();
                        Console.WriteLine("Enter First Name: ");            // Ask the user to input a first name.
                        firstName = Console.ReadLine();                     // Pass the input to firstName.

                        Console.WriteLine("\nEnter Last Name: ");           // Ask the user to input a last name.
                        lastName = Console.ReadLine();                      // Pass the input to lastName.

                        Console.WriteLine("\nEnter Phone Number: ");        // Ask the user for phone number.
                        phone = Console.ReadLine();                         // Pass the input to phone.

                        Console.WriteLine("\nEnter age: ");                 // Ask the user fo age.
                        if (!int.TryParse(Console.ReadLine(), out customerAge))               // Pass the input to customer age and convert it to int.
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number."); // Remind the user to put a valid number.
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            continue;                                                         // Go back to Customer Menu
                        }

                        if (customersManager.AddCustomer(firstName, lastName, phone, customerAge))     // If everything is good.
                        {                                                                              // inform the user that
                            Console.WriteLine("\nCustomer successfully added!");                       // the customer is successfully added
                        }
                        else                                                                           // If everything went bad 
                        {                                                                              // inform the user that 
                            Console.WriteLine("\nCustomer addition failed.");                          // adding a customer was unsuccessful.
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        break;                                               // End of Add Customer Logic
                    case 2:                                                  // Start of View Customers.
                        if (customersManager.numCustomer == 0)               // Check if we have lists of customers.
                        {
                            Console.WriteLine("\n\nCustomer list is empty.");// If we don't have any, inform the user.
                            Console.WriteLine("Press any key to continue."); // Allow them to exit.
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine(customersManager.ViewCustomers()); // Call the method ViewCustomers
                        Console.WriteLine("\nPress any key to continue.");   // to give a list of all the customers.
                        Console.ReadKey();
                        Console.Clear();
                        break;                                               // End of View Customers.   
                    case 3:                                                        // Start of Delete a customer.
                        if (customersManager.numCustomer == 0)                     // Check if we have existing customers.
                        {
                            Console.WriteLine("\n\nCustomer list is empty.");      // If don't have existing customers, inform the user.
                            Console.WriteLine("Press any key to continue.");       // Allow the user to exit.
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("Enter First Name: ");                   // Ask the user to enter first name
                        string firstNameToDelete = Console.ReadLine();             // of the customer that they want to delete.

                        Console.WriteLine("\nEnter Last Name: ");                  // Ask the user to enter last name
                        string lastNameToDelete = Console.ReadLine();              // of the customer that they want to delete.

                        Console.WriteLine("\nEnter Phone Number: ");               // Ask the user to enter the phone number
                        string phoneToDelete = Console.ReadLine();                 // of the customer that they want to delete.


                        if (customersManager.DeleteCustomer(firstNameToDelete, lastNameToDelete, phoneToDelete))
                        {
                            Console.Clear();                                                // If the customer is removed,
                            Console.WriteLine("Customer successfully deleted!");            // inform the user.
                        }
                        else
                        {
                            Console.Clear();                                                // If the customer wasn't deleted,
                            Console.WriteLine("Customer removal failed or canceled.");      // inform the user.
                        }

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        break;                                                               // End of Delete a Customer logic.                             
                    case 4:
                        Console.Clear();
                        return;                                                              // Exit the customer menu and return to the main menu
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");            // Inform the user that they're entering wrong choice.
                        break;
                }
            }
        }                                                                                   // END OF CUSTOMER MENU

        private void RunFlightMenu()                                                    // FLIGHTS MENU
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("* == FLIGH HIGH AIRLINES == *\n\n");
                Console.WriteLine("~ FLIGHTS MENU ~\n");
                Console.WriteLine("1. Add Flight");                                    // Allows the user to add flight.
                Console.WriteLine("2. View Flights");                                  // Allows the user to view all the flights.
                Console.WriteLine("3. View Particular Flight");                        // Allows the user to view a particular flight.
                Console.WriteLine("4. Delete Flight");                                 // Allows the user to delete a flight.
                Console.WriteLine("5. Back to Main Menu\n\n");                         // Allows the user to go back to the MAIN MENU.

                Console.WriteLine("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    string origin, destination;
                    int maxSeats;

                    switch (choice)
                    {
                        case 1:                                          // Start of the logic to Add Flight
                            Console.Clear();
                            Console.WriteLine("Enter Origin: ");                        // Ask the user for origin.
                            origin = Console.ReadLine();                                // Pass the input to our origin variable.

                            Console.WriteLine("\nEnter Destination: ");                 // Ask the user for destination
                            destination = Console.ReadLine();                           // Pass the input to our destination variable.

                            Console.WriteLine("\nEnter Max Seats: ");                   // Ask the user for the max seats.                     
                                if (!int.TryParse(Console.ReadLine(), out maxSeats))    // Pass the input to maxSeats and convert it to int.
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number."); // Remind the user to put a valid number.
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;                                           // Go back to Flight Menu
                                }

                            flightManager.AddFlight(origin, destination, maxSeats);     // Add the flight to using our method AddFlight.
                            break;                                                      // End of the Add Flight logic.           
                        case 2:                                                   // Start of logic to View Flights
                            if (flightManager.numFlights == 0)                    // Check if we have existing flights.
                            {
                                Console.WriteLine("\n\nFlight list is empty.");   // If we don't have existing flights, inform the user.
                                Console.WriteLine("Press any key to continue.");  // No available flights, exit.
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();
                            Console.WriteLine(flightManager.ViewFlights());     // Call our method ViewFlights to list all the flights we have.                           
                            break;                                              // End of the View Flights logic.
                        case 3:                                                        // Start of logic to View a Particular FLight
                            if (flightManager.numFlights == 0)                         // Check if we have existing flights.
                            {                                                          // If we don't have flights inform the user.
                                Console.WriteLine("\n\nFlight list is empty.");        // Direct the user to exit.
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();
                            Console.WriteLine("Enter Flight ID: ");                               // Ask the user for the FlightID
                            int flightID;                                                         // Using the FlightID
                            if (!int.TryParse(Console.ReadLine(), out flightID))                // User must input a valid integer for the flight ID.
                            {
                                Console.WriteLine("Invalid input. Please enter a valid Flight ID.");    // If the input is not a valid integer,
                                Console.WriteLine("Press any key to continue.");                        // Allow them to continue by pressing any key.
                                Console.ReadKey();
                                continue;                                                               // Restart the loop if the input is invalid
                            }
                            Console.WriteLine(flightManager.ViewParticularFlight(flightID));      // We're going to let the user to see the flight.
                            break;                                                                // End of logic to View a Particular Flight
                        case 4:                                                                             // Start of logic to delete a flight.
                            if (flightManager.numFlights == 0)                       // Check if we have exiting flights.
                            {                                                        // If we don't have existing flights,
                                Console.WriteLine("\n\nFlight list is empty.");      // Inform the user.
                                Console.WriteLine("Press any key to continue.");     // Direct them to exit.
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine(flightManager.ViewFlights());                             // Let the user see the lists of the flights while deciding what to delete.
                                Console.WriteLine("\n\n****************");
                                Console.WriteLine("Enter Flight ID to delete: ");                           // User must provide the Flight ID of the one they wants to delete.
                                int flightIDToDelete;

                                if (!int.TryParse(Console.ReadLine(), out flightIDToDelete))                // User must input a valid integer for the flight ID.
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid Flight ID.");    // If the input is not a valid integer,
                                    Console.WriteLine("Press any key to continue.");                        // Allow them to continue by pressing any key.
                                    Console.ReadKey();
                                    continue;                                                               // Restart the loop if the input is invalid
                                }

                                if (flightManager.DeleteFlight(flightIDToDelete))                           // Check if the flight with the specified ID was deleted.
                                {
                                    break;                                                                  // Exit the loop if the flight is successfully deleted
                                }

                                else
                                {
                                    Console.WriteLine("Do you wish to continue? (Y/N)");                  // Ask the user whether they want to continue.
                                    ConsoleKeyInfo key = Console.ReadKey();
                                    Console.WriteLine();

                                    switch (key.KeyChar)
                                    {
                                        case 'Y':
                                        case 'y':
                                            break;                                                        // Continue the loop to get the proper flightID.
                                        case 'N':
                                        case 'n':
                                            RunFlightMenu();                                              // If the user doesn't want to continue, Return to the Flight Menu.
                                            return;
                                        default:
                                            Console.WriteLine("Invalid input. Please enter Y/y or N/n."); // Message will prompt if the user chose neither of Y/N
                                            Console.WriteLine("Press any key to continue.");
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                            }
                            break;
                        case 5:
                            Console.Clear();                                            // Exit the flight menu and return to the main menu
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");     // Inform the user that they're choosing an invalid option.
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a number.");         // If the user put invalid choice, inform them.
                }
                Console.WriteLine("Press any key to continue.....");                      // Allow them to continue if they choose any key.
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void RunBookingMenu()                                                              // BOOKING MENU
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("* == FLIGH HIGH AIRLINES == *\n\n");
                Console.WriteLine("~ BOOKING MENU ~\n");
                Console.WriteLine("1. Make Booking");                                              // Allows the user to create a booking.
                Console.WriteLine("2. View Bookings");                                             // Allows the user to view all the bookings.
                Console.WriteLine("3. Back to Main Menu\n");                                       // Allows the user to go back to the Main Menu.

                Console.WriteLine("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:                                                                        // Start of logic to Make a Booking.
                            Console.Clear();
                            if (flightManager.numFlights == 0 && customersManager.numCustomer == 0)
                            {
                                Console.WriteLine("Error: Unable to book!");
                                Console.WriteLine("No available Flights.");
                                Console.WriteLine("No available Customers.");
                                Console.WriteLine("\n\nPress any key to continue...");
                                Console.ReadKey();
                                continue;
                            }
                            if (bookingManager.MakeBooking(flightManager, customersManager))           // When we add Booking,
                            {                                                                          // There's a list of all Customers and Flights.          
                                Console.WriteLine("\nBooking successfully made!");
                            }
                            else
                            {
                                Console.WriteLine("\nBooking failed. Press any key to continue.");     // If something goes wrong, inform the user that the booking is failed.
                            }
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break;                                                                     // End of the logic for Making a Booking.
                        case 2:                                                                        // Start of logic to View Bookings.
                            Console.Clear();
                            if (bookingManager.numBookings == 0)                  // Check if we have existing bookings.
                            {                                                     // If we don't have existing booking 
                                Console.WriteLine("Booking list is empty.");  // Inform the user.
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            Console.Clear();
                            Console.WriteLine(bookingManager.ViewBookings());
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;                                                                    // End of the logic to View Bookings.
                        case 3:
                            Console.Clear();
                            return;                                                                   // Exit the booking menu and return to the main menu
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a number.");      // If the user put invalid choice, inform them.
                    Console.WriteLine("Press any key to continue.....");                   // Allow them to continue if they choose any key.
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                AirlineCoordinator airlineCoordinator = new AirlineCoordinator();
                airlineCoordinator.Run();
            }
        }
    }
}