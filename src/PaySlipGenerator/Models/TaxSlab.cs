using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaySlipGenerator.Models
{
    public class TaxSlab
    {
        public long AmountFrom { get; set; }
        public long AmountTo { get; set; }
        public decimal TaxCentsPerDollar { get; set; }
    }
}