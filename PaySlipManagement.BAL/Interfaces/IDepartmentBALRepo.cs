using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Interfaces
{
    public interface IDepartmentBALRepo
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();

        Task<Department> GetDepartmentByidAsync(Department _department);
        Task<bool> Create(Department _department);
        Task<bool> Update(Department _department);
        Task<bool> Delete(Department _department);
    }
}
