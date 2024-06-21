using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.DapperServices.Implementations;
using PaySlipManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Implementations
{
    public class EmployeeDALRepo:IEmployeeDALRepo
    {
        DapperServices<Employee> _employeeDALRepo;
        public EmployeeDALRepo()
        {
            _employeeDALRepo = new DapperServices<Employee>();
        }

      public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                var result = await _employeeDALRepo.ReadAllAsync(new Employee() { Id = null });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(Employee _employee)
        {
            try
            {
                return await _employeeDALRepo.ReadGetByIdAsync(_employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> AddEmployee(Employee _employee)
        {
            try
            {

                if (_employee != null)
                {
                    await _employeeDALRepo.CreateAsync(_employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteEmployee(Employee _employee)
        {
            try
            {
                if (_employee != null)
                {
                    await _employeeDALRepo.DeleteAsync(_employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateEmployee(Employee _employee)
        {
            try
            {
                if (_employee != null)
                {
                    await _employeeDALRepo.UpdateAsync(_employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
