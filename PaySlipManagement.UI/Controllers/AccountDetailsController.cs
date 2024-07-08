using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;
using PaySlipManagement.Common.Models;


namespace PaySlipManagement.UI.Controllers
{
    public class AccountDetailsController : Controller
    {
        private APIServices _apiServices;
        public AccountDetailsController(APIServices apiServices)
        {
            this._apiServices = apiServices;
        }

        public async Task<IActionResult> Index()
        {
            var AccountDetails = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.AccountDetailsViewModel>("api/AccountDetails/GetAllAccountDetails");
            return View(AccountDetails);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiServices.GetAsync<AccountDetailsViewModel>($"api/AccountDetails/GetAccountDetailsById/{id}");
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountDetails account)
        {
            if (ModelState.IsValid)
            {
                //AccountDetails accountDetails = new AccountDetails();
                //accountDetails.Id = account.Id;
                //accountDetails.Emp_Code = account.Emp_Code;
                //accountDetails.BankName = account.BankName;
                //accountDetails.BankAccountNumber = account.BankAccountNumber;
                //accountDetails.UANNumber = account.UANNumber;
                //accountDetails.PFAccountNumber = account.PFAccountNumber;
                AccountDetailsViewModel a = new AccountDetailsViewModel();
                a.Id = account.Id;
                a.Emp_Code = account.Emp_Code;
                a.BankName = account.BankName;
                a.BankAccountNumber = account.BankAccountNumber;
                a.UANNumber = account.UANNumber;
                a.PFAccountNumber = account.PFAccountNumber; var response = await _apiServices.PostAsync<AccountDetails>("api/AccountDetails/CreateAccountDetails", account);
                if (response != null&&response=="true")
                {
                    return RedirectToAction("Index");
                }
                return View(a);
            }
            return View(account);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiServices.GetAsync<AccountDetailsViewModel>($"api/AccountDetails/GetAccountDetailsById/{id}");
            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountDetails model)
        {
            if (ModelState.IsValid)
            {
                await _apiServices.PutAsync("api/AccountDetails/UpdateAccountDetails", model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiServices.GetAsync<AccountDetailsViewModel>($"api/AccountDetails/GetAccountDetailsById/{id}");
            return View(response);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _apiServices.GetAsync<bool>($"api/AccountDetails/DeleteAccountDetails/{id}");
            if (response == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Delete");
        }
    }
}
