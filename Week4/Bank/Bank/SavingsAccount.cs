using System;

namespace Bank
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string owner, double interestRate, double startingBalance = 0) : base(owner, interestRate, startingBalance)
        {
        }

        public override void Withdraw(double amount)
        {
            if (amount < 0)
            {
                return;
            }

            _balance -= amount;
        }

        public override void AddInterests()
        {
            _balance += _balance * _interestRate;
        }

        public override string ToString()
        {
            return "Savingsaccount as text";
        }
    }
}
