using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class AccountDetailsController : Controller
    {
        private static List<AccountDetailsViewModel> _accountDetails = new List<AccountDetailsViewModel>
        {
            new AccountDetailsViewModel { Id = 1, Emp_Code = "E001", BankName = "Bank A", BankAccountNumber = 1234567890, UANNumber = 9876543210, PFAccountNumber = "PF001" },
            // Add more account details as needed
        };

        public IActionResult Index()
        {
            return View(_accountDetails);
        }

        public IActionResult Details(int id)
        {
            var account = _accountDetails.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccountDetailsViewModel account)
        {
            if (ModelState.IsValid)
            {
                account.Id = _accountDetails.Max(a => a.Id) + 1 ?? 1;
                _accountDetails.Add(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public IActionResult Edit(int id)
        {
            var account = _accountDetails.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AccountDetailsViewModel account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingAccount = _accountDetails.FirstOrDefault(a => a.Id == id);
                if (existingAccount == null)
                {
                    return NotFound();
                }

                existingAccount.Emp_Code = account.Emp_Code;
                existingAccount.BankName = account.BankName;
                existingAccount.BankAccountNumber = account.BankAccountNumber;
                existingAccount.UANNumber = account.UANNumber;
                existingAccount.PFAccountNumber = account.PFAccountNumber;

                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public IActionResult Delete(int id)
        {
            var account = _accountDetails.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = _accountDetails.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            _accountDetails.Remove(account);
            return RedirectToAction(nameof(Index));
        }
    }
}
