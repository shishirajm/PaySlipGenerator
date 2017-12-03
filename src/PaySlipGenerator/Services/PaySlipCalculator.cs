using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaySlipGenerator.Models;

namespace PaySlipGenerator.Services
{
    public class PaySlipCalculator : IPaySlipCalculator
    {
        public Task<PaySlipResponse> GetPaySlip(PaySlipRequest request)
        {
            var grossIncome = GetMonthly(request.AnnualSalary);
            var incomeTax = GetIncomeTax(request.AnnualSalary, request.PaymentStartDate);

            var response = new PaySlipResponse {
                Name = string.Format("{0} {1}", request.FirstName, request.LastName),
                GrossIncome = grossIncome,
                IncomeTax = incomeTax,
                NetIncome = grossIncome - incomeTax,
                SuperAmount = GetSuper(grossIncome, request.SuperInterestRate),
                PaymentPeriod = string.Format("01 {0} - {1} {2}", request.PaymentStartDate.ToString("MMMM"),
                                DateTime.DaysInMonth(request.PaymentStartDate.Year, request.PaymentStartDate.Month),
                                request.PaymentStartDate.ToString("MMMM"))
                };
            
            return Task.FromResult(response);
        }

        private long GetMonthly(decimal number)
        {
            return Round((decimal)number / 12);
        }

        private long Round(decimal x)
        {
            var roundedDecimal = Math.Round(x, MidpointRounding.AwayFromZero);
            return (long)roundedDecimal;
        }

        private long GetIncomeTax(long annualSalary, DateTime paymentPeriod)
        {
            var year = paymentPeriod.Month <= 6 ? paymentPeriod.Year : paymentPeriod.Year + 1;
            var taxSlabs = GetTaxSlabForYear(year);
            var sortedList = taxSlabs.OrderBy(x => x.AmountFrom).ToList();
            
            decimal tax = 0;
            foreach(var item in sortedList)
            {
                if(annualSalary >= item.AmountTo)
                {
                    tax += GetTax(item.AmountTo, item.AmountFrom, item.TaxCentsPerDollar);
                }
                else
                {
                    tax += GetTax(annualSalary, item.AmountFrom, item.TaxCentsPerDollar);
                    break;
                }
            }

            return Round(GetMonthly(tax));
        }

        private decimal GetTax(long amountTo, long amountFrom, decimal rate)
        {
            if (rate == 0) return 0;

            return (amountTo - amountFrom) * (rate / 100);
        }

        private long GetSuper(long grossIncome, decimal superRate)
        {
            return Round(grossIncome * superRate / 100);
        }

        private List<TaxSlab> GetTaxSlabForYear(int taxYear)
        {
            //Idea was to define different slabs for each year
            //if(taxYear == 2018)
            {
                return new List<TaxSlab>
                {
                    new TaxSlab
                    {
                        AmountFrom = 0,
                        AmountTo = 18200,
                        TaxCentsPerDollar = 0
                    },
                    new TaxSlab
                    {
                        AmountFrom = 18200,
                        AmountTo = 37000,
                        TaxCentsPerDollar = 19
                    },
                    new TaxSlab
                    {
                        AmountFrom = 37000,
                        AmountTo = 87000,
                        TaxCentsPerDollar = (decimal)32.5,
                    },
                    new TaxSlab
                    {
                        AmountFrom = 87000,
                        AmountTo = 180000,
                        TaxCentsPerDollar = (decimal)37,
                    },
                    new TaxSlab
                    {
                        AmountFrom = 180000,
                        AmountTo = long.MaxValue,
                        TaxCentsPerDollar = (decimal)45,
                    }
                };
            }

            return null;
        }
    }
}