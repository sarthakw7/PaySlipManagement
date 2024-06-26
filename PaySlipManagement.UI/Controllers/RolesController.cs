using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class RolesController : Controller
    {
        private readonly APIServices _apiServices;

        public RolesController(APIServices apiServices)
        {
            _apiServices = apiServices;
        }


       // GET: Roles
        public async Task<IActionResult> Index()
        {
            TempData["message"] = "This is Role Index";

            var roles = await _apiServices.GetAllAsync<PaySlipManagement.Common.Models.Roles>("/api/Roles/GetAllAsyncRoles");

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

                var response = await _apiServices.PostAsync("/api/Roles/CreateRoles", roles);
                if (!string.IsNullOrEmpty(response) && response == "Role Registred Successfull" || response == "true")
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
            var data = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Roles>("/api/Roles/GetByIdAsyncRoles", new Roles() { Id = id, Role = string.Empty });
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
                var response = await _apiServices.PutAsync("/api/Roles/UpdateRoles", role);

                if (!string.IsNullOrEmpty(response) && response == "Role is Updated Successfull" || response == "true")
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
            var data = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Roles, PaySlipManagement.Common.Models.Roles>("api/Roles/GetByIdAsyncRoles", new Roles() { Id = Id, Role = string.Empty });
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Roles, PaySlipManagement.Common.Models.Roles>("/api/Roles/GetByIdAsyncRoles", new Roles() { Id = Id, Role = string.Empty });
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RolesViewModel role)
        {
            var response = await _apiServices.PostAsync<PaySlipManagement.Common.Models.Roles>("/api/Roles/DeleteRoles", new Roles() { Id = role.Id, Role = "string" });
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
   

