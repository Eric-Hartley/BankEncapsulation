using System.ComponentModel.Design;
using System.Security.Principal;

namespace BankEncapsulation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            ATM(account);
        }

        private static BankAccount ATM(BankAccount account)
        {
            Console.WriteLine("Welcome! What can I help you with today?");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Balance Inquiry");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("0. Exit");

            var input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                if (option == 1)
                {
                    Console.WriteLine("How much would you like to deposit?");
                    double.TryParse(Console.ReadLine(), out double amount);

                    if (amount > 0.00)
                    {
                        account.Deposit(amount);
                        Console.WriteLine($"Deposit of ${amount} complete.");
                        return ATM(account);

                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        return ATM(account);
                    }

                }
                else if (option == 2)
                {
                    Console.WriteLine($"Your balance is ${account.GetBalance()}");
                    return ATM(account);
                }
                else if (option == 3)
                {
                    Console.WriteLine("How much would you like to withdraw?");
                    double.TryParse(Console.ReadLine(), out double amount);

                    if (amount > 0.00 && amount < account.GetBalance())
                    {
                        account.Withdraw(amount);
                        Console.WriteLine($"withdrawal of ${amount} complete.");
                        return ATM(account);

                    }
                    else if (amount > 0.00 && amount > account.GetBalance())
                    {
                        Console.WriteLine("You do not have the funds to complete" +
                            " this withdrawal.");
                        return ATM(account);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        return ATM(account);
                    }
                }
                else if (option == 0)
                {
                    Console.WriteLine("Have a great day.");
                    return account;
                }
                Console.WriteLine("Invalid Input");
                return ATM(account);
            }
            
            return account;
        }
    }
}
