using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Interfaces
{
    public interface IAccountDetailsDALRepo
    {
        Task<IEnumerable<AccountDetails>> GetAllAccountDetailsAsync();

        Task<AccountDetails> GetAccountDetailsByidAsync(AccountDetails _accountDetails);
        Task<bool> CreateAccountDetails(AccountDetails _accountDetails);
        Task<bool> UpdateAccountDetails(AccountDetails _accountDetails);
        Task<bool> DeleteAccountDetails(AccountDetails accountDetails);
    }
}
