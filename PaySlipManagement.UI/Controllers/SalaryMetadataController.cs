using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class SalaryMetadataController : Controller
    {
        private readonly APIServices _apiService;
        private readonly string baseUrl = "api/Salary";
        public SalaryMetadataController(APIServices apiService)
        {
            _apiService = apiService;
        }
        // GET: SalaryMetadata
        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAllAsync<SalaryMetadata>($"{baseUrl}/GetAllSalaryMetadata");
            return View(response);
        }
        // GET: SalaryMetadata/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiService.GetAsync<SalaryMetadataViewModel>($"{baseUrl}/GetSalaryMetadataById/{id}");
            return View(response);
        }
        // GET: SalaryMetadata/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalaryMetadata/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalaryMetadataViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync($"{baseUrl}/CreateSalaryMetadata", model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        // GET: SalaryMetadata/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiService.GetAsync<SalaryMetadataViewModel>($"{baseUrl}/GetSalaryMetadataById/{id}");
            return View(response);
        }

        // POST: SalaryMetadata/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SalaryMetadata model)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PutAsync($"{baseUrl}/UpdateSalaryMetadata", model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: SalaryMetadata/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.GetAsync<SalaryMetadataViewModel>($"{baseUrl}/GetSalaryMetadataById/{id}");
            return View(response);
        }

        // POST: SalaryMetadata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _apiService.GetAsync<bool>($"{baseUrl}/DeleteSalaryMetadata/{id}");
            if (data==true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Delete");
        }
    }
}
