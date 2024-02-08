using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class SeniorCitizen : Customers
    {
        protected int seniorCitizenAge;

        public SeniorCitizen(int customerID, string firstName, string lastName, string phone, int scAge)
            :base(customerID,firstName, lastName, phone, scAge)
        {
            this.seniorCitizenAge = scAge;
        }

        public override string ToString()
        {
            string s = base.ToString();
            s = s + "\nAge: " + seniorCitizenAge;
            s = s + "\nType: Senior Citizen";
            return s;
        }
    }
}
