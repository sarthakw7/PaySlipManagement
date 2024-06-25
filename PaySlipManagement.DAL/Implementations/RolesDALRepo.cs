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
    public class RolesDALRepo : IRolesDALRepo
    {
        DapperServices<Roles> _rolesDALRepo;
        public RolesDALRepo() 
        { 
            _rolesDALRepo = new DapperServices<Roles>();
        }
       
        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            var result = await _rolesDALRepo.ReadAllAsync(new Roles() { Id = null, Role =null });

            return result;
        }
        public async Task<bool> Create(Roles roles)
        {

            if (roles != null)
            {
                await _rolesDALRepo.CreateAsync(roles);
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(Roles roles)
        {
            if (roles != null)
            {
                await _rolesDALRepo.DeleteAsync(roles);
                return true;
            }
            return false;
        }

        public async Task<Roles> GetByIdAsync(Roles roles)
        {
            return await _rolesDALRepo.ReadGetByIdAsync(roles);
        }

        public async Task<bool> Update(Roles roles)
        {
            if (roles != null)
            {
                await _rolesDALRepo.UpdateAsync(roles);
                return true;
            }

            return false;
        }
    }
}
