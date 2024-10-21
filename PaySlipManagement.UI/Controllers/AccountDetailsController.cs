using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;
using PaySlipManagement.Common.Models;
using Microsoft.Extensions.Options;
using NuGet.Configuration;
using System.Linq;


namespace PaySlipManagement.UI.Controllers
{
    public class AccountDetailsController : Controller
    {
        private APIServices _apiServices;
        private readonly ApiSettings _apiSettings;
        public AccountDetailsController(APIServices apiServices, IOptions<ApiSettings> apiSettings)
        {
            this._apiServices = apiServices;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 8) // Default page is 1, and page size is 8
        {
            // Fetch all account details from the API
            var accountDetails = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.AccountDetailsViewModel>($"{_apiSettings.AccountDetailsEndpoint}/GetAllAccountDetails");

            // Implement pagination
            int totalItems = accountDetails.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize); // Calculate total pages
            int currentPage = page > totalPages ? totalPages : page; // Ensure currentPage doesn't exceed totalPages
            int skipItems = (currentPage - 1) * pageSize; // Calculate how many items to skip based on currentPage

            // Get the account details for the current page
            var pagedAccountDetails = accountDetails.Skip(skipItems).Take(pageSize).ToList();

            // Pass pagination details to ViewBag
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize; // Optional: use this in the view to control items per page

            return View(pagedAccountDetails); // Return the paginated list to the view
        }


        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiServices.GetAsync<AccountDetailsViewModel>($"{_apiSettings.AccountDetailsEndpoint}/GetAccountDetailsById/{id}");
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
                a.PFAccountNumber = account.PFAccountNumber; 
                var response = await _apiServices.PostAsync<AccountDetails>($"{_apiSettings.AccountDetailsEndpoint}/CreateAccountDetails", account);
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
            var response = await _apiServices.GetAsync<AccountDetailsViewModel>($"{_apiSettings.AccountDetailsEndpoint}/GetAccountDetailsById/{id}");
            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountDetails model)
        {
            if (ModelState.IsValid)
            {
                await _apiServices.PutAsync($"{_apiSettings.AccountDetailsEndpoint}/UpdateAccountDetails", model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiServices.GetAsync<AccountDetailsViewModel>($"{_apiSettings.AccountDetailsEndpoint}/GetAccountDetailsById/{id}");
            return View(response);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _apiServices.GetAsync<bool>($"{_apiSettings.AccountDetailsEndpoint}/DeleteAccountDetails/{id}");
            if (response == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Delete");
        }
    }
}
