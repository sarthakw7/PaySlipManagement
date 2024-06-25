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
    public class UserRoleBALRepo : IUserRoleBALRepo
    {
        private UserRolesDALRepo userRoleDALRepo;

        public UserRoleBALRepo()
        {
            userRoleDALRepo = new UserRolesDALRepo();
        }

       public async Task<IEnumerable<UserRoles>> GetAllAsync()
        {
            return await userRoleDALRepo.GetAllAsync();
        }

        public async Task<UserRoles> GetByIdAsync(UserRoles userRoles)
        {
            return await userRoleDALRepo.GetByIdAsync(userRoles);
        }

        public async Task<bool> Create(UserRoles userRoles)
        {
            return await userRoleDALRepo.Create(userRoles);
        }

        public async Task<bool> Update(UserRoles userRoles)
        {
            return await userRoleDALRepo.Update(userRoles);
        }

        public async Task<bool> Delete(UserRoles userRoles)
        {
            return  await userRoleDALRepo.Delete(userRoles);
        }

       
    }
}
