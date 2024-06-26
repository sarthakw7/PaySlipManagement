using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private APIServices _apiServices;
        public DepartmentController(APIServices apiService)
        {
            this._apiServices = apiService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["message"] = "This is Department Index";

            var Departments = await _apiServices.GetAllAsync<PaySlipManagement.Common.Models.Department>("api/Department/GetAllDepartments");
            return View(Departments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department();
                department.Id = model.DepartmentId;
                department.DepartmentName = model.DepartmentName;             

                // Make a POST request to the Web API
                var response = await _apiServices.PostAsync("api/Department/CreateDepartment", model);

                if (!string.IsNullOrEmpty(response) && response == "Department Registered Successfully" || response == "true")
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
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Department>("api/Department/GetDepartmentById/{id}");
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Make a POST request to the Web API
                var response = await _apiServices.PutAsync("/api/Department/UpdateDepartment", model);

                if (!string.IsNullOrEmpty(response) && response == "Department Updated Successfully" || response == "true")
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
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Department>("api/Department/GetDepartmentById/{id}");
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Department>("api/Department/GetDepartmentById/{id}");
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentViewModel model)
        {
            var response = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Department>("/api/Department/DeleteDepartment", new Department() { Id = model.DepartmentId });
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
