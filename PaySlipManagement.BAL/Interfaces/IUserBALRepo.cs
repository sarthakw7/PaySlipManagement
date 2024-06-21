using PaySlipManagement.Common.Models;


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
