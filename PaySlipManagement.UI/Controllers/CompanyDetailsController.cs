using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class CompanyDetailsController : Controller
    {
        private APIServices _apiServices;
        public CompanyDetailsController(APIServices apiServices)
        {
            this._apiServices = apiServices;
        }

        public async Task<IActionResult> Index()
        {
            var companyDetails = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.CompanyDetailsViewModel>("api/CompanyDetails/GetAllCompanyDetails");
            return View(companyDetails);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiServices.GetAsync<CompanyDetailsViewModel>($"api/CompanyDetails/GetCompanyDetailsById/{id}");
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

                var response = await _apiServices.PostAsync<CompanyDetails>("api/CompanyDetails/CreateCompanyDetails", details);
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
            var response = await _apiServices.GetAsync<CompanyDetailsViewModel>($"api/CompanyDetails/GetCompanyDetailsById/{id}");
            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyDetails details)
        {
            if (ModelState.IsValid)
            {
                await _apiServices.PutAsync("api/CompanyDetails/UpdateCompanyDetails", details);
                return RedirectToAction(nameof(Index));
            }
            return View(details);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _apiServices.GetAsync<CompanyDetailsViewModel>($"api/CompanyDetails/GetCompanyDetailsById/{id}");
            return View(data);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _apiServices.GetAsync<bool>($"api/CompanyDetails/DeleteCompanyDetails/{id}");
            if (data == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Delete");
        }
    }
}
