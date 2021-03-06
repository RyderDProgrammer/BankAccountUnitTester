using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountUnitTester
{
    /// <summary>
    /// Represents a single checking account
    /// </summary>
    public class Account
    {

        /// <summary>
        /// Deposits the amount in the bank account
        /// and returns the new balance
        /// </summary>
        /// <param name="amt">The amount to deposit</param>
        public double Deposit(double amt)
        {
            if(amt >= 10000)
            {
                throw new ArgumentException($"{nameof(amt)} must be smaller than 10000");
            }
            if(amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} has to be greater than 0");
            }
            Balance += amt;
            return Balance;
        }

        public void Withdraw(double amt)
        {
            if(amt > Balance)
            {
                throw new ArgumentException("You cannot withdraw more than the current balance");
            }
            if(amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} needs to be greater than 0");
            }
            Balance -= amt;
        }

        /// <summary>
        /// Gets the current balance
        /// </summary>
        public double Balance { get; private set; }
    }
}
