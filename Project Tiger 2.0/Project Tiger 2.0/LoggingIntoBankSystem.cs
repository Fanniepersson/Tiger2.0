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
                UserName = "System Admin 1",
                PinCode = 1337,
                AdminPrivileges = true
            });
        
            
        }
    }
}
