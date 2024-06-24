using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class RolesController : Controller
    {
        private static List<Roles> _roles = new List<Roles>
        {
            new Roles { Id = 1, Role = "Admin" },
            new Roles { Id = 2, Role = "User" },
            // Add more roles as needed
        };

        // GET: Roles
        public IActionResult Index()
        {
            return View(_roles);
        }

        // GET: Roles/Details/5
        public IActionResult Details(int id)
        {
            var role = _roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Roles role)
        {
            if (ModelState.IsValid)
            {
                role.Id = _roles.Max(r => r.Id) + 1;
                _roles.Add(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(int id)
        {
            var role = _roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Roles role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingRole = _roles.FirstOrDefault(r => r.Id == id);
                if (existingRole == null)
                {
                    return NotFound();
                }

                existingRole.Role = role.Role;

                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public IActionResult Delete(int id)
        {
            var role = _roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var role = _roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            _roles.Remove(role);
            return RedirectToAction(nameof(Index));
        }
    }
}
