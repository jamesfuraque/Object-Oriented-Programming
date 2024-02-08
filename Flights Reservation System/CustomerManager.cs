using Project_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class CustomerManager
    {
        public int numCustomer;
        protected int maxCustomer;
        public Customers[] customerList;
        private int numBookings;
        private Booking[] bookingList;

        public CustomerManager(int max)
        {
            this.numCustomer = 0;
            this.maxCustomer = max;
            customerList = new Customers[max];
            this.numBookings = 0;
            bookingList = new Booking[max];
        }

        public bool CustomerExists(string firstName, string lastName, string phone) // Method to identify if we already have an existing customer.
        {
            for (int i = 0; i < numCustomer; i++)                                   // Check if a customer with the same first name, last name, and phone already exists
            {
                if (customerList[i].customerFirstName == firstName &&               // Check the First Name,
                    customerList[i].customerLastName == lastName &&                 // Check the Last Name,
                    customerList[i].customerPhone == phone)                         // Check the phone.
                {
                    return true;                                                    // Return true if we have existing customer.
                }
            }
            return false;                                                           // Return false if we don't have that existing customer.
        }

        public bool AddCustomer(string firstName, string lastName, string phone, int customerAge)        // Start of method to ADD CUSTOMER.
        {
            if (CustomerExists(firstName, lastName, phone))                                              // Check if customer already exists with the same first name, last name, and phone.
            {
                Console.WriteLine("\nCustomer already exists. Cannot duplicate records!");               // Inform the customer that we can't duplicate records.
                return false;                                                                            // Return false if we already have existing records for that customer.
            }

            if (numCustomer >= maxCustomer)                                                              // Check if the number of customers we have 
            {                                                                                            // is less than the max capacity.
                Console.WriteLine("Customer list is full! Cannot add more customers.");                  // Inform the user that our customer list is full. 
                return false;                                                                            // Return false if we are failed to add customer.
            }

            Customers newCustomer;                                                                              // Declare a varibale for a new customer which belongs to Customers.
            int customerID = GenerateCustomerID();                                                              // Generate a unique ID for the customer.
            if (customerAge >= 60)                                                                                  // Check if the age is greater than or equal to 60.
            {
                newCustomer = new SeniorCitizen(customerID, firstName, lastName, phone, customerAge);               // Add the customer as Senior Citizen.
            }
            else if (customerAge >= 18)                                                                             // Check if the age is greater than or equal to 18.
            {
                newCustomer = new Adult(customerID, firstName, lastName, phone, customerAge);                       // Add the customer as Adult.
            }
            else if (customerAge >= 5)                                                                              // Check if the age is greater than or equal to 5.
            {
                newCustomer = new Child(customerID, firstName, lastName, phone, customerAge);                       // Add the customer as a Child.
            }
            else                                                                                                    // If neither of the given specifications above,
            {
                newCustomer = new Infant(customerID, firstName, lastName, phone, customerAge);                      // Add the customer as an Infant.
            }
            customerList[numCustomer] = newCustomer;                                                     // Add the new customer to the array                   
            numCustomer++;                                                                               // Increment the customer count
            return true;                                                                                 // Customer addition succeeded
        }                                                                                                // End of method to ADD CUSTOMER.



        public int GenerateCustomerID()    // Method to allow us generate unique ID for customers.
        {
            return 1000 + numCustomer + 1; // Preferably customer IDs starts with 1000
        }

        private bool CustomerHasBookings(string firstName, string lastName, string phone)  // Method for us to know if the customer has bookings.
        {
            for (int i = 0; i < numBookings; i++)                                          // Iterate through bookings to check if the customer has any
            {
                if (bookingList[i].BookedCustomer.customerFirstName == firstName &&        // Check the First Name 
                    bookingList[i].BookedCustomer.customerLastName == lastName &&          // Check the Last Name
                    bookingList[i].BookedCustomer.customerPhone == phone)                  // Check the Phone Number
                {
                    return true;                                                           // Return true if the customer has bookings.
                }
            }
            return false;                                                                  // Return false if the customer doesn't have any bookings.
        }

        public bool DeleteCustomer(string firstName, string lastName, string phone)      // Start of method for us to delete a customer.
        {
            bool customerExists = CustomerExists(firstName, lastName, phone);            // Check if a customer with the specified details exists.

            if (customerExists)                                                          // If customer is exists, proceed to deletion process.
            {
                if (CustomerHasBookings(firstName, lastName, phone))
                {
                    Console.WriteLine($"\n\nExisting record for this customer has found: {GetCustomerInfo(firstName, lastName, phone)}\n"); // Customer found, prompt for confirmation.
                    Console.Write("Are you sure you want to delete this record? (Y/N): ");                                                  // Ask the user if they're sure to delete the record.
                    char confirmation = Console.ReadKey().KeyChar;

                    if (confirmation == 'Y' || confirmation == 'y')                          // Whether they choose Y or y, continue the process.
                    {
                        int index = -1;                                                      // Find the index of the customer and shift remaining elements.
                        for (int i = 0; i < numCustomer; i++)
                        {
                            if (customerList[i].customerFirstName == firstName &&            // Look for the First Name.
                                customerList[i].customerLastName == lastName &&              // Look for the Last Name.
                                customerList[i].customerPhone == phone)                      // Look for the Phone Number.
                            {
                                index = i;                                                   // Customer found, set the index.
                                break;
                            }
                        }

                        if (index != -1)                                   // Check if the value of the variable is not equal to -1
                        {
                            for (int i = index; i < numCustomer - 1; i++)
                            {
                                customerList[i] = customerList[i + 1];
                            }
                            numCustomer--;                                 // Decrease the customer count in our table.
                            return true;                                   // Customer deletion succeeded.
                        }
                        else
                        {
                            Console.WriteLine("Error: customer doesn't exists.");       // Inform the user if the customer doesn't exists.
                            return false;                                               // Return false becuase of customer deletion failed.
                        }
                    }

                    else if (confirmation == 'N' || confirmation == 'n')               // If they choose N/n, don't let them continue the removal of the customer.
                    {
                        Console.WriteLine("\nCustomer Deletion CANCELLED!");           // User removal was cancelled.
                        return false;                                                  // Customer deletion canceled.
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Returning to Customer's Menu.");  // However, inform them that they're choosing invalid input if they're not pressing either Y/N
                        return false;                                                         // Return false and because of that, we will terminate the removal of the customer.
                    }
                }
                else
                {                                                                                                                                         // We cannot delete a customer if they have booking.  
                    Console.WriteLine("\nError: Customer has bookings. Process canceled!\nYou can only delete a customer if they don't have booking.");   // Inform the user that the customer has booking.
                    return false;
                }
            }
            else                                                                   // IF CUSTOMER DOESN'T EXISTS.
            {
                Console.WriteLine("\nCustomer not found. Deletion canceled.");     // Inform the user and we will terminate the removal.
                return false;                                                      // Customer not found, deletion canceled, we return False.
            }
        }                                                                          // End of method to DELETE A CUSTOMER.

        private string GetCustomerInfo(string firstName, string lastName, string phone)        // Start of method to allow us to identify if there's a record for our customer.
        {                                                                                      // We made this method to also use it to delete customer method.
            for (int i = 0; i < numCustomer; i++)
            {
                if (customerList[i].customerFirstName == firstName &&                          // Check the First Name.
                    customerList[i].customerLastName == lastName &&                            // Check the Last Name.
                    customerList[i].customerPhone == phone)                                    // Check the Phone Number.
                {
                    return customerList[i].ToString();                                         // Return customer information as a string.
                }
            }
            return "Customer not found";                                                       // If not found, inform the customer.
        }                                                                                      // End of GetCustomerInfo method.

        public Customers GetCustomerById(int customerId)        // Start of our method GetCustomerByID.
        {
            for (int i = 0; i < numCustomer; i++)
            {
                if (customerList[i].customerID == customerId)
                {
                    return customerList[i];                     // Return the customer with the specified ID.
                }
            }
            return null;                                        // Customer with the specified ID not found.
        }                                                       // End of our method GetCustomerByID.

        // Method to view all existing customers in our record.
        public string ViewCustomers()
        {
            if (numCustomer == 0)
            {
                return "No customers available.\n\n";                 // If there's no customers, inform the user.
            }
            string s = " === * LIST OF ALL CUSTOMERS * === ";
            for (int i = 0; i < numCustomer; i++)
            {
                s = s + "\n" + customerList[i].ToString();
                s = s + "\n";
            }
            return s;
        }
    }
}