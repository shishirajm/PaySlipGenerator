using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PaySlipGenerator.Models;

namespace PaySlipGenerator.Services
{
    public class PaySlipCalculator : IPaySlipCalculator
    {
        public Task<PaySlipResponse> GetPaySlip(PaySlipRequest request)
        {
            var response = new PaySlipResponse {
                Name = string.Format("{0} {1}", request.FirstName, request.LastName)
            };

            return Task.FromResult(response);
        }

        private List<TaxSlab> GetTaxSlabForYear(int financialYearBeginning)
        {
            if(financialYearBeginning == 2017)
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