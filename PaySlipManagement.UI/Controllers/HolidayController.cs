using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class HolidayController : Controller
    {
        private readonly APIServices _apiServices;
        private readonly ApiSettings _apiSettings;
        public HolidayController(APIServices apiServices, IOptions<ApiSettings> apiSettings)
        {
            _apiServices = apiServices;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            // Fetch the latest holiday image
            var holidayImage = await _apiServices.GetAsync<HolidayImageViewModel>($"{_apiSettings.HolidayEndpoint}/GetHolidayImageByIdAsync");

            // Fetch the latest holiday PDF
            var holidayPdf = await _apiServices.GetAsync<HolidayPdfViewModel>($"{_apiSettings.HolidayEndpoint}/GetHolidayPdfByIdAsync");

            // Create a view model to pass both holiday image and PDF data to the view
            var viewModel = new HolidayImagePDFViewModel
            {
                HolidayImage = holidayImage,
                HolidayPdf = holidayPdf
            };

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var image = new HolidayImage
                    {
                        Id = 0,
                        ImageName = file.FileName,
                        ContentType = file.ContentType
                    };

                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        image.ImageData = stream.ToArray();
                    }
                    var response = await _apiServices.PostAsync($"{_apiSettings.HolidayEndpoint}/CreateHolidayPdfAsync", image);
                    if (!string.IsNullOrEmpty(response) && response == "Role Registered Successfully" || response == "true")
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        //Handle the case where the API request fails or register is unsuccessful
                        if (response != null)
                        {
                            ModelState.AddModelError(string.Empty, response);
                        }
                        ModelState.AddModelError(string.Empty, "API request failed or Create was unsuccessful");
                    }
                }
            }
            //return View(model);

            ModelState.AddModelError(string.Empty, "Invalid Create attempt");
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var image = new HolidayPdf
                    {
                        Id = 0,
                        FileName = file.FileName,
                        ContentType = file.ContentType
                    };

                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        image.Data = stream.ToArray();
                    }
                    var response = await _apiServices.PostAsync($"{_apiSettings.HolidayEndpoint}/CreateHolidayPdfAsync", image);
                    if (!string.IsNullOrEmpty(response) && response == "Role Registered Successfully" || response == "true")
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        //Handle the case where the API request fails or register is unsuccessful
                        if (response != null)
                        {
                            ModelState.AddModelError(string.Empty, response);
                        }
                        ModelState.AddModelError(string.Empty, "API request failed or Create was unsuccessful");
                    }
                }
            }
            //return View(model);

            ModelState.AddModelError(string.Empty, "Invalid Create attempt");
            return View("Create");
        }
    }
}
