using PayslipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Interfaces
{
    public  interface IUserBALRepo
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(Users user);
        Task<bool> Create(Users _user);
        Task<bool> Update(Users _user);
        Task<bool> Delete(Users _user);
        //bool ValidateUserCredentials(string username, string password);
        Task<Users> UserValidateUserCredentials(Users user);
    }
}
