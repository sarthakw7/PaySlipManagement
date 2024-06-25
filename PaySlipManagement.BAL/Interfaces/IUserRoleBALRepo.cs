﻿using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Interfaces
{
    public interface IUserRoleBALRepo
    {
        Task<IEnumerable<UserRoles>> GetAllAsync();
        Task<UserRoles> GetByIdAsync(UserRoles userRoles);
        Task<bool> Create(UserRoles userRoles);
        Task<bool> Update(UserRoles userRoles);
        Task<bool> Delete(UserRoles userRoles);
    }
}
