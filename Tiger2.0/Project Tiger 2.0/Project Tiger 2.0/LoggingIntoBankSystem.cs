using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class LoggingIntoBankSystem
    {
        public void LoginMenu()
        {
            List<Users> listOfUsers = new List<Users>();
            listOfUsers.Add(new Users
            {
                UserName = "test1",
                PinCode = 1,
                AdminPrivileges = true
            });

            listOfUsers.Add(new Users
            {
                UserName = "test2",
                PinCode = 2,
                AdminPrivileges = false
            });
            listOfUsers[1].listOfBankAccounts.Add(new BankAccounts("Sparkonto", 1000));
            listOfUsers[1].listOfBankAccounts.Add(new BankAccounts("Lönekonto", 13456));
            listOfUsers[1].listOfBankAccounts.Add(new BankAccounts("Sparkonto", 1359385));

            listOfUsers.Add(new Users
            {
                UserName = "test3",
                PinCode = 3,
                AdminPrivileges = false
            });
            listOfUsers[2].listOfBankAccounts.Add(new BankAccounts("Sparkonto", 181518));
            listOfUsers[2].listOfBankAccounts.Add(new BankAccounts("Lönekonto", 472494));

            bool login = true;
            while (login)
            {
                Console.Clear();
                string answerUserName = " ";
                bool answerUserNameWrong = true;
                int loggedInUserIndex = 0;
                while (answerUserNameWrong == true)
                {
                    Console.WriteLine("Välkommen till banken! Mata in ditt användarnamn.");
                    answerUserName = Console.ReadLine();

                    foreach (Users user in listOfUsers)
                    {
                        if (answerUserName == user.UserName)
                        {
                            loggedInUserIndex = listOfUsers.IndexOf(user);
                            //Console.WriteLine(loggedInUserIndex);
                            answerUserNameWrong = false;
                        }
                    }
                    if (answerUserNameWrong == true)
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
                        if (answerPinCode == listOfUsers[loggedInUserIndex].PinCode && answerUserName == listOfUsers[loggedInUserIndex].UserName)
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
                    if (listOfUsers[loggedInUserIndex].AdminPrivileges == true)
                    {
                        /*Console.WriteLine("Du är en admin!");*/ // Admin meny anrop här.
                        MainMenuAdmin adminMenu = new MainMenuAdmin();
                        adminMenu.MainMenuA(listOfUsers, loggedInUserIndex);
                    }
                    else
                    {
                        /*Console.WriteLine("Du är en vanlig kund!");*/ // Kund meny anrop här.
                        MainMenuCustomer customerMenu = new MainMenuCustomer();
                        customerMenu.MainMenuC(listOfUsers, loggedInUserIndex);
                    }
                }




                // Ge användaren möjligheten att stänga av systemet i slutet av denna loopen.
                //login = false;
            }
        }
    }
}
