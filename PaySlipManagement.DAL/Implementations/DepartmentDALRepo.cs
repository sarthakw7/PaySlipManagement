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
    public class DepartmentDALRepo: IDepartmentDALRepo
    {
        DapperServices<Department> departmentRepository;

        public DepartmentDALRepo()
        {
            departmentRepository = new DapperServices<Department>();
        }


        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            try
            {
                var result = await departmentRepository.ReadAllAsync(new Department() { Id = null });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Department> GetDepartmentByidAsync(Department _department)
        {
            try
            {
                return await departmentRepository.ReadGetByIdAsync(_department);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Create(Department _department)
        {
            try
            {

                if (_department != null)
                {
                    await departmentRepository.CreateAsync(_department);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Department _department)
        {
            try
            {
                if (_department != null)
                {
                    await departmentRepository.UpdateAsync(_department);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Delete(Department _department)
        {
            try
            {
                if (_department != null)
                {
                    await departmentRepository.DeleteAsync(_department);
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
