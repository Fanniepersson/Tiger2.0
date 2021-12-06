using System;
using System.Collections.Generic;
namespace Project_Tiger_2._0
{
    public class MainMenuCustomer
    {
        public void MainMenuC(List<Users> listOfUsers, int loggedInUserIndex)
        {
            bool logOut = false;
            while (logOut == false)
            {
                Console.Clear();
                Console.WriteLine("Välj ett av valen nedan i menyn:");
                Console.WriteLine("1 --- Se dina konton & saldo.");
                Console.WriteLine("2 --- Överföring av pengar mellan dina konton. (inte implementerad ännu)");
                Console.WriteLine("3 --- Överför dina pengar till en annan användare. (inte implementerad ännu)");
                Console.WriteLine("4 --- Öppna upp ett nytt konto. (inte implementerad ännu)");
                Console.WriteLine("5 --- Logga ut.");

                string choice = Console.ReadLine();
                switch (choice)
                {

                    case "1":

                        Console.WriteLine("Dina konton och saldo");
                        Console.WriteLine();

                        for (int i = 0; i < listOfUsers[loggedInUserIndex].listOfBankAccounts.Count; i++)
                        {
                            Console.Write(listOfUsers[loggedInUserIndex].listOfBankAccounts[i].AccountName);
                            Console.Write(" --- ");
                            Console.Write(listOfUsers[loggedInUserIndex].listOfBankAccounts[i].AccountBalance);
                            Console.WriteLine();
                            Console.WriteLine();
                        }

                        Console.WriteLine("Tryck på enter för att återgå till menyn.");
                        Console.ReadKey();

                        break;


                    case "2":

                        Console.WriteLine("Föra över pengar mellan dina konton");





                        break;

                    case "3":

                        break;

                    case "4":

                        break;

                    case "5":
                        logOut = true;
                        break;


                    default:

                        break;
                }












            }
















        }
    }
}
