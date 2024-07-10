using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class RolesController : Controller
    {
        private readonly APIServices _apiServices;
        private readonly ApiSettings _apiSettings;
        public RolesController(APIServices apiServices, IOptions<ApiSettings> apiSettings)
        {
            _apiServices = apiServices;
            _apiSettings = apiSettings.Value;
        }


        // GET: Roles
        public async Task<IActionResult> Index()
        {
            TempData["message"] = "This is Role Index";

            var roles = await _apiServices.GetAllAsync<PaySlipManagement.UI.Models.RolesViewModel>($"{_apiSettings.RolesEndpoint}/GetAllAsyncRoles");

            return View(roles);
        }

        // GET: Roles/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesViewModel role)
        {
            if (ModelState.IsValid)
            {
                Roles roles = new Roles();
                roles.Id = role.Id;
                roles.Role = role.Role;

                var response = await _apiServices.PostAsync($"{_apiSettings.RolesEndpoint}/CreateRoles", role);
                if (!string.IsNullOrEmpty(response) && response == "Role Registered Successfully" || response == "true")
                {
                    TempData["Message"] = response;

                    return RedirectToAction("Index");
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
            ModelState.AddModelError(string.Empty, "Invalid Create attempt");
            return View();
        }

       
        // GET: Roles/Edit/5
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Roles>($"{_apiSettings.RolesEndpoint}/GetByIdAsyncRoles/{id}");
            return View(data);

        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolesViewModel role)
        {
            if (ModelState.IsValid)
            {
                // Make a POST request to the Web API
                var response = await _apiServices.PutAsync($"{_apiSettings.RolesEndpoint}/UpdateRoles", role);

                if (!string.IsNullOrEmpty(response) && response == "Role is Updated Successfully" || response == "true")
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
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Roles>($"{_apiSettings.RolesEndpoint}/GetByIdAsyncRoles/{id}");
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _apiServices.GetAsync<PaySlipManagement.Common.Models.Roles>($"{_apiSettings.RolesEndpoint}/GetByIdAsyncRoles/{id}");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RolesViewModel role)
        {
            var response = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Roles>($"{_apiSettings.RolesEndpoint}/DeleteRoles", new Roles() { Id = role.Id});
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
   

