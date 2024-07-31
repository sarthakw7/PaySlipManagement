using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Interfaces
{
    public interface IEmployeeTypeDALRepo
    {
        Task<IEnumerable<EmployeeType>> GetAllEmployeeTypeAsync();
        Task<EmployeeType> GetEmployeeTypeByidAsync(EmployeeType _employeeType);
        Task<bool> CreateEmployeeType(EmployeeType _employeeType);
        Task<bool> UpdateEmployeeType(EmployeeType _employeeType);
        Task<bool> DeleteEmployeeType(EmployeeType employeeType);
    }
}
