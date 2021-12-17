using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class LoggingIntoBankSystem
    {
        public void LoginMenu()
        {

            List<Admin> listOfAdmins = new List<Admin>();
            List<Customer> listOfCustomers = new List<Customer>();
            listOfAdmins.Add(new Admin
            {
                UserName = "Tobias Landèn",
                PinCode = 1,
                AdminPrivileges = true
            });

            listOfAdmins.Add(new Admin
            {
                UserName = "Anas Alhussain",
                PinCode = 2,
                AdminPrivileges = true
            });

            listOfCustomers.Add(new Customer
            {
                UserName = "Shere Khan",
                PinCode = 3,
            });
            listOfCustomers[0].listOfBankAccounts.Add(new BankAccounts("Sparkonto", 4000,"SEK"));
            listOfCustomers[0].listOfBankAccounts.Add(new BankAccounts("Lönekonto", 5000,"SEK"));

            bool login = true;
            while (login)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
                string answerUserName = " ";
                bool loop = true;
                int loggedInUserIndexAdmin = 0;
                int loggedInUserIndexCustomer = 0;


                Console.WriteLine(@"

                         __,,,,_
          _ __..-;''`--/'/ /.',-`-.
      (`/' ` |  \ \ \\ / / / / .-'/`,_
     /'`\ \   |  \ | \| // // / -.,/_,'-,
    /<7' ;  \ \  | ; ||/ /| | \/    |`-/,/-.,_,/')
   /  _.-, `,-\,__|  _-| / \ \/|_/  |    '-/.;.\'
   `-`  f/ ;      / __/ \__ `/ |__/ |
        `-'      |  -| =|\_  \  |-' |
              __/   /_..-' `  ),'  //
             ((__.-'((___..-'' \__.'

                                        ");

                while (loop == true)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    Console.WriteLine("Välkommen till banken! Mata in ditt användarnamn.");
                    answerUserName = Console.ReadLine();

                    foreach (Admin admin in listOfAdmins)
                    {
                        if (answerUserName == admin.UserName)
                        {
                            loggedInUserIndexAdmin = listOfAdmins.IndexOf(admin);
                            loop = false;
                        }
                    }
                    foreach (Customer customer in listOfCustomers)
                    {
                        if (answerUserName == customer.UserName)
                        {
                            loggedInUserIndexCustomer = listOfCustomers.IndexOf(customer);
                            loop = false;
                        }
                    }
                    if (loop == true)
                    {
                        Console.WriteLine("Det användarnamnet finns inte i systemet! Försök igen.");
                    }
                }

                bool successfullyLoggedIn = false;
                int loginTries = 0;
                bool answerdRight = false;
                while (loginTries < 3)
                {
                    Console.WriteLine("Var vänlig och ange din pinkod.");
                    int answerPinCode = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < 3; i++)
                    {
                        if (answerPinCode == listOfAdmins[loggedInUserIndexAdmin].PinCode && answerUserName == listOfAdmins[loggedInUserIndexAdmin].UserName)
                        {
                            successfullyLoggedIn = true;
                            answerdRight = true;
                            break;
                        }
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (answerPinCode == listOfCustomers[loggedInUserIndexCustomer].PinCode && answerUserName == listOfCustomers[loggedInUserIndexCustomer].UserName)
                        {
                            successfullyLoggedIn = true;
                            answerdRight = true;
                            break;
                        }
                    }

                    loginTries++;
                    if (answerdRight == true)
                    {
                        break;
                    }
                    else if (loginTries == 3)
                    {
                        Console.WriteLine("Du matade in fel pinkod 3 gånger, du kommer nu att bli avstängd från systemet!");
                        login = false;
                    }
                    else if (answerdRight != true)
                    {
                        Console.WriteLine($"Du har {3 - loginTries} försök till på dig att mata in rätt pinkod.");
                    }
                }

                if (successfullyLoggedIn == true)
                {
                    if (listOfAdmins[loggedInUserIndexAdmin].UserName == answerUserName)
                    {
                        // Admin meny anrop här.
                        Admin adminMenu = new Admin();
                        adminMenu.MainMenuA(listOfAdmins, loggedInUserIndexAdmin, listOfCustomers);
                    }
                    else if (listOfCustomers[loggedInUserIndexCustomer].UserName == answerUserName)
                    {
                        // Customer meny anrop här.
                        Customer customerMenu = new Customer();
                        customerMenu.MainMenuC(listOfCustomers, loggedInUserIndexCustomer);
                    }
                }
            }
            
        }
    }
}
