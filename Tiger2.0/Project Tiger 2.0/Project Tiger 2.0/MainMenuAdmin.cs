using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Tiger_2._0
{
    public class MainMenuAdmin
    {

        public void MainMenuA(List<Users> listOfUsers, int loggedInUserIndex)
        {
            bool LogOut = false;
            while (LogOut == false)
            {


                string AdminPick = Console.ReadLine();
                Console.WriteLine("Välj ett alternativ utav följande : ");
                Console.WriteLine("Skapa en ny administrator\n Skapa ett nytt konto åt kunden.");

                switch (AdminPick)
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
                        LogOut = true;
                        break;
                    default:
                        break;
                }
            }
        }

    }

}








