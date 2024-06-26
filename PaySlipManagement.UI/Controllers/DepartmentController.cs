using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private static List<DepartmentViewModel> _departments = new List<DepartmentViewModel>
        {
            new DepartmentViewModel { DepartmentId = 1, DepartmentName = "HR" },
            new DepartmentViewModel { DepartmentId = 2, DepartmentName = "Finance" },
            // Add more departments as needed
        };
        // GET: DepartmentController
        public IActionResult Index()
        {
            return View(_departments);
        }

        // GET: DepartmentController/Details/5
        public IActionResult Details(int id)
        {
            var department = _departments.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // GET: DepartmentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                department.DepartmentId = _departments.Max(d => d.DepartmentId) + 1;
                _departments.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: DepartmentController/Edit/5
        public IActionResult Edit(int id)
        {
            var department = _departments.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DepartmentViewModel department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingDepartment = _departments.FirstOrDefault(d => d.DepartmentId == id);
                if (existingDepartment == null)
                {
                    return NotFound();
                }

                existingDepartment.DepartmentName = department.DepartmentName;
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: DepartmentController/Delete/5
        public IActionResult Delete(int id)
        {
            var department = _departments.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _departments.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            _departments.Remove(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
