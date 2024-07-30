using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayslipDetailsController : ControllerBase
    {
        private readonly IPayslipDetailsBALRepo _payslipBALRepo;
        public PayslipDetailsController(IPayslipDetailsBALRepo payslipBALRepo)
        {
            _payslipBALRepo = payslipBALRepo;       
        }
        [HttpPost("CreatePayslipDetails")]
        public async Task<bool> Create(List<PayslipDetails> _payslipDetails)
        {
            return await _payslipBALRepo.Create(_payslipDetails);
        }
    }
}
