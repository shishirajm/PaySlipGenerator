using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaySlipGenerator.Models;
using PaySlipGenerator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipGenerator.Tests.Services
{ 
    [TestClass]
    public class PaySlipCalculatorTests
    {
        private PaySlipRequest _request;
        private PaySlipCalculator _service;

        [TestInitialize]
        public void SetUp()
        {
            _request = new PaySlipRequest
            {
                AnnualSalary = 10000,
                FirstName = "Shishira",
                LastName = "Mallasandra",
                SuperInterestRate = 9,
                PaymentStartDate = DateTime.Now
            };
            _service = new PaySlipCalculator();
        }

        [TestMethod]
        public void When_firstName_lastName_are_sent_its_concatenated()
        {
            var expected = string.Format("{0} {1}", _request.FirstName, _request.LastName);
            var result = _service.GetPaySlip(_request).Result;
            Assert.IsTrue(expected == result.Name);
        }

        [DataTestMethod]
        [DataRow(60050, 9, 5004, 922, 450)]
        [DataRow(120000, 10, 10000, 2669, 1000)]
        [DataRow(18600, 10, 1550, 6, 155)]
        [DataRow(18630, 3.25, 1553, 7, 50)]
        [DataRow(0, 12, 0, 0, 0)]
        [DataRow(120000, 0, 10000, 2669, 0)]
        [DataRow(2000000, 10, 166667, 72769, 16667)]
        public void When_inputs_are_valid_expected_output_should_show(long salary, double super,
            long expectedGross, long expectedTax, long expectedSuper)
        {
            _request.AnnualSalary = salary;
            _request.SuperInterestRate = (decimal)super;

            var result = _service.GetPaySlip(_request).Result;
            Assert.IsTrue(expectedGross == result.GrossIncome);
            Assert.IsTrue(expectedTax == result.IncomeTax);
            Assert.IsTrue(expectedGross - expectedTax == result.NetIncome);
            Assert.IsTrue(expectedSuper == result.SuperAmount);
        }
    }
}
