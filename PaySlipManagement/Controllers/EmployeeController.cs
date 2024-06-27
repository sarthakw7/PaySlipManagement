using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.BAL.Implementations;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.DAL.Interfaces;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBALRepo _employeeBALRepo;
        public EmployeeController(IEmployeeBALRepo _empBALRepo)
        {
            _employeeBALRepo = _empBALRepo;
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeBALRepo.GetAllEmployees();
        }
        [HttpGet("GetEmployeeById/{id}")]
        public async Task<Employee> GetEmployeeByidAsync(int id)
        {
            Employee emp = new Employee();
            emp.Id = id;
            return await _employeeBALRepo.GetEmployeeById(emp);
        }
        [HttpPost("CreateEmployee")]
        public async Task<bool> Create(Employee _employee)
        {
            return await _employeeBALRepo.AddEmployee(_employee);

        }
        [HttpPut("UpdateEmployee")]
        public async Task<bool> Update(Employee _employee)
        {
            return await _employeeBALRepo.UpdateEmployee(_employee);

        }
        [HttpGet("DeleteEmployee/{id}")]
        public async Task<bool> Delete(int id)
        {
            Employee emp = new Employee();
            
                emp.Id = id;
            
            return await _employeeBALRepo.DeleteEmployee(emp);
        }
    }
}
