using System;
using System.Collections.Generic;

namespace banking
{
    public class CustomerDiscountCalculator
    {
        private static readonly Dictionary<Tuple<bool, bool, bool>, decimal> _discounts = new Dictionary<Tuple<bool, bool, bool>, decimal>() {
            { new Tuple<bool, bool, bool>(true, true, true), 0 },
            { new Tuple<bool, bool, bool>(true, true, false), 0 },
            { new Tuple<bool, bool, bool>(true, false, true), 20 },
            { new Tuple<bool, bool, bool>(true, false, false), 15 },
            { new Tuple<bool, bool, bool>(false, true, true), 30 },
            { new Tuple<bool, bool, bool>(false, true, false), 10 },
            { new Tuple<bool, bool, bool>(false, false, true), 20 },
            { new Tuple<bool, bool, bool>(false, false, false), 0 },
        };

        public decimal GetDiscount(Customer customer, bool haveCoupon)
        {
            return _discounts[new Tuple<bool, bool, bool>(customer.IsNewCustomer, customer.IsLoyalityCustomer, haveCoupon)];
        }
    }
}