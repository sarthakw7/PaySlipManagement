using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly APIServices _apiService;
        private readonly ApiSettings _apiSettings;
        public DepartmentController(APIServices apiService, ApiSettings apiSettings)
        {
            _apiService = apiService;
            _apiSettings = apiSettings;
        }
        // GET: DepartmentController
        public async Task<IActionResult> Index()
        {
            ViewData["ToastMessage"] = "Retrieved all Departments.";
            var data = await _apiService.GetAllAsync<DepartmentViewModel>($"{_apiSettings.DepartmentEndpoint}/GetAllDepartments");
            return View(data);
        }

        // GET: DepartmentController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _apiService.GetAsync<DepartmentViewModel>($"{_apiSettings.DepartmentEndpoint}/GetDepartmentById/{id}");
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // GET: DepartmentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                Department d = new Department();
                d.Id=department.Id;
                d.DepartmentName=department.DepartmentName;
                var data = await _apiService.PostAsync<Department,bool>($"{_apiSettings.DepartmentEndpoint}/CreateDepartment",d);
                if (data)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }

        // GET: DepartmentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _apiService.GetAsync<DepartmentViewModel>($"{_apiSettings.DepartmentEndpoint}/GetDepartmentById/{id}");
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentViewModel department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Department d = new Department();
                d.Id = department.Id;
                d.DepartmentName = department.DepartmentName;
                var existingDepartment = await _apiService.PutAsync<Department>($"{_apiSettings.DepartmentEndpoint}/UpdateDepartment", d); 
                if (existingDepartment == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: DepartmentController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _apiService.GetAsync<DepartmentViewModel>($"{_apiSettings.DepartmentEndpoint}/GetDepartmentById/{id}");
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _apiService.GetAsync<bool>($"{_apiSettings.DepartmentEndpoint}/DeleteDepartment/{id}");
            if (department == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
