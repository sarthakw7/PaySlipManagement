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
            TempData["message"] = "This is Department Index";

            var Departments = await _apiServices.GetAllAsync<PaySlipManagement.Common.Models.Employee>("api/Department/GetAllDepartments");
            return View(Departments);
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
                var response = await _apiServices.PostAsync("api/Department/CreateDepartment", model);

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
        public async Task<IActionResult> Update(int Id)
        {
            var data = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Employee, PaySlipManagement.Common.Models.Employee>("api/Department/GetDepartmentById", new Employee() { Id = Id, Emp_Code = string.Empty, EmployeeName = string.Empty, DepartmentId =Id, Designation = string.Empty, Division = string.Empty, Email = string.Empty, PAN_Number = string.Empty, JoiningDate = string.Empty });
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Make a POST request to the Web API
                var response = await _apiServices.PutAsync("/api/Department/UpdateDepartment", model);

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
        public async Task<IActionResult> Details(int Id)
        {
            var data = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Employee, PaySlipManagement.Common.Models.Employee>("api/Department/GetDepartmentById", new Employee() { Id = Id, Emp_Code = string.Empty, EmployeeName = string.Empty, /*DepartmentId =,*/ Designation = string.Empty, Division = string.Empty, Email = string.Empty, PAN_Number = string.Empty, JoiningDate = string.Empty });
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Employee, PaySlipManagement.Common.Models.Employee>("api/Department/GetDepartmentById", new Employee() { Id = Id, Emp_Code = string.Empty, EmployeeName = string.Empty, /*DepartmentId =,*/ Designation = string.Empty, Division = string.Empty, Email = string.Empty, PAN_Number = string.Empty, JoiningDate = string.Empty });
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeController model)
        {
            var response = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Employee>("/api/Department/DeleteDepartment", new Employee() { Id = Id, Emp_Code = string.Empty, EmployeeName = string.Empty, /*DepartmentId =,*/ Designation = string.Empty, Division = string.Empty, Email = string.Empty, PAN_Number = string.Empty, JoiningDate = string.Empty });
            if (!string.IsNullOrEmpty(response) && response == "true")
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where the API request fails or register is unsuccessful
                if (response != null)
                {
                    TempData["message"] = "Department Deleted Successfully";
                    ModelState.AddModelError(string.Empty, response);
                }
                ModelState.AddModelError(string.Empty, "API request failed or register was unsuccessful");
            }
            ModelState.AddModelError(string.Empty, "Invalid register attempt");
            return View("Index");
        }
    }  
}




