using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class LeavesController : Controller
    {
        private APIServices _apiServices;
        private readonly ApiSettings _apiSettings;
        public LeavesController(APIServices apiServices, IOptions<ApiSettings> apiSettings)
        {
            this._apiServices = apiServices;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            var leaves = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.LeavesViewModel>($"{_apiSettings.LeavesEndpoint}/GetAllLeaves");
            return View(leaves);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiServices.GetAsync<LeavesViewModel>($"{_apiSettings.LeavesEndpoint}/GetLeavesByid/{id}");
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Leaves leaves)
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
                LeavesViewModel l = new LeavesViewModel();
                l.Id = leaves.Id;
                l.Emp_Code = leaves.Emp_Code;
                l.TypeId = leaves.TypeId;
                l.TotalLeaves = leaves.TotalLeaves;
                l.LeavesAvailable = leaves.LeavesAvailable;
                l.LeavesUsed = leaves.LeavesUsed;
                var response = await _apiServices.PostAsync<Leaves>($"{_apiSettings.LeavesEndpoint}/CreateLeaves", leaves);
                if (response != null && response == "true")
                {
                    return RedirectToAction("Index");
                }
                return View(l);
            }
            return View(leaves);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiServices.GetAsync<LeavesViewModel>($"{_apiSettings.LeavesEndpoint}/GetLeavesByid/{id}");
            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Leaves model)
        {
            if (ModelState.IsValid)
            {
                await _apiServices.PutAsync($"{_apiSettings.LeavesEndpoint}/UpdateLeaves", model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiServices.GetAsync<LeavesViewModel>($"{_apiSettings.LeavesEndpoint}/GetLeavesByidAsync/{id}");
            return View(response);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _apiServices.GetAsync<bool>($"{_apiSettings.LeavesEndpoint}/DeleteLeaves/{id}");
            if (response == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Delete");
        }


        // fetches the leave balance and initializes it into the model before returning it to the view

        [HttpGet]
        public async Task<IActionResult> LeaveRequestForm(string empCode)
        {
            var leaveRequestModel = new LeaveRequestsViewModel
            {
                Emp_Code = empCode
            };


            var response = await _apiServices.GetAsync<LeavesViewModel>($"{_apiSettings.LeavesEndpoint}/GetLeaveBalance/{empCode}");
            if (response != null)
            {
                leaveRequestModel.LeaveBalance = response.LeavesAvailable;
            }

            // Pass the model to the view
            return View(leaveRequestModel);
        }


        [HttpPost, ActionName("Submit")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SubmitLeaveRequest(LeaveRequestsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // fetch current leave balance for the employee
                var response = await _apiServices.GetAsync<LeavesViewModel>($"{_apiSettings.LeavesEndpoint}/GetLeaveBalance/{model.Emp_Code}/{model.LeaveType}");
                if (response != null)
                {
                    var availableLeaveBalance = response.LeavesAvailable;
                    //Calculate total number of days requested
                    var totalLeaveDays = 0;
                    if (model.FromDate != null && model.ToDate != null)
                    {
                        totalLeaveDays = (model.ToDate - model.FromDate).Value.Days + 1;
                    }

                    if (totalLeaveDays > availableLeaveBalance)
                    {
                        model.LeaveBalance = availableLeaveBalance;
                        return Json(new { success = false, message = "Insufficient leave balance." });
                    }



                    model.Status = "Pending";
                    model.LeavesCount = totalLeaveDays;
                    model.LeaveBalance = availableLeaveBalance - totalLeaveDays;

                    var submitResponse = await _apiServices.PostAsync($"{_apiSettings.LeaveRequestsEndpoint}/SubmitLeaveRequest", model);
                    if (!string.IsNullOrEmpty(submitResponse))
                    {
                        return Json(new { success = true, message = "Leave request submitted successfully!" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "An error occurred while submitting the leave request." });
                    }
                }
            }
            return Json(new { success = false, message = "An error occurred while submitting the leave request." });
        }

        



    }
}
