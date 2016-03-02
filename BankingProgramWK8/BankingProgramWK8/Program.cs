using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankingProgramWK8
{
    [System.Runtime.InteropServices.Guid("5ABA3028-A1E3-472B-BB99-722533F1EF86")]
    class Program
    {

        static void Main(string[] args)
        {
            List<string> menuItems = new List<string>
            {"View Client Information","View Account Balance","Deposit Funds","Withdraw Funds","Exit"};


            Client client = new Client("Marpy","Winkelman");
            Account account = new Account(client);
            client.Account = account;
            account.Client = client;

            CreateClientFile(client, account);

            bool repeat = true;
            while (repeat==true)
            {
                string menuInput = DisplayMenu(menuItems);
                switch (menuInput)
                {
                    case "1":
                        DisplayClientInfo(client);
                        Console.WriteLine("Press ENTER to return to the Main Menu.");
                        Console.Read();
                        break;
                    case "2":
                        DisplayAccountBalance(account);
                        Console.WriteLine("Press ENTER to return to the Main Menu.");
                        Console.Read();
                        break;
                    case "3":
                        DepositFunds(account);
                        Console.WriteLine("Press ENTER to return to the Main Menu.");
                        Console.Read();
                        break;
                    case "4":
                        WithdrawFunds(account);
                        Console.WriteLine("Press ENTER to return to the Main Menu.");
                        Console.Read();
                        break;
                    case "5":
                        repeat = false;
                        Console.WriteLine("Goodbye");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
            Console.Read();
        }
        static string DisplayMenu(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("PERSONAL BANKING SYSTEM\n");
            int counter = 0;
            Console.WriteLine("MENU:\n-----------------");
            foreach (string item in menuItems)
            {
                counter++;
                Console.WriteLine($"{counter}. {item}");
            }
            Console.WriteLine("Enter the number of a menu item:");
            string input = Console.ReadLine();
            return input;
        }
        static void CreateClientFile(Client client, Account account)
        {
            string fileName = account.Filepath;
            StreamWriter sw = new StreamWriter(fileName);
            using (sw)
            {
                sw.WriteLine($"Client Name: {client.FirstName} {client.LastName}");
                sw.WriteLine($"Account Number: {account.AccountNumber}");
                sw.WriteLine("---------------------------------------");
                sw.WriteLine("TRANSACTION HISTORY");
                sw.WriteLine("---------------------------------------");
            }            
            StreamReader sr = new StreamReader(fileName);
            using (sr)
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        static void DisplayClientInfo(Client client)
        {
            Console.WriteLine($"Client Name: {client.FirstName} {client.LastName}");
            Console.WriteLine($"Account Number: {client.Account.AccountNumber.ToString()}");
        }
        static void DisplayAccountBalance(Account account)
        {
            Console.WriteLine($"Current Balance: ${account.AccountBalance}");
        }
        static void DepositFunds(Account account)
        {
            Console.WriteLine("Enter amount:");
            string input = Console.ReadLine();
            decimal amount;
            bool test = decimal.TryParse(input, out amount);
            if (!test)
                return;

            bool allow = account.Deposit(amount);
            if (allow == true)
            {
                StreamWriter sw = new StreamWriter(account.Filepath, true);
                DateTime dateTime = DateTime.Now;
                using (sw)
                {
                    sw.WriteLine($"{dateTime}:  + ${amount},  Current Balance: ${account.AccountBalance}");
                }
                Console.Clear();
                StreamReader sr = new StreamReader(account.Filepath);
                using (sr)
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            else { Console.WriteLine("Error: nonvalid amount"); }
        }
        static void WithdrawFunds(Account account)
        {
            Console.WriteLine("Enter amount:");
            string input = Console.ReadLine();
            decimal amount;
            bool test = decimal.TryParse(input, out amount);
            if (!test)
                return;

            bool allow = account.Withdraw(amount);

            if (allow == true)
            {
                StreamWriter sw = new StreamWriter(account.Filepath, true);
                DateTime dateTime = DateTime.Now;
                using (sw)
                {
                    sw.WriteLine($"{dateTime}:  - ${amount},  Current Balance: ${account.AccountBalance}");
                }
                Console.Clear();
                StreamReader sr = new StreamReader(account.Filepath);
                using (sr)
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            else { Console.WriteLine("Error: Insufficient funds or nonvalid amount"); }
        }
    }
}
