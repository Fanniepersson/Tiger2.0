using System;
using System.Collections.Generic;
namespace Project_Tiger_2._0
{
    public class MainMenuCustomer
    {


       
        public void MainMenuC(List<Users> listOfUsers, int loggedInUserIndex)
        {
            bool logOut = false;


            listOfUsers[loggedInUserIndex].listOfBankAccounts.Add(new BankAccounts("Sparkonto", 1000));
            listOfUsers[loggedInUserIndex].listOfBankAccounts.Add(new BankAccounts("Lönekonto", 13456));
            listOfUsers[loggedInUserIndex].listOfBankAccounts.Add(new BankAccounts("Sparkonto", 1359385));


            while (logOut == false)
            {
                Console.WriteLine("Välj ett av valen nedan i menyn:");
                Console.WriteLine("1 - Se dina konton & saldo");
                Console.WriteLine("2 - Överföring av pengar mellan dina konton");
                Console.WriteLine("3 - Överför dina pengar till en annan användare");
                Console.WriteLine("4 - Öppna upp ett nytt konto");
                string choice = Console.ReadLine();

                switch (choice)
                {

                    case "1":

                        Console.WriteLine("Dina konton och saldo");
                        Console.WriteLine();

                        for (int i = 0; i < listOfUsers[loggedInUserIndex].listOfBankAccounts.Count; i++)
                        {
                            Console.Write(listOfUsers[loggedInUserIndex].listOfBankAccounts[i].AccountName);
                            Console.Write(" -- ");
                            Console.Write(listOfUsers[loggedInUserIndex].listOfBankAccounts[i].AccountBalance);
                            Console.WriteLine();
                            Console.WriteLine();
                        }


                        break;


                    case "2":

                        Console.WriteLine("Föra över pengar mellan dina konton");





                        break;

                    case "3":

                        break;

                    case "4":

                        break;

                    case "5":

                        break;


                    default:
                        break;
                }












            }
















        }
    }
}
