using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.Implementations;


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

        public async Task<User> UserValidateUserCredentials(User user)
        {
            return await _userDALRepo.UserValidateUserCredentials(user);    
        }
    }
}
