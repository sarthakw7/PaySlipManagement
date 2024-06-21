using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.BAL.Interfaces;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentBALRepo _departmentBALRepo;
        public DepartmentController(IDepartmentBALRepo departmentBALRepo)
        {
            _departmentBALRepo=departmentBALRepo;
        }
        [HttpGet("GetAllDepartments")]
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentBALRepo.GetAllDepartmentsAsync();
        }
        [HttpPost("GetDepartmentById")]
        public async Task<Department> GetDepartmentByidAsync(Department _department)
        {
            return await _departmentBALRepo.GetDepartmentByidAsync(_department);
        }
        [HttpPost("CreateDepartment")]
        public async Task<bool> Create(Department _department)
        {
            return await _departmentBALRepo.Create(_department);

        }
        [HttpPut("UpdateDepartment")]
        public async Task<bool> Update(Department _department)
        {
            return await _departmentBALRepo.Update(_department);

        }
        [HttpPost("DeleteDepartment")]
        public async Task<bool> Delete(Department _department)
        {
            return await _departmentBALRepo.Delete(_department);

        }
    }
}
