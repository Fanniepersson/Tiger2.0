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
                Console.WriteLine("Välj ett alternativ utav följande : ");
                Console.WriteLine("1 --- Skapa en ny admin.");
                Console.WriteLine("5 --- Logga ut.");
                string AdminPick = Console.ReadLine();
                switch (AdminPick)
                {
                    case "1":

                        string nameForNewAdmin = " ";
                        bool userNameAlreadyExists = true;
                        while (userNameAlreadyExists == true)
                        {
                            Console.WriteLine("Vad ska den nya administratören ha för användarnamn?");
                            nameForNewAdmin = Console.ReadLine();

                            bool nameAlreadyTaken = false;

                            foreach (Users user in listOfUsers)
                            {
                                if (user.UserName == nameForNewAdmin)
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
                                listOfUsers.Add(new Users // Denna algoritm används för att skapa en ny administratör.
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








