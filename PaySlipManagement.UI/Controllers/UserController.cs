using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly APIServices _apiService;
        private readonly string baseUrl = "api/Users";
        public UserController(APIServices apiService)
        {
            _apiService = apiService;
        }
        // GET: UserController
        public async Task<IActionResult> Index()
        {
            ViewData["ToastMessage"] = "Retrieved all Users.";
            var data = await _apiService.GetAllAsync<UsersViewModel>($"{baseUrl}/GetAllUsers");
            return View(data);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _apiService.GetAsync<UsersViewModel>($"{baseUrl}/GetByIdUser/{id}");
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // GET: UserController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersViewModel user)
        {
            if (ModelState.IsValid)
            {
                Users u = new Users();
                u.Id = user.Id;
                u.Emp_Code = user.Emp_Code;
                u.Password = user.Password;
                u.Email = user.Email;
                //u.Role = user.Role;
                var data = await _apiService.PostAsync<Users, bool>($"{baseUrl}/RegisterUser", u);
                if (data)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _apiService.GetAsync<UsersViewModel>($"{baseUrl}/GetByIdUser/{id}");
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsersViewModel user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Users u = new Users();
                u.Id = user.Id;
                u.Emp_Code = user.Emp_Code;
                u.Password = user.Password;
                u.Email = user.Email;
                //u.Role = user.Role;
                var existinguser= await _apiService.PutAsync<Users>($"{baseUrl}/UpdateUser", u);
                if (existinguser == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var users = await _apiService.GetAsync<UsersViewModel>($"{baseUrl}/GetByIdUser/{id}");
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: UsersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserConfirmed(int id)
        {
            var users = await _apiService.GetAsync<bool>($"{baseUrl}/DeleteUser/{id}");
            if (users == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
