using PaySlipManagement.DAL.DapperServices.Implementations;
using PaySlipManagement.DAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.DAL.Implementations
{
    public class AccountDetailsDALRepo: IAccountDetailsDALRepo
    {

        DapperServices<AccountDetails> accountDetailsRepository;
        public AccountDetailsDALRepo()
        {
            accountDetailsRepository = new DapperServices<AccountDetails>();
        }


        public async Task<IEnumerable<AccountDetails>> GetAllAccountDetailsAsync()
        {
            try
            {
                var result = await accountDetailsRepository.ReadAllAsync(new AccountDetails() { Id = null });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<AccountDetails> GetAccountDetailsByidAsync(AccountDetails _accountDetails)
        {
            try
            {
                return await accountDetailsRepository.ReadGetByIdAsync(_accountDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> CreateAccountDetails(AccountDetails _accountDetails)
        {
            try
            {

                if (_accountDetails != null)
                {
                    await accountDetailsRepository.CreateAsync(_accountDetails);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateAccountDetails(AccountDetails _accountDetails)
        {
            try
            {
                if (_accountDetails != null)
                {
                    await accountDetailsRepository.UpdateAsync(_accountDetails);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> DeleteAccountDetails(AccountDetails accountDetails)
        {
            try
            {
                if (accountDetails != null)
                {
                    await accountDetailsRepository.DeleteAsync(accountDetails);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
