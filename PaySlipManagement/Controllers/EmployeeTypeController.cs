using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeBALRepo _employeeTypeBALRepo;
        public EmployeeTypeController(IEmployeeTypeBALRepo employeeTypeBALRepo)
        {
            _employeeTypeBALRepo = employeeTypeBALRepo;
        }
        [HttpGet("GetAllEmployeeType")]
        public async Task<IEnumerable<EmployeeType>> GetAllEmployeeTypeAsync()
        {
            return await _employeeTypeBALRepo.GetAllEmployeeTypeAsync();
        }
        [HttpGet("GetEmployeeTypeById/{id}")]
        public async Task<EmployeeType> GetEmployeeTypeByidAsync(int id)
        {
            EmployeeType _employeeType = new EmployeeType();
            _employeeType.Id = id;
            return await _employeeTypeBALRepo.GetEmployeeTypeByidAsync(_employeeType);
        }
        [HttpPost("CreateEmployeeType")]
        public async Task<bool> CreateEmployeeType(EmployeeType _employeeType)
        {
            return await _employeeTypeBALRepo.CreateEmployeeType(_employeeType);

        }
        [HttpPut("UpdateEmployeeType")]
        public async Task<bool> UpdateEmployeeType(EmployeeType _employeeType)
        {
            return await _employeeTypeBALRepo.UpdateEmployeeType(_employeeType);

        }
        [HttpGet("DeleteEmployeeType/{id}")]
        public async Task<bool> DeleteEmployeeType(int id)
        {
            EmployeeType employeeType = new EmployeeType();
            employeeType.Id = id;
            return await _employeeTypeBALRepo.DeleteEmployeeType(employeeType);
        }
    }
}
