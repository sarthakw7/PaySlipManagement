using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class CompanyDetailsController : Controller
    {
        private APIServices _apiServices;
        private readonly ApiSettings _apiSettings;
        public CompanyDetailsController(APIServices apiServices, IOptions<ApiSettings> apiSettings)
        {
            this._apiServices = apiServices;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var companyDetails = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.CompanyDetailsViewModel>($"{_apiSettings.CompanyDetailsEndpoint}/GetAllCompanyDetails");
            return View(companyDetails);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiServices.GetAsync<CompanyDetailsViewModel>($"{_apiSettings.CompanyDetailsEndpoint}/GetCompanyDetailsById/{id}");
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyDetails details)
        {
            if (ModelState.IsValid)
            {
                CompanyDetails companyDetails = new CompanyDetails();
                companyDetails.Id = details.Id;
                companyDetails.CompanyName = details.CompanyName;
                companyDetails.CompanyAddress = details.CompanyAddress;
                companyDetails.Division = details.Division;

                var response = await _apiServices.PostAsync<CompanyDetails>($"{_apiSettings.CompanyDetailsEndpoint}/CreateCompanyDetails", details);
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(details);
            }
            return View(details);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiServices.GetAsync<CompanyDetailsViewModel>($"{_apiSettings.CompanyDetailsEndpoint}/GetCompanyDetailsById/{id}");
            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyDetails details)
        {
            if (ModelState.IsValid)
            {
                await _apiServices.PutAsync($"{_apiSettings.CompanyDetailsEndpoint}/UpdateCompanyDetails", details);
                return RedirectToAction(nameof(Index));
            }
            return View(details);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _apiServices.GetAsync<CompanyDetailsViewModel>($"{_apiSettings.CompanyDetailsEndpoint}/GetCompanyDetailsById/{id}");
            return View(data);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _apiServices.GetAsync<bool>($"{_apiSettings.CompanyDetailsEndpoint}/DeleteCompanyDetails/{id}");
            if (data == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Delete");
        }
    }
}
