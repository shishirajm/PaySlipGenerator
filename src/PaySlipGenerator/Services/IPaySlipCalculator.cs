using PaySlipGenerator.Models;
using System.Threading.Tasks;

namespace PaySlipGenerator.Services
{
    public interface IPaySlipCalculator
    {
        Task<PaySlipResponse> GetPaySlip(PaySlipRequest request);
    }
}
