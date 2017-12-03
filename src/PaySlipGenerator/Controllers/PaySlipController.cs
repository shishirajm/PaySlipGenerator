using System.Threading.Tasks;
using System.Web.Http;
using PaySlipGenerator.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using PaySlipGenerator.Services;

namespace PaySlipGenerator.Controllers
{
    [Route("api/payslip")]
    public class PaySlipController : ApiController
    {
        private IPaySlipCalculator _paySlipCalculator;

        public PaySlipController(IPaySlipCalculator paySlipCalculator)
        {
            _paySlipCalculator = paySlipCalculator;
        }

        public async Task<IHttpActionResult> GetPaySlip([FromUri]PaySlipRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var x = await _paySlipCalculator.GetPaySlip(request);

            return Ok(x);
        } 
    }
}
