using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class EmployeeController : Controller
    {

        private APIServices _apiServices;
        public EmployeeController(APIServices apiService)
        {
            this._apiServices = apiService;
        }

        //GET: EmployeeController

        public async Task<IActionResult> Index()
        {
            TempData["message"] = "This is Employee Index";

            var Employees = await _apiServices.GetAllAsync<PaySlipManagement.Common.Models.Employee>("api/Employee/GetAllEmployees");
            return View(Employees);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.Id = model.Id;
                employee.Emp_Code = model.Emp_Code;
                employee.EmployeeName = model.EmployeeName;
                employee.DepartmentId = model.DepartmentId;
                employee.Designation = model.Designation;
                employee.Division = model.Division;
                employee.Email = model.Email;
                employee.PAN_Number = model.PAN_Number;
                employee.JoiningDate = model.JoiningDate;

                // Make a POST request to the Web API
                var response = await _apiServices.PostAsync("api/Employee/CreateEmployee", model);

                if (!string.IsNullOrEmpty(response) && response == "Employee Registered Successfully" || response == "true")
                {
                    TempData["message"] = response;
                    // Handle a successful Register
                    return RedirectToAction("Index");
                }
                else
                {

                    // Handle the case where the API request fails or register is unsuccessful
                    if (response != null)
                    {
                        ModelState.AddModelError(string.Empty, response);
                    }
                    ModelState.AddModelError(string.Empty, "API request failed or Create was unsuccessful");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Create attempt");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Employee>("api/Employee/GetEmployeeById/{id}");
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Make a POST request to the Web API
                var response = await _apiServices.PutAsync("/api/Employee/UpdateEmployee", model);

                if (!string.IsNullOrEmpty(response) && response == "Employee Updated Successfully" || response == "true")
                {
                    TempData["message"] = response;
                    // Handle a successful Updated
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle the case where the API request fails or register is unsuccessful
                    if (response != null)
                    {
                        ModelState.AddModelError(string.Empty, response);
                    }
                    ModelState.AddModelError(string.Empty, "API request failed or Update was unsuccessful");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Update attempt");
            return View("Update");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Employee>("api/Employee/GetEmployeeById/{id}");
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Employee>("api/Employee/GetEmployeeById/{id}");
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeViewModel model)
        {
            var response = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Employee>("/api/Employee/DeleteEmployee", new Employee() { Id = model.Id});
            if (!string.IsNullOrEmpty(response) && response == "true")
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where the API request fails or register is unsuccessful
                if (response != null)
                {
                    TempData["message"] = "Employee Deleted Successfully";
                    ModelState.AddModelError(string.Empty, response);
                }
                ModelState.AddModelError(string.Empty, "API request failed or register was unsuccessful");
            }
            ModelState.AddModelError(string.Empty, "Invalid register attempt");
            return View("Index");
        }
    }  
}




