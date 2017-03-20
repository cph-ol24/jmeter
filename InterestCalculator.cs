using System;

namespace banking
{
    public class InterestCalculator
    {
        public decimal Calculate(decimal money)
        {
            if (money < 0)
            {
                throw new InvalidOperationException($"'{money}' is not a valid value");
            }

            if (money <= 100)
            {
                return 3;
            }

            if (money < 1000) {
                return 5;
            }

            return 7;
        }
    }
}