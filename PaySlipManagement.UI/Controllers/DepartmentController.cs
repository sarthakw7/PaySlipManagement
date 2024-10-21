using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly APIServices _apiService;
        private readonly ApiSettings _apiSettings;
        public DepartmentController(APIServices apiService, IOptions<ApiSettings> apiSettings)
        {
            _apiService = apiService;
            _apiSettings = apiSettings.Value;
        }
        // GET: DepartmentController
        public async Task<IActionResult> Index(int page = 1, int pageSize = 8)
        {
            // Fetch all department data
            var data = await _apiService.GetAllAsync<DepartmentViewModel>($"{_apiSettings.DepartmentEndpoint}/GetAllDepartments");

            // Calculate total number of items
            int totalItems = data.Count();

            // Calculate total number of pages
            int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);

            // Ensure current page is within bounds
            int currentPage = page > totalPages ? totalPages : page;
            currentPage = currentPage < 1 ? 1 : currentPage;

            // Calculate the number of items to skip
            int skipItems = (currentPage - 1) * pageSize;

            // Get the paginated department data for the current page
            var pagedDepartments = data.Skip(skipItems).Take(pageSize).ToList();

            // Pass pagination data to the view using ViewBag
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;

            // ViewData for toast message
            ViewData["ToastMessage"] = "Retrieved all Departments.";

            // Return the paginated data to the view
            return View(pagedDepartments);
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
