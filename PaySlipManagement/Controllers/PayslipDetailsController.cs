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
        public async Task<IActionResult> Create(List<PayslipDetails> payslipDetails)
        {
            var result = await _payslipBALRepo.Create(payslipDetails);
            if (result)
            {
                return Ok("Imported Successfully");
            }
            return BadRequest("Failed to import payslips");
        }

        [HttpGet("GetAllPayslipDetails")]
        public async Task<ActionResult<IEnumerable<PayslipDetails>>> GetAll()
        {
            var payslips = await _payslipBALRepo.GetAll();
            return Ok(payslips);
        }

        [HttpGet("GetPayslipDetails/{id}")]
        public async Task<ActionResult<PayslipDetails>> GetPayslipDetails(int? id)
        {
            var payslip = await _payslipBALRepo.GetById(id);
            if (payslip == null)
            {
                return NotFound();
            }
            return Ok(payslip);
        }

        [HttpPut("UpdatePayslipDetails")]
        public async Task<IActionResult> UpdatePayslipDetails(PayslipDetails payslipDetails)
        {
            var result = await _payslipBALRepo.Update(payslipDetails);
            if (result)
            {
                return Ok("Updated Successfully");
            }
            return BadRequest("Failed to update payslip");
        }

        [HttpDelete("DeletePayslipDetails/{id}")]
        public async Task<IActionResult> DeletePayslipDetails(int? id)
        {
            var result = await _payslipBALRepo.Delete(id);
            if (result)
            {
                return Ok(true);
            }
            return NotFound();
        }
    }
}
