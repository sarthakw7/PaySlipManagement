using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PaySlipManagement.Common.Models;
using PaySlipManagement.BAL.Interfaces;

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
        [HttpGet("GetSalaryMetadataById/{id}")]
        public async Task<SalaryMetadata> GetSalaryMetadataByidAsync(int id)
        {
            SalaryMetadata s = new SalaryMetadata();
            s.Id = id;
            return await _salaryBALRepo.GetSalaryMetadataByidAsync(s);
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
        [HttpGet("DeleteSalaryMetadata/{id}")]
        public async Task<bool> DeleteSalaryMetadata(int id)
        {
            SalaryMetadata s = new SalaryMetadata();
            s.Id = id;
            return await _salaryBALRepo.DeleteSalaryMetadata(s);
        }
    }
}
