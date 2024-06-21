using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.DAL.Implementations;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.BAL.Implementations
{
    public class AccountDetailsBALRepo : IAccountDetailsBALRepo
    {
        public AccountDetailsDALRepo _accountDetailsDALRepo = new AccountDetailsDALRepo();
        //private readonly AccountDetailsDALRepo _accountDetailsDALRepo;
        //public AccountDetailsBALRepo() 
        //{
        //    _accountDetailsDALRepo = new AccountDetailsDALRepo();
        //}

        public async Task<IEnumerable<AccountDetails>> GetAllAccountDetailsAsync()
        {
            return await _accountDetailsDALRepo.GetAllAccountDetailsAsync();
        }

        public async Task<AccountDetails> GetAccountDetailsByidAsync(AccountDetails _accountDetails)
        {
            return await _accountDetailsDALRepo.GetAccountDetailsByidAsync(_accountDetails);
        }
        public async Task<bool> CreateAccountDetails(AccountDetails _accountDetails)
        {
            return await _accountDetailsDALRepo.CreateAccountDetails(_accountDetails);

        }
        public async Task<bool> UpdateAccountDetails(AccountDetails _accountDetails)
        {
            return await _accountDetailsDALRepo.UpdateAccountDetails(_accountDetails);

        }
        public async Task<bool> DeleteAccountDetails(AccountDetails accountDetails)
        {
            return await _accountDetailsDALRepo.DeleteAccountDetails(accountDetails);

        }
    }
}
