using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProjectBankAcct
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> menuItems = new List<string>
            { "View Client Information","View Account Balance","Deposit Funds","Withdraw Funds","Exit" };

     
       
            DisplayMenu(menuItems);
            string menuChoice = Console.ReadLine();
            
            switch(menuChoice)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            } 
            Console.Read();

        }
        static void DisplayMenu(List<string> menuItems)
        {

            Console.WriteLine("Personal Banking Program \n-------------------------\nMENU:");
            int counter = 0;
            foreach (string item in menuItems)
            {
                counter++;
                Console.WriteLine($"{counter}. {item}");
            }
        }
    }
}
