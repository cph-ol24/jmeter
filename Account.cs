using System;

namespace banking
{
    public class Account
    {
        public decimal Balance { get; set; }

        public Account(decimal balance)
        {
            Balance = balance;
        }
    }
}
