using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ICompanyDetailsBALRepo _companydetailsBALRepo;
        private readonly ILogger<CompanyDetailsController> _logger;
        public CompanyDetailsController(ICompanyDetailsBALRepo _cmpdetailsBALRepo, ILogger<CompanyDetailsController> logger)
        {
            _companydetailsBALRepo = _cmpdetailsBALRepo;
            _logger = logger;
        }
        [HttpGet("GetAllCompanyDetails")]
        public async Task<IEnumerable<CompanyDetails>> GetAllCompanyDetailsAsync()
        {
            _logger.LogInformation("Company details API called");
            return await _companydetailsBALRepo.GetAllCompanyDetailsAsync();
        }
        [HttpGet("GetCompanyDetailsById/{id}")]
        public async Task<CompanyDetails> GetCompanyDetailsByidAsync(int id)
        {
            CompanyDetails _companyDetails = new CompanyDetails();
            _companyDetails.Id = id;
            return await _companydetailsBALRepo.GetCompanyDetailsByidAsync(_companyDetails);
        }
        [HttpPost("CreateCompanyDetails")]
        public async Task<bool> CreateCompanyDetails(CompanyDetails _companyDetails)
        {
            return await _companydetailsBALRepo.CreateCompanyDetails(_companyDetails);

        }
        [HttpPut("UpdateCompanyDetails")]
        public async Task<bool> UpdateCompanyDetails(CompanyDetails _companyDetails)
        {
            return await _companydetailsBALRepo.UpdateCompanyDetails(_companyDetails);

        }
        [HttpGet("DeleteCompanyDetails/{id}")]
        public async Task<bool> DeleteCompanyDetails(int id)
        {
            CompanyDetails companyDetails = new CompanyDetails();
            companyDetails.Id = id;
            return await _companydetailsBALRepo.DeleteCompanyDetails(companyDetails);
        }
    }
}
