using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaySlipGenerator.Models
{
    public class PaySlipResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal SuperInterestRate { get; set; }
        public DateTime PaymentStartDate { get; set; }
        public DateTime PaymentEndDate { get; set; }
    }
}