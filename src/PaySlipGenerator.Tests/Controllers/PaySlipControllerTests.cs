using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PaySlipGenerator.Controllers;
using PaySlipGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipGenerator.Tests.Controllers
{
    [TestClass]
    public class PaySlipControllerTests
    {
        private PaySlipController _controller;
        private PaySlipRequest _request;

        [TestInitialize]
        public void SetUp()
        {
            _controller = new PaySlipController();
            _request = new PaySlipRequest {
                AnnualSalary = 10000,
                FirstName = "Shishira",
                LastName = "Mallasandra",
                SuperInterestRate = 9,
                PaymentStartDate = DateTime.Now
            };
        }

        [TestMethod]
        public void When_FirstName_is_invalid_then_bad_request_is_expected()
        {
            _request.FirstName = "";
            var result = _controller.GetPaySlip(_request).Result;
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
