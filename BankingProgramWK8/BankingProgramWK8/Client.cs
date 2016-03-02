using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgramWK8
{
    class Client
    {
        //FIELDS
        private string firstName;
        private string lastName;
        private Account account;

        //PROPERTIES
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public Account Account
        {
            get { return this.account; }
            set { this.account = value; }
        }
        
        //CONSTRUCTORS
        public Client()
        {
            firstName = null;
            lastName = null;
            account = null;
        }
        public Client(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            account = null;
        }

        //METHODS
        static string FullName(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;
            return fullName;
        }
    }
}
