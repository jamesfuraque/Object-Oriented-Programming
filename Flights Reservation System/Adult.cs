using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class Adult : Customers
    {
        protected int adultAge;

        public Adult(int customerID, string firstName, string lastName, string phone, int adAge)
            : base(customerID, firstName, lastName, phone, adAge)
        {
            this.adultAge = adAge;
        }

        public override string ToString()
        {
            string s = base.ToString();
            s = s + "\nAge: " + adultAge;
            s = s + "\nType: Adult";
            return s;
        }
    }
}