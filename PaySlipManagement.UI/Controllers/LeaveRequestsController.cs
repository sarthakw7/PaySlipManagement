using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NPOI.SS.Formula.Functions;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;
using System.Threading.Tasks;

namespace PaySlipManagement.UI.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private APIServices _apiServices;
        private readonly ApiSettings _apiSettings;
        public LeaveRequestsController(APIServices apiServices, IOptions<ApiSettings> apiSettings)
        {
            _apiServices = apiServices;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            var leaveRequests = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.LeaveRequestsViewModel>($"{_apiSettings.LeaveRequestsEndpoint}/GetAllLeaveRequests");
            return View(leaveRequests);
        }

        public async Task<IActionResult> Index1(string Emp_Code)
        {
            var empCode = Request.Cookies["empCode"];
            Emp_Code = empCode;
            var leaveRequests = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.LeaveRequestsViewModel>($"{_apiSettings.LeaveRequestsEndpoint}/GetLeaveRequestsByEmpCode/{Emp_Code}");
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
                var response = await _apiServices.PostAsync<LeaveRequests>($"{_apiSettings.LeaveRequestsEndpoint}/CreateLeaveRequests", leaveRequests);
                if (response != null && response == "true")
                {
                    return RedirectToAction("Index");
                }
                return View(leaveRequests);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> ApproveRequest(int id)
        {
            var currentManagerCode = Request.Cookies["empCode"]; // Get the logged-in manager's Emp_Code

            var response = await _apiServices.GetAsync<LeaveRequestsViewModel>($"{_apiSettings.LeaveRequestsEndpoint}/GetLeaveRequestsByid/{id}");
            if (response != null)
            {
                var model = response;

                // Check if the current user is the manager responsible for approving the request
                if (model.ApprovalPerson == currentManagerCode && model.Status == "Pending")
                {
                    model.Status = "Approved";
                    var count = 0;
                    if (model.FromDate != null && model.ToDate != null)
                    {
                        count = (model.ToDate - model.FromDate).Value.Days + 1;
                    }
                    model.LeavesCount = count;

                    await _apiServices.PutAsync($"{_apiSettings.LeaveRequestsEndpoint}/UpdateLeaveRequests", model);
                    return Json(new { success = true, message = "Request approved successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "You are not authorized to approve this request." });
                }
            }
            return Json(new { success = false, message = "An error occurred while approving the request." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelRequest(int id)
        {
            var currentManagerCode = Request.Cookies["empCode"]; // Get the logged-in manager's Emp_Code

            var response = await _apiServices.GetAsync<LeaveRequestsViewModel>($"{_apiSettings.LeaveRequestsEndpoint}/GetLeaveRequestsByid/{id}");
            if (response != null)
            {
                var model = response;

                // Ensure the manager is authorized to cancel the request
                if (model.ApprovalPerson == currentManagerCode && model.Status == "Pending")
                {
                    model.Status = "Declined";
                    await _apiServices.PutAsync($"{_apiSettings.LeaveRequestsEndpoint}/UpdateLeaveRequests", model);
                    return Json(new { success = true, message = "Request canceled successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "You are not authorized to cancel this request." });
                }
            }
            return Json(new { success = false, message = "An error occurred while canceling the request." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyLeave(LeaveRequests leaveRequests)
        {
            try
            {
                var empCode = Request.Cookies["empCode"];
                leaveRequests.Emp_Code = empCode;

                // Retrieve the employee details to find their manager
                var employee = await _apiServices.GetAsync<Employee>($"{_apiSettings.EmployeeEndpoint}/GetEmployeeManagerByCodeAsync/{empCode}");

                if (employee != null)
                {
                    leaveRequests.ApprovalPerson = employee.ManagerCode;

                    leaveRequests.Status = "Pending";
                    var count = 0;
                    if (leaveRequests.FromDate != null && leaveRequests.ToDate != null)
                    {
                        count = (leaveRequests.ToDate - leaveRequests.FromDate).Value.Days + 1;
                    }
                    leaveRequests.LeavesCount = count;

                    var response = await _apiServices.PostAsync<LeaveRequests>($"{_apiSettings.LeaveRequestsEndpoint}/CreateLeaveRequests", leaveRequests);

                    // Check if the response was successful
                    if (!string.IsNullOrEmpty(response))
                    {
                        return RedirectToAction("Index1");
                    }
                    else
                    {
                        // Handle the case where the API response is empty or failed
                        ModelState.AddModelError("", "Failed to submit leave request.");
                    }
                }
                else
                {
                    // Handle case where employee is null
                    ModelState.AddModelError("", "Employee not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception and add a model error
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }

            // Return the view with errors if any issues occur
            return View(Index1);
        }



    }
}
