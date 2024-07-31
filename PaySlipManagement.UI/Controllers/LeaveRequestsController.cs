using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private APIServices _apiServices;
        private readonly ApiSettings _apiSettings;
        public LeaveRequestsController(APIServices apiServices, IOptions<ApiSettings> apiSettings)
        {
            this._apiServices = apiServices;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            var leaveRequests = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.LeaveRequestsViewModel>($"{_apiSettings.LeaveRequestsEndpoint}/GetAllLeaveRequests");
            return View(leaveRequests);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiServices.GetAsync<LeaveRequestsViewModel>($"{_apiSettings.LeaveRequestsEndpoint}/GetLeaveRequestsByid/{id}");
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequests leaveRequests)
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
                LeaveRequestsViewModel lr = new LeaveRequestsViewModel();
                lr.Id = leaveRequests.Id;
                lr.Emp_Code = leaveRequests.Emp_Code;
                lr.LeaveType = leaveRequests.LeaveType;
                lr.Reason = leaveRequests.Reason;
                lr.FromDate = leaveRequests.FromDate;
                lr.ToDate = leaveRequests.ToDate;
                lr.LeavesCount = leaveRequests.LeavesCount;
                lr.ApprovalPerson = leaveRequests.ApprovalPerson;
                lr.Status = leaveRequests.Status;
                lr.LeaveBalance = leaveRequests.LeaveBalance;
                var response = await _apiServices.PostAsync<LeaveRequests>($"{_apiSettings.LeaveRequestsEndpoint}/CreateLeaveRequests", leaveRequests);
                if (response != null && response == "true")
                {
                    return RedirectToAction("Index");
                }
                return View(lr);
            }
            return View(leaveRequests);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiServices.GetAsync<LeaveRequestsViewModel>($"{_apiSettings.LeaveRequestsEndpoint}/GetLeaveRequestsByid/{id}");
            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveRequests model)
        {
            if (ModelState.IsValid)
            {
                await _apiServices.PutAsync($"{_apiSettings.LeaveRequestsEndpoint}/UpdateLeaveRequests", model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiServices.GetAsync<LeaveRequestsViewModel>($"{_apiSettings.LeaveRequestsEndpoint}/GetLeaveRequestsByid/{id}");
            return View(response);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _apiServices.GetAsync<bool>($"{_apiSettings.LeaveRequestsEndpoint}/DeleteLeaveRequests/{id}");
            if (response == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Delete");
        }
    }
}
