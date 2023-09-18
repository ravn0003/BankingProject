using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    internal class Account
    {
        //These are the properties
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public double Balance { get; set; }
        public double MonthlyDeposit { get; set; }

        //Field static properties
        private static double MonthlyFee = 4.0;
        private static double MonthlyInterestRate = 0.0025;
        private static int MinimumInitialBalance = 1000;
        private static int MaximumInitialDeposit = 50;


        //Creating Constructor
        public Account(string nameOfOwner, double initialDepositAmount)
        {
            OwnerName = nameOfOwner;
            Balance = initialDepositAmount;
            string helperAccountNumber = "";
            // Generating account number randomly
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                helperAccountNumber += random.Next(0, 10);
            }
            AccountNumber = helperAccountNumber;
        }

        public void Deposit(double BalanceAmount)
        {
            //Deposit- it takes a double as a parameter to inc. the balance
            Balance += BalanceAmount;

        }

        public void Withdraw(double WithdrawAmount)
        {
            //It takes a double as a parameter to dec. the balance
            Balance -= WithdrawAmount;
        }


    }
}