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
        [HttpGet("GetAccountDetailsById/{id}")]
        public async Task<AccountDetails> GetAccountDetailsByidAsync(int id)
        {
            AccountDetails _accountDetails = new AccountDetails();
            _accountDetails.Id= id;
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
        [HttpGet("DeleteAccountDetails/{id}")]
        public async Task<bool> DeleteAccountDetails(int id)
        {
            AccountDetails accountDetails = new AccountDetails();
            accountDetails.Id= id;
            return await _accountdetailsBALRepo.DeleteAccountDetails(accountDetails);
        }
    }
}
