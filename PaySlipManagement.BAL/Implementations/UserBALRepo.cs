using PayslipManagement.Common.Models;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Implementations
{
    public class UserBALRepo : IUserBALRepo
    {
        private UserDALRepo _userDALRepo;
        
        public UserBALRepo()
        {
            _userDALRepo = new UserDALRepo();
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _userDALRepo.GetAllAsync();  
        }

        public async Task<Users> GetByIdAsync(Users user)
        {
           return await _userDALRepo.GetByIdAsync(user);
        }

        public async Task<bool> Create(Users _user)
        {
            return await _userDALRepo.Create(_user);
        }

        public async Task<bool> Delete(Users _user)
        {
            return await _userDALRepo.Delete(_user);
        }

        public async Task<bool> Update(Users _user)
        {
            return await _userDALRepo.Update(_user);
        }

        public async Task<Users> UserValidateUserCredentials(Users user)
        {
            return await _userDALRepo.UserValidateUserCredentials(user);    
        }

    }
}
