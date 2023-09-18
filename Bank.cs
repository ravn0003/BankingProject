using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Lab4
{
    public class Bank
    {


        static void Main(string[] args)
        {
            bool keepLooping = true;
            bool isDataFull = false;

            // Prompt the user to enter the number of months to deposit
            Console.WriteLine("Enter the number of months to deposit: ");
            string InputByUser = Console.ReadLine();
            int NumOfMonthsToDeposit = 0;

            // Convert the user input to an integer if it's not empty or null
            if (!string.IsNullOrEmpty(InputByUser)){
                NumOfMonthsToDeposit = Convert.ToInt32(InputByUser);
            }

            // Create a list to store account data
            List<Account> data = new List<Account>();

            while (keepLooping)
            {

                // Prompt the user to enter the customer's name
                Console.Write("Enter Customer's Name:");
                string NameOfCustomer = Console.ReadLine();

                string initialDepositAmountString = "";
                string monthlyDepositAmountString = "";
                double initialDepositAmountDouble = 0.0;
                double monthlyDepositAmountDouble = 0.0;

                // Check if the customer's name is not empty or null
                if (!string.IsNullOrEmpty(NameOfCustomer))

                {   // Prompt the user to enter the initial deposit amount for the customer
                    Console.WriteLine($"Enter {NameOfCustomer} Initial Deposit Amount (minimum $1,000.00):");
                    initialDepositAmountString = Console.ReadLine();

                    // Prompt the user to enter the monthly deposit amount for the customer
                    Console.WriteLine($"Enter {NameOfCustomer} Monthly Deposit Amount (minimum $50.00):");
                    monthlyDepositAmountString = Console.ReadLine();


                    // Convert the initial deposit amount to a double if it's not empty or null
                    if (!string.IsNullOrEmpty(initialDepositAmountString))
                    {
                        initialDepositAmountDouble = Convert.ToDouble(initialDepositAmountString);
                    }

                    // Convert the monthly deposit amount to a double if it's not empty or null
                    if (!string.IsNullOrEmpty(monthlyDepositAmountString))
                    {
                        monthlyDepositAmountDouble = Convert.ToDouble(monthlyDepositAmountString);
                    }


                    // Check if the initial deposit amount is less than the minimum required
                    if (initialDepositAmountDouble < Account.MinimumInitialBalance)
                    {
                        Console.WriteLine($"Enter an amount above or equal {Account.MinimumInitialBalance}");
                        continue;
                    }

                    // Check if the monthly deposit amount is less than the maximum allowed
                    if (monthlyDepositAmountDouble < Account.MaximumInitialDeposit)
                    {
                        Console.WriteLine($"Enter an amount above or equal {monthlyDepositAmountDouble}");
                        continue;
                    }


                    // Set the dataFull flag to true since data for at least one customer is entered
                    isDataFull = true;

                    // Create an instance of the Account class for the current customer
                    Account accountInstance = new Account(NameOfCustomer, initialDepositAmountDouble);

                    // Perform calculations for the specified number of months
                    for (int start = 0; start < NumOfMonthsToDeposit; start++)
                    {
                        accountInstance.Withdraw(Account.MonthlyFee);
                        double rateToAdd = Math.Round((Account.MonthlyInterestRate * accountInstance.Balance), 2);
                        accountInstance.Deposit(rateToAdd);
                        accountInstance.Deposit(Math.Round(monthlyDepositAmountDouble, 2));
                    }

                    // Add the account instance to the data list
                    data.Add(accountInstance);

}
                // Check if the customer's name is empty or null and data for at least one customer is entered
                else if (string.IsNullOrEmpty(NameOfCustomer) && isDataFull == true)
                {

                    // Display the account balances for all customers
                    foreach (Account value in data)
                    {
                        Console.WriteLine($"After {NumOfMonthsToDeposit} months, {value.OwnerName}'s account #({value.AccountNumber}) has a balance of ${value.Balance}");
                    }

                    // Exit the program
                    keepLooping = false;
                    Console.WriteLine("");
                    Console.WriteLine("Press Enter to leave");
                    Console.Read();

                }
 



            }
        }
    }

}