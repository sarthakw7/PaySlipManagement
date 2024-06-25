using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.Implementations;
using PaySlipManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Implementations
{
    public class RoleBALRepo : IRoleBALRepo
    {
        private RolesDALRepo _roleDALRepo;

        public RoleBALRepo()
        {
            _roleDALRepo = new RolesDALRepo();
        }

        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _roleDALRepo.GetAllAsync();
        }
        public async  Task<Roles> GetByIdAsync(Roles roles)
        {
            return await _roleDALRepo.GetByIdAsync(roles);
        }

        public async Task<bool> Create(Roles roles)
        {
            return await _roleDALRepo.Create(roles);   
        }

        public async Task<bool> Update(Roles roles)
        {
            return await _roleDALRepo.Update(roles);
        }

        public async Task<bool> Delete(Roles roles)
        {
            return await _roleDALRepo.Delete(roles);
        }


    }
}
