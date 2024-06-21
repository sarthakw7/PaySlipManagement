using PayslipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace PaySlipManagement.DAL.Interfaces
 {
    public  interface IUserDALRepo
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(Users user);
        Task<bool> Create(Users user);
        Task<bool> Update(Users user);
        Task<bool> Delete(Users user);
        Task<Users> UserValidateUserCredentials(Users user);


    }
}
