using PaySlipManagement.Common.Models;


 namespace PaySlipManagement.DAL.Interfaces
 {
    public  interface IUserDALRepo
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(Users user);
        Task<bool> Create(Users user);
        Task<bool> Update(Users user);
        Task<bool> Delete(Users user);
        Task<User> UserValidateUserCredentials(User user);
    }
}
