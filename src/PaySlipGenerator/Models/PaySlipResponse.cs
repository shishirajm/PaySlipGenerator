using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaySlipGenerator.Models
{
    public class PaySlipResponse
    {
        public string Name { get; set; }
        public long GrossIncome { get; set; }
        public long IncomeTax { get; set; }
        public long NetIncome { get; set; }
        public decimal SuperAmount { get; set; }
        public Payment PaymentDetails { get; set; }
    }

    public class Payment
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}