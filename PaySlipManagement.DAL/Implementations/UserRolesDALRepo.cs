using NPOI.SS.Formula.Functions;
using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.DapperServices.Implementations;
using PaySlipManagement.DAL.DapperServices.Interfaces;
using PaySlipManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Implementations
{
    public class UserRolesDALRepo : IUserRolesDALRepo
    {
        DapperServices<UserRoles> _userRoleRepositary;

        public UserRolesDALRepo()
        {
            _userRoleRepositary = new DapperServices<UserRoles>();

        }

        public async Task<IEnumerable<UserRoles>> GetAllAsync()
        {
            var result = await _userRoleRepositary.ReadAllAsync(new UserRoles() { Id = null, Emp_Code = null, RoleId = null });

            return result ;
        }

        public async Task<UserRoles> GetByIdAsync(UserRoles userRoles)
        {
            return await _userRoleRepositary.ReadGetByIdAsync(userRoles);
        }

        public async  Task<bool> Create(UserRoles userRoles)
        {
            if (userRoles != null)
            {
                var employeeExists = await _userRoleRepositary.CheckEmployeeExistsAsync(userRoles.Emp_Code);
                if (!employeeExists)
                {
                    return false; // Employee does not exist, creation cannot proceed
                }

                var roleExists = await _userRoleRepositary.CheckRoleExistsAsync(userRoles.RoleId);
                if (!roleExists)
                {
                    return false; // Role does not exist, creation cannot proceed
                }

                await _userRoleRepositary.CreateAsync(userRoles);
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(UserRoles userRoles)
        {
            if (userRoles != null)
            {
                await _userRoleRepositary.DeleteAsync(userRoles);
                return true;
            }
            return false;
        }


        public async Task<bool> Update(UserRoles userRoles)
        {
            if (userRoles != null)
            {
                var employeeExists = await _userRoleRepositary.CheckEmployeeExistsAsync(userRoles.Emp_Code);
                if (!employeeExists)
                {
                    return false ;
                }

                var roleExists = await _userRoleRepositary.CheckRoleExistsAsync(userRoles.RoleId);
                if (!roleExists)
                {
                    return false;
                }
                await _userRoleRepositary.UpdateAsync(userRoles);
                return true;
            }
            
            return false;
        }


       
    }
}
