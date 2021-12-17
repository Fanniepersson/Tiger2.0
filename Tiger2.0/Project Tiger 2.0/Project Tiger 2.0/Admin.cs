using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class Admin : Users
    {
        public bool AdminPrivileges { get; set; }
        public const string Tiger = "🐯";
        public const string Back = "🔙";
        public void MainMenuA(List<Admin> listOfAdmins, int loggedInUserIndex, List<Customer> listOfCustomers)
        {
            bool LogOut = false;
            while (LogOut == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
                Console.WriteLine($"Hej och välkommen {listOfAdmins[loggedInUserIndex].UserName}. Du är adminstratör hos Tiger International " + Admin.Tiger);
                Console.WriteLine();
                Console.WriteLine("Välj ett alternativ utav följande:");
                Console.WriteLine("1 --- Skapa en ny admin.");
                Console.WriteLine("2 --- Skapa en ny kund.");
                Console.WriteLine("3 --- Se lista på anställda.");
                Console.WriteLine("4 --- Logga ut.");

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
                        Console.WriteLine();
                        Console.WriteLine(Customer.Tiger);
                        Console.WriteLine();
                        Console.WriteLine("Vi som jobbar på Tiger International: \nChief Executive Officer: Fannie \nOperations Director: Daniel \nEconomy Manager: Mattias \nStrategist Of Finance: Filip ");
                        Console.WriteLine("");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
                        Console.WriteLine();
                        Console.WriteLine(Customer.Back);

                        Console.ReadKey();
                        break;


                    case "4":
                        LogOut = true;
                        break;


                    default:
                        Console.WriteLine("Felaktig inmatning. Tryck på enter för att återgå till menyn.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void CreateNewAdmin(List<Admin> listOfAdmins, List<Customer> listOfCustomers) // Skapa nya admins
        {
            Console.Clear();
            string nameForNewAdmin = " ";
            bool loop = true;
            while (loop == true)
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
                    loop = false;
                }
            }

            int pinCodeForNewAdmin = 0;
            bool pinCodeConsistsOfSixNumbers = false;
            while (pinCodeConsistsOfSixNumbers == false)
            {
                Console.WriteLine("Välj nu en pinkod för den nya administratören.");

                try
                {
                    pinCodeForNewAdmin = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                   
                }

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

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
            Console.WriteLine();
            Console.WriteLine(Customer.Back);

            Console.ReadKey();
        }

        public void CreateNewCustomer(List<Admin> listOfAdmins, List<Customer> listOfCustomers) // Skapa nya kunder
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
                    listOfCustomers[indexOfLatestCustomer].listOfBankAccounts.Add(new BankAccounts("Konto 1", 0, "SEK"));
                    pinCodeConsistsOfSixNumbers = true;
                }
                else
                {
                    Console.WriteLine("Din pinkod måste innehålla 6 stycken siffror!");
                }
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
            Console.WriteLine();
            Console.WriteLine(Customer.Back);

            Console.ReadKey();
        }

    }
}