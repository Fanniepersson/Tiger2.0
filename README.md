# Tiger International
-------------
Introduction|
-------------
This programe we have created is a internet bank in wich people can create new accounts and transfer money to each other, they can see their own bankaccounts and open new ones. They can also view their own bank records. The user can see their own bankaccounts and open new ones. The project is built so that customers and admins exsists.

-----------
MOTIVATION|
-----------
The motivation behind the creation is we wanted to build a stable and functioning internet bank.

-----------------
Admin & Customer|
-----------------
When the programme is launched the user is directed to the LogInToBankSystem and LogInMenu, where the user is needed to type in their information inorder to proceed to the next menu.

If logged in as a admin you have the options to create new admins and customers. You have the possibility to see who are employed at the bank. Once either a new customer or admin are created the user can log into the bank with the new logg in info they just created. 

If logged in as a customer the user will be logged into the customer menu, where the user will have 7 options on what to do in the menu. 1. Seeing your own bankaccount, 2.transfer money between accounts, 3.transfer money between users, 4.open a new account, 5.close down existing bank account, 6.see you account history, 7.logg out.

---------------
Class Overview|
---------------
The classes we have are the following:

LoggIntoBankSystem, this class has a method called LoggInMenu, this method includes two list one for customer and one for admin. And these lists are lists of objects from customer and admin classes. 

Transaction, this class has fields of account names, dates and amount transaction. We also have a constructor that holds our fields.

User, this class is abstract and contains 2 fields, username and pincode. These fields are needed inorder to logg into to your bank.

Bankaccounts, this class contains 3 fields, this class enables us to assign bankaccounts to every individuell customers. 

Customer, this class inherets from the user class, the class contains 5 fields that are lists, these lists are used in the list of customers that we created in the LoggInMenu method. The class also contains methods, PrintBankAccounts, TransferMoneyToAnotherAccount, TransferMoneyToAnotherCustomer, CreateNewAccount, RemovExistingAccount and PrintTransactionHistory.

Admin, this inherets from user, see row 15 for similar explanation.

Program, we created a object of LoggIntoBankSystem class, then we made a method LoggIntoMenu method.


![imgpsh_mobile_save](https://user-images.githubusercontent.com/91311241/146205838-519c727d-1a33-483f-ace1-3f293ee519bd.jpg)  
Class Admin

![imgpsh_mobile_save](https://user-images.githubusercontent.com/91311241/146206050-dd7dac4b-5ebe-41c3-9f16-bc4b58a9245a.jpg)  
Class Program

![imgpsh_mobile_save](https://user-images.githubusercontent.com/91311241/146206156-5908d6fc-bd50-4faf-9df2-1b50d313923f.jpg)  
 Class BankAccounts
 
![imgpsh_mobile_save](https://user-images.githubusercontent.com/91311241/146206260-6e26c94f-254c-400f-882d-86df3ee0bde5.jpg)  
Class LoggIntoBankSystem

![imgpsh_mobile_save](https://user-images.githubusercontent.com/91311241/146207104-9779c745-0289-4fd8-993c-8e4650cb8d59.jpg)  
 Class Customer
 
![dba7299f-2c48-40d1-bfb6-639e4acd6674](https://user-images.githubusercontent.com/91311241/146208093-9f6355cd-9970-4852-ae91-a9eb2b4b481c.jpg)  
Class Transaction

![68b63f78-1085-4971-8321-a012a95ce25a](https://user-images.githubusercontent.com/91311241/146208135-eb578618-31c0-4739-b0eb-1f0c54360cb9.jpg)  
Class User

----------------
Working Details|
----------------
On this page we disscused and planned, we devided the work between us and worked accourding to Kanban.

Heres a link to our trello where our plans for the project are.
https://trello.com/b/jUvhPcy1/team-tiger

Heres a link to our UML diagram where our flow chart are, planned the structure of the code.
https://lucid.app/lucidchart/7525d290-ba21-425c-96cf-75671118eed3/edit?invitationId=inv_608cfaa3-7df2-4351-a21f-33f3520340b9



