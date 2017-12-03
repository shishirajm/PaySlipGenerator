using System;
using System.ComponentModel.DataAnnotations;

namespace PaySlipGenerator.Models
{
    public class PaySlipRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal AnnualSalary { get; set; }
        [Required]
        public decimal SuperInterestRate { get; set; }
        [Required]
        public DateTime PaymentStartDate { get; set; }
        [Required]
        public DateTime PaymentEndDate { get; set; }
    }
}