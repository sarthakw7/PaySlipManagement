using PaySlipManagement.Common.Models;

namespace PaySlipManagement.BAL.Interfaces
{
    public interface IAccountDetailsBALRepo
    {
        Task<IEnumerable<AccountDetails>> GetAllAccountDetailsAsync();

        Task<AccountDetails> GetAccountDetailsByidAsync(AccountDetails _accountDetails);
        Task<bool> CreateAccountDetails(AccountDetails _accountDetails);
        Task<bool> UpdateAccountDetails(AccountDetails _accountDetails);
        Task<bool> DeleteAccountDetails(AccountDetails accountDetails);
    }
}
