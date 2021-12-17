# Tiger International
-------------
Introduction|
-------------
This program that we have created is an internet bank in wich users can create new accounts and transfer money to other users, they can see their own bank accounts and open new ones. They can also view their own bank transaction history. There are 2 different types of users in this bank system: administrators and customers.

-----------
MOTIVATION|
-----------
The motivation behind This project is that we wanted to build a stable and functioning internet bank system.

-----------------
Admin & Customer|
-----------------
When the programme is launched the user is directed to the LogInToBankSystem Class and the LogInMenu Method, where the user is Prompted to type in their login information in order to proceed to the next menu.

If logged in as an admin you have the options to create new admins and customers. You also have the possibility to see who are employed at the bank. Once either a new customer or admin have been created the user can log into the bank with the new log in details they have just created.

If logged in as a customer the user will be directed to the customer menu, where the user will have 7 options on what to do in the menu. 1. Seeing your own bank accounts, 2. Transfer money between accounts, 3. Transfer money to other users, 4. Open up a new account, 5. Close down an existing bank account, 6. See your transaction history, 7. Logg out.

---------------
Class Overview|
---------------
The classes that we have are the following:

LoggIntoBankSystem, this class has a method called LoggInMenu, this method includes two lists, one for customers and one for admins. And these lists are lists of objects from customer and admin classes. 

Transaction, this class has fields of account names, dates and amount transaction. We also have a constructor that holds our fields.

User, this class is abstract and contains 2 fields, username and pincode. These fields are needed inorder to logg into the bank.

Bankaccounts, this class contains 3 fields, this class enables us to assign bankaccounts to every individual customer.

Customer, this class inherets from the user class, the class contains 5 fields that are lists, these lists are used in the list of customers that we created in the LoggInMenu method. The class also contains the following methods: PrintBankAccounts, TransferMoneyToAnotherAccount, TransferMoneyToAnotherCustomer, CreateNewAccount, RemovExistingAccount and PrintTransactionHistory.

Admin, this class inherets from user, see row 17 for a more detailed explanation.

Program, we created a object of LoggIntoBankSystem class, then we made a method call to the LoggIntoMenu method.


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
On this page we disscused and planned, we divided the work between us and then proceeded to work according to the tenants of the Kanban paradigm.

Here is a link to our trello where our Kanban board for the project is located.
https://trello.com/b/jUvhPcy1/team-tiger

Here is a link to our UML diagram where our class diagram is located, we used it to plan the structure of the code.
https://lucid.app/lucidchart/7525d290-ba21-425c-96cf-75671118eed3/edit?invitationId=inv_608cfaa3-7df2-4351-a21f-33f3520340b9



