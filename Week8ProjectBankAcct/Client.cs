using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProjectBankAcct
{
    class Client
    {
        private string firstName;
        private string lastName;
        private Random acctNumber;

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
        public int AcctNumber
        {
            get { return acctNumber; }
            set { acctNumber = value; }
        }

        public Client()
        {
            firstName = null;
            lastName = null;
            acctNumber = null;
        }
        public Client(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.acctNumber = new Random();

            Console.WriteLine($"Opened an account for {this.firstName} {this.lastName} with account number {this.acctNumber}.");
        }
    }
}
