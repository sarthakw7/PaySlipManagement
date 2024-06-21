using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PaySlipManagement.Common.Models;
using PaySlipManagement.BAL.Interfaces;


namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly IAccountDetailsBALRepo _accountdetailsBALRepo;
        public AccountDetailsController(IAccountDetailsBALRepo _accdetailsBALRepo)
        {
            _accountdetailsBALRepo = _accdetailsBALRepo;
        }
        [HttpGet("GetAllAccountDetails")]
        public async Task<IEnumerable<AccountDetails>> GetAllAccountDetailsAsync()
        {
            return await _accountdetailsBALRepo.GetAllAccountDetailsAsync();
        }
        [HttpPost("GetAccountDetailsById")]
        public async Task<AccountDetails> GetAccountDetailsByidAsync(AccountDetails _accountDetails)
        {
            return await _accountdetailsBALRepo.GetAccountDetailsByidAsync(_accountDetails);
        }
        [HttpPost("CreateAccountDetails")]
        public async Task<bool> CreateAccountDetails(AccountDetails _accountDetails)
        {
            return await _accountdetailsBALRepo.CreateAccountDetails(_accountDetails);

        }
        [HttpPut("UpdateAccountDetails")]
        public async Task<bool> UpdateAccountDetails(AccountDetails _accountDetails)
        {
            return await _accountdetailsBALRepo.UpdateAccountDetails(_accountDetails);

        }
        [HttpPost("DeleteAccountDetails")]
        public async Task<bool> DeleteAccountDetails(AccountDetails accountDetails)
        {
            return await _accountdetailsBALRepo.DeleteAccountDetails(accountDetails);
        }
    }
}
