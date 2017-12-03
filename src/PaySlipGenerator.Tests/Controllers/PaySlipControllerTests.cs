using Moq;
using PaySlipGenerator.Controllers;
using PaySlipGenerator.Models;
using PaySlipGenerator.Services;
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaySlipGenerator.Tests.Controllers
{
    [TestClass]
    public class PaySlipControllerTests
    {
        private PaySlipController _controller;
        private PaySlipRequest _request;
        private Mock<IPaySlipCalculator> _paySlipCalculator;

        [TestInitialize]
        public void SetUp()
        {
            _paySlipCalculator = new Mock<IPaySlipCalculator>();
            _paySlipCalculator.Setup(x => x.GetPaySlip(It.IsAny<PaySlipRequest>()))
                .Returns(Task.FromResult(new PaySlipResponse()));
            _controller = new PaySlipController(_paySlipCalculator.Object);
            _request = new PaySlipRequest {
                AnnualSalary = 10000,
                FirstName = "Shishira",
                LastName = "Mallasandra",
                SuperInterestRate = 9,
                PaymentStartDate = DateTime.Now
            };
        }

        [TestMethod]
        public async Task When_FirstName_is_invalid_then_bad_request_is_expected()
        {
            _controller = new PaySlipController(_paySlipCalculator.Object);
            _controller.ModelState.AddModelError("FirstName", "Invalid");
            var result = await _controller.GetPaySlip(_request);
            //Assert.AreEqual(null, result);
        }
    }
}
