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
    public class EmployeeTypeDALRepo:IEmployeeTypeDALRepo
    {
        DapperServices<EmployeeType> employeeTypeRepository;
        public EmployeeTypeDALRepo()    
        {
            employeeTypeRepository = new DapperServices<EmployeeType>();
        }


        public async Task<IEnumerable<EmployeeType>> GetAllEmployeeTypeAsync()
        {
            try
            {
                var result = await employeeTypeRepository.ReadAllAsync(new EmployeeType() { Id = null });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<EmployeeType> GetEmployeeTypeByidAsync(EmployeeType _employeeType)
        {
            try
            {
                return await employeeTypeRepository.ReadGetByIdAsync(_employeeType);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> CreateEmployeeType(EmployeeType _employeeType)
        {
            try
            {

                if (_employeeType != null)
                {
                    await employeeTypeRepository.CreateAsync(_employeeType);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateEmployeeType(EmployeeType _employeeType)
        {
            try
            {
                if (_employeeType != null)
                {
                    await employeeTypeRepository.UpdateAsync(_employeeType);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> DeleteEmployeeType(EmployeeType employeeType)
        {
            try
            {
                if (employeeType != null)
                {
                    await employeeTypeRepository.DeleteAsync(employeeType);
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
