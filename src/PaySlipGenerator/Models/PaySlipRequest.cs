using System;
using System.ComponentModel.DataAnnotations;
using PaySlipGenerator.Helpers;

namespace PaySlipGenerator.Models
{
    public class PaySlipRequest
    {
        [Required]
        [RegularExpression(Constants.ValidationRegex.Name, ErrorMessage = "First name is invalid.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(Constants.ValidationRegex.Name, ErrorMessage = "Last name is invalid.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(Constants.ValidationRegex.NumberWithTwoDecimal, ErrorMessage = "Invalid annual salary")]
        public long AnnualSalary { get; set; }

        [Required]
        [Range(0.00, 12.00)]
        [RegularExpression(Constants.ValidationRegex.NumberWithTwoDecimal, ErrorMessage = "Invalid super interest rate.")]
        public decimal SuperInterestRate { get; set; }

        [Required]
        public DateTime PaymentStartDate { get; set; }
    }
}