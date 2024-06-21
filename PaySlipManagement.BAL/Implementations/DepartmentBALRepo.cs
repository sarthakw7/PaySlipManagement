using PaySlipManagement.Common.Models;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.DAL.Implementations;
using PaySlipManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Implementations
{
    public class DepartmentBALRepo : IDepartmentBALRepo
    {
        DepartmentDALRepo _departmentDALRepo=new DepartmentDALRepo();

        public async Task<bool> Create(Department _department)
        {
           return await _departmentDALRepo.Create(_department);
        }

        public async Task<bool> Delete(Department _department)
        {
            return await _departmentDALRepo.Delete(_department);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentDALRepo.GetAllDepartmentsAsync();
        }

        public async Task<Department> GetDepartmentByidAsync(Department _department)
        {
            return await _departmentDALRepo.GetDepartmentByidAsync(_department);
        }

        public async Task<bool> Update(Department _department)
        {
            return await _departmentDALRepo.Update(_department);
        }
    }
}
