using System.Threading.Tasks;
using System.Web.Http;
using PaySlipGenerator.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PaySlipGenerator.Controllers
{
    [Route("api/payslip")]
    public class PaySlipController : ApiController
    {
        public async Task<IHttpActionResult> GetPaySlip([FromUri]PaySlipRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(request);
        } 
    }
}
