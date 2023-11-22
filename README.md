# Grupparbete -BinaryBats

In the class BankAccount we have created two properties.
The first property Accountnumber: has only “get;” in that way we could not change the value after it has been created.
The seconds property Balance: has “get; and set;”, the value can be changed after created.
Afterwards we made a constructor with two variables to be able to type in the value when we are making an instance in another class. .
In this same class we then made a method called Transfer() which include the datatype “BankAccount”
The method lets the user type in how much money the user wants to transfer.
In the method have an if sats to make a condition, if the amount the user type in is more than zero and more or as much as any balance then the transfer is successful. 

The LoginManager class is controlling the user login attempts. 
LoginManager class has public properties MaxAttempts and attempts.  
There is also a TryLogin method with parameters username and password. 
The user writes in username and password and returns a bool whether the login attempt is successful.  
entered username and password are returned through the parameters. 

This program is a login system with two roles, either admin or user. 
Class program initiates the application, utilizing a LoginManager for login attempts.  
The user is presented with options to log in as admin, user or exit the program, with maximum three login attempts.  
With a successful login the user is directed to role-specific menu admin menu or user menu. 
with functions like adding users, check balance or transferring money. 
Every menu has a log out option and returns to the main menu. 

We made a method-list from the datatype BankAccount named CreateBankAccounts(). In that method we made a list named Userccounts where we created accounts and decided the AccountNumber and the Balande in each account. We then added the created accounts in the list with “add.”. Lastly, we returned UserAccounts.
The next method we created was a private void method called “DisplayUserAccounts” and contains a list of accounts. The method will print out each account and its salary.
We after made a void method named CheckSaldo(). Here we made a variable (useraccounts) from the list BankAccount and put it equals to the method CreateBankAccounts(). The we called out “DisplayUserAccounts (useraccounts)”
Further on we made a void method called AddUser.
In the method we have a while loop, in loop the user is being asked if he/she wants to add users and has to type in yes or no.
In the loop we then made an if sats, if the user type yes he/she will be required to type a name.
 
We then have a void method that we named “TransferMethod”.
In the method we put the list of userAccounts from the method “CreateBankAccounts()”.
We also have a while loop, in the loop the user will be asked if she/he wants to transfer money. We made a if sats with a condition, if there is more than two accounts available then two variables “SourceAccount” and “DestionationAccount” of the objects in the list will be created. By using the transfer method we can let the SourceAccount tranfer money to DestinationAccount .
After that the updated account balances will be displayed y calling the DisplayUserAccount Method (userAccount).
Ww lastly have public void RunApplication(). This method first creates a instans from the class LoginManger and then calls the Run() method.
