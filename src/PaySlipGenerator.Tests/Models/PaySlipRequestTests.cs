using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaySlipGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PaySlipGenerator.Tests.Models
{
    [TestClass]
    public class PaySlipRequestTests
    {
        private PaySlipRequest _request;

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
        }

        [TestMethod]
        public void When_all_the_fields_are_valid_then_model_should_be_valid()
        {
            var result = ValidateModel(_request);
            Assert.AreEqual(0, result.Count);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("some space")]
        [DataRow("some#character")]
        public void When_FirstName_is_invalid_then_model_should_be_error(string firstName)
        {
            _request.FirstName = firstName;
            var result = ValidateModel(_request);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("FirstName", result[0].MemberNames.First());
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("some space")]
        [DataRow("some#character")]
        public void When_LastName_is_invalid_then_model_should_be_error(string lastName)
        {
            _request.LastName = lastName;
            var result = ValidateModel(_request);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("LastName", result[0].MemberNames.First());
        }

        [DataTestMethod]
        [DataRow(-1.1)]
        [DataRow(1.012)]
        public void When_AnnualSalary_is_invalid_then_model_should_be_error(double salary)
        {
            _request.AnnualSalary = (decimal)salary;
            var result = ValidateModel(_request);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("AnnualSalary", result[0].MemberNames.First());
        }

        [DataTestMethod]
        [DataRow(-1.1)]
        [DataRow(1.012)]
        public void When_SuperInterestRate_is_invalid_then_model_should_be_error(double interest)
        {
            _request.SuperInterestRate = (decimal)interest;
            var result = ValidateModel(_request);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("SuperInterestRate", result[0].MemberNames.First());
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
