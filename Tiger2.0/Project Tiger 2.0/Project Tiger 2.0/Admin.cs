using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class Admin : Users
    {
        public bool AdminPrivileges { get; set; } // Behövs inte. Dålig.
        public void MainMenuA(List<Admin> listOfAdmins, int loggedInUserIndex, List<Customer> listOfCustomers)
        {
            bool LogOut = false;
            while (LogOut == false)
            {
                Console.Clear();
                Console.WriteLine("Välj ett alternativ utav följande:");
                Console.WriteLine("1 --- Skapa en ny admin.");
                Console.WriteLine("2 --- Skapa en ny kund.");
                Console.WriteLine("5 --- Logga ut.");

                string AdminPick = Console.ReadLine();
                switch (AdminPick)
                {
                    case "1":
                        listOfAdmins[loggedInUserIndex].CreateNewAdmin(listOfAdmins, listOfCustomers);
                        break;

                    case "2":
                        listOfAdmins[loggedInUserIndex].CreateNewCustomer(listOfAdmins, listOfCustomers);
                        break;

                    case "3":

                        break;

                    case "4":

                        break;

                    case "5":
                        LogOut = true;
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning. Tryck på enter för att återgå till menyn.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void CreateNewAdmin(List<Admin> listOfAdmins, List<Customer> listOfCustomers) // Denna metoden rör admins.
        {
            Console.Clear();
            string nameForNewAdmin = " ";
            bool userNameAlreadyExists = true;
            while (userNameAlreadyExists == true)
            {
                Console.WriteLine("Vad ska den nya administratören ha för användarnamn?");
                nameForNewAdmin = Console.ReadLine();

                bool nameAlreadyTaken = false;

                foreach (Admin admins in listOfAdmins)
                {
                    if (admins.UserName == nameForNewAdmin)
                    {
                        Console.WriteLine("Det namnet finns redan i systemet, välj ett annat!");
                        nameAlreadyTaken = true;
                    }
                }
                foreach (Customer customers in listOfCustomers)
                {
                    if (customers.UserName == nameForNewAdmin)
                    {
                        Console.WriteLine("Det namnet finns redan i systemet, välj ett annat!");
                        nameAlreadyTaken = true;
                    }
                }
                if (nameAlreadyTaken == false)
                {
                    userNameAlreadyExists = false;
                }
            }

            bool pinCodeConsistsOfSixNumbers = false;
            while (pinCodeConsistsOfSixNumbers == false)
            {
                Console.WriteLine("Välj nu en pinkod för den nya administratören.");
                int pinCodeForNewAdmin = Convert.ToInt32(Console.ReadLine());
                string stringPinCodeForNewAdmin = Convert.ToString(pinCodeForNewAdmin);

                if (stringPinCodeForNewAdmin.Length == "123456".Length)
                {
                    listOfAdmins.Add(new Admin // Denna algoritm används för att skapa en ny administratör.
                    {
                        UserName = nameForNewAdmin,
                        PinCode = pinCodeForNewAdmin,
                        AdminPrivileges = true
                    });
                    pinCodeConsistsOfSixNumbers = true;
                }
                else
                {
                    Console.WriteLine("Din pinkod måste innehålla 6 stycken siffror!");
                }
            }

            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();
        }




        public void CreateNewCustomer(List<Admin> listOfAdmins, List<Customer> listOfCustomers)
        {
            Console.Clear();
            string nameForNewCustomer = " ";
            bool userNameAlreadyExists = true;
            while (userNameAlreadyExists == true)
            {
                Console.WriteLine("Vad ska den nya kunden ha för användarnamn?");
                nameForNewCustomer = Console.ReadLine();

                bool nameAlreadyTaken = false;

                foreach (Admin admins in listOfAdmins)
                {
                    if (admins.UserName == nameForNewCustomer)
                    {
                        Console.WriteLine("Det namnet finns redan i systemet, välj ett annat!");
                        nameAlreadyTaken = true;
                    }
                }
                foreach (Customer customers in listOfCustomers)
                {
                    if (customers.UserName == nameForNewCustomer)
                    {
                        Console.WriteLine("Det namnet finns redan i systemet, välj ett annat!");
                        nameAlreadyTaken = true;
                    }
                }
                if (nameAlreadyTaken == false)
                {
                    userNameAlreadyExists = false;
                }
            }

            bool pinCodeConsistsOfSixNumbers = false;
            while (pinCodeConsistsOfSixNumbers == false)
            {
                Console.WriteLine("Välj nu en pinkod för den nya kunden.");
                int pinCodeForNewCustomer = Convert.ToInt32(Console.ReadLine());
                string stringPinCodeForNewCustomer = Convert.ToString(pinCodeForNewCustomer);

                if (stringPinCodeForNewCustomer.Length == "123456".Length)
                {
                    listOfCustomers.Add(new Customer // Denna algoritm används för att skapa en ny kund.
                    {
                        UserName = nameForNewCustomer,
                        PinCode = pinCodeForNewCustomer
                    });
                    int indexOfLatestCustomer = listOfCustomers.Count - 1;
                    listOfCustomers[indexOfLatestCustomer].listOfBankAccounts.Add(new BankAccounts("Konto 1", 0));
                    pinCodeConsistsOfSixNumbers = true;
                }
                else
                {
                    Console.WriteLine("Din pinkod måste innehålla 6 stycken siffror!");
                }
            }

            Console.WriteLine("Tryck på enter för att återgå till menyn.");
            Console.ReadKey();
        }

    }
}