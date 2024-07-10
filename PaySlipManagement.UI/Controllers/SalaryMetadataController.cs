using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class SalaryMetadataController : Controller
    {
        private readonly APIServices _apiService;
        private readonly ApiSettings _apiSettings;
        public SalaryMetadataController(APIServices apiService, IOptions<ApiSettings> apiSettings)
        {
            _apiService = apiService;
            _apiSettings = apiSettings.Value;
        }
        // GET: SalaryMetadata
        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAllAsync<SalaryMetadata>($"{_apiSettings.SalaryEndpoint}/GetAllSalaryMetadata");
            return View(response);
        }
        // GET: SalaryMetadata/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiService.GetAsync<SalaryMetadataViewModel>($"{_apiSettings.SalaryEndpoint}/GetSalaryMetadataById/{id}");
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
                await _apiService.PostAsync($"{_apiSettings.SalaryEndpoint}/CreateSalaryMetadata", model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        // GET: SalaryMetadata/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiService.GetAsync<SalaryMetadataViewModel>($"{_apiSettings.SalaryEndpoint}/GetSalaryMetadataById/{id}");
            return View(response);
        }

        // POST: SalaryMetadata/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SalaryMetadata model)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PutAsync($"{_apiSettings.SalaryEndpoint}/UpdateSalaryMetadata", model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: SalaryMetadata/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.GetAsync<SalaryMetadataViewModel>($"{_apiSettings.SalaryEndpoint}/GetSalaryMetadataById/{id}");
            return View(response);
        }

        // POST: SalaryMetadata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _apiService.GetAsync<bool>($"{_apiSettings.SalaryEndpoint}/DeleteSalaryMetadata/{id}");
            if (data==true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Delete");
        }
    }
}
