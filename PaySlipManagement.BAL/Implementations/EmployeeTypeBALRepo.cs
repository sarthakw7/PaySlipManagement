using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Implementations
{
    public class EmployeeTypeBALRepo: IEmployeeTypeBALRepo
    {
        public EmployeeTypeDALRepo _employeeTypeDALRepo = new EmployeeTypeDALRepo();

        public async Task<IEnumerable<EmployeeType>> GetAllEmployeeTypeAsync()
        {
            return await _employeeTypeDALRepo.GetAllEmployeeTypeAsync();
        }

        public async Task<EmployeeType> GetEmployeeTypeByidAsync(EmployeeType _employeeType)
        {
            return await _employeeTypeDALRepo.GetEmployeeTypeByidAsync(_employeeType);
        }
        public async Task<bool> CreateEmployeeType(EmployeeType _employeeType)
        {
            return await _employeeTypeDALRepo.CreateEmployeeType(_employeeType);

        }
        public async Task<bool> UpdateEmployeeType(EmployeeType _employeeType)
        {
            return await _employeeTypeDALRepo.UpdateEmployeeType(_employeeType);

        }
        public async Task<bool> DeleteEmployeeType(EmployeeType employeeType)
        {
            return await _employeeTypeDALRepo.DeleteEmployeeType(employeeType);

        }
    }
}
