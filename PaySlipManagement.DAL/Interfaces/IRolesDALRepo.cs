using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Interfaces
{
    public  interface IRolesDALRepo
    {
        Task<IEnumerable<Roles>> GetAllAsync();
        Task<Roles> GetByIdAsync(Roles roles);
        Task<bool> Create(Roles roles);
        Task<bool> Update(Roles roles);
        Task<bool> Delete(Roles roles);
    }
}
