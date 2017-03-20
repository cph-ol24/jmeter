using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace banking.Controllers
{
    [Route("api")]
    public class ValuesController : Controller
    {
        private static readonly CustomerDiscountCalculator _customerDiscountCalculator = new CustomerDiscountCalculator();
        private static readonly InterestCalculator _interestCalculator = new InterestCalculator();

        // GET api/values
        [HttpGet]
        [Route("discount")]
        public ActionResult Discount(DiscountModels.Get model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = new Customer()
            {
                IsLoyalityCustomer = model.IsLoyality,
                IsNewCustomer = model.IsNewCustomer
            };

            return Ok(_customerDiscountCalculator.GetDiscount(customer, model.HaveCoupon));
        }

        // GET api/values
        [HttpGet]
        [Route("interest")]
        public ActionResult Interest(decimal balence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_interestCalculator.Calculate(balence));
        }
    }

    public class DiscountModels
    {
        public class Get
        {
            [Required]
            public bool IsLoyality { get; set; }

            [Required]
            public bool IsNewCustomer { get; set; }

            [Required]
            public bool HaveCoupon { get; set; }
        }
    }
}
