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
                Console.Clear();
                Console.WriteLine("Välj ett alternativ utav följande:");
                Console.WriteLine("1 --- Skapa en ny admin.");
                Console.WriteLine("5 --- Logga ut.");

                string AdminPick = Console.ReadLine();
                switch (AdminPick)
                {
                    case "1":                        
                        listOfUsers[loggedInUserIndex].CreateNewAdmin(listOfUsers);                        
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








