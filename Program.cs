using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }   

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getfirstName()
    {
        return firstName;
    }

    public String getlastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;   
    }
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawl");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("What dollar amount would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for you deposit. \nYour new balance is:$ " +currentUser.getBalance());
        }

        void withdrawl(cardHolder currentUser)
        {
            Console.WriteLine("What dollar amount would you like to withdrawl? ");
            double withdrawl = Double.Parse(Console.ReadLine());
            //We need to check funds available
            if(currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("Insufficent balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("Thank you! Have a nice day!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is:$ " +currentUser.getBalance());
        }
        //List of cardholders
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456", 1234, "John", "Smith", 150.50));
        cardHolders.Add(new cardHolder("890123", 5555, "Jane", "Smith", 100.50));
        cardHolders.Add(new cardHolder("456789", 6666, "Bob", "Awalt", 80.50));
        cardHolders.Add(new cardHolder("112345", 7777, "Rich", "Richie", 10.50));

        //Promt User for card number
        Console.WriteLine("Welcome to EZ-ATM");
        Console.WriteLine("Please insert debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check agains DataBase
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your PIN: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect PIN. Please try again"); }
        }

        Console.WriteLine("Welcome back " +currentUser.getfirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdrawl(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if( option == 4) { break; }
            else { option = 0; }

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day!");


    }
        









}
