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
                        bool userNameAlreadyExists = true;
                        while (userNameAlreadyExists == true)
                        {
                            Console.WriteLine("Vad ska den nya adminastratorn ha för användarnamn?");
                            string nameForNewAdmin = Console.ReadLine();
                            foreach (Users users in listOfUsers) // Funkar inte.
                            {
                                if (users.UserName == nameForNewAdmin)
                                {
                                    Console.WriteLine("Det användarnamnet finns redan i systemet. välj ett annat!");
                                }
                                else
                                {
                                    bool pinCodeMustConsistOfSixNumbers = false;
                                    while (pinCodeMustConsistOfSixNumbers == false)
                                    {
                                        Console.WriteLine("Välj nu en pinkod för den nya adminastratorn.");
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
                                            pinCodeMustConsistOfSixNumbers = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Din pinkod måste innehålla 6 stycken siffror!");
                                        }
                                    }




                                    userNameAlreadyExists = false;
                                }
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








