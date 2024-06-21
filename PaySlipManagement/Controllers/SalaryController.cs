using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryBALRepo _salaryBALRepo;
        public SalaryController(ISalaryBALRepo _salBALRepo)
        {
            _salaryBALRepo = _salBALRepo;
        }
        [HttpGet("GetAllSalaryMetadata")]
        public async Task<IEnumerable<SalaryMetadata>> GetAllSalaryMetadataAsync()
        {
            return await _salaryBALRepo.GetAllSalaryMetadataAsync();
        }
        [HttpPost("GetSalaryMetadataById")]
        public async Task<SalaryMetadata> GetSalaryMetadataByidAsync(SalaryMetadata _salaryMetadata)
        {
            return await _salaryBALRepo.GetSalaryMetadataByidAsync(_salaryMetadata);
        }
        [HttpPost("CreateSalaryMetadata")]
        public async Task<bool> CreateSalaryMetadata(SalaryMetadata _salaryMetadata)
        {
            return await _salaryBALRepo.CreateSalaryMetadata(_salaryMetadata);

        }
        [HttpPut("UpdateSalaryMetadata")]
        public async Task<bool> UpdateSalaryMetadata(SalaryMetadata _salaryMetadata)
        {
            return await _salaryBALRepo.UpdateSalaryMetadata(_salaryMetadata);

        }
        [HttpPost("DeleteSalaryMetadata")]
        public async Task<bool> DeleteSalaryMetadata(SalaryMetadata salaryMetadata)
        {
            return await _salaryBALRepo.DeleteSalaryMetadata(salaryMetadata);
        }
    }
}
