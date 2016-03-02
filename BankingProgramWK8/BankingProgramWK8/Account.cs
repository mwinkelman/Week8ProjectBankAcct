using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgramWK8
{
    class Account
    {
        //FIELDS
        public Client client;
        private int accountNumber;
        private decimal accountBalance;
        private string filepath;

        //PROPERTIES
        public Client Client
        {
            get { return client; }
            set { this.client = value; }
        }
        public int AccountNumber
        {
            get { return accountNumber; }            
        }
        public decimal AccountBalance
        {
            get { return accountBalance; }
        }
        public string Filepath
        {
            get { return this.filepath; }
            set { this.filepath = value; }
        }

        //CONSTRUCTORS
        public Account() { }
        public Account(Client client)
        {
            this.client = client;
            Random random = new Random();
            accountNumber = random.Next();
            accountBalance = 0;
            filepath = @"AccountSummary.txt";
        }

        //METHODS
        public bool Withdraw(decimal withdrawalAmount)
        {
            if (accountBalance - withdrawalAmount >= 0 && withdrawalAmount > 0)
            {
                accountBalance = accountBalance - withdrawalAmount;
                return true;
            }

            else
            {
                return false;
            }
        }
        public bool Deposit(decimal depositAmount)
        {
            if (depositAmount > 0)
            {
                accountBalance = accountBalance + depositAmount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
