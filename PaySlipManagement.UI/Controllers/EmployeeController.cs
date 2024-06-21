using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Emp_Code = "E001", EmployeeName = "John Doe", DepartmentId = 1, Designation = "Manager", Division = "Sales", Email = "john.doe@example.com", PAN_Number = "ABCDE1234F", JoiningDate = DateTime.Now.AddYears(-5) },
            new Employee { Id = 2, Emp_Code = "E002", EmployeeName = "Jane Smith", DepartmentId = 2, Designation = "Analyst", Division = "Finance", Email = "jane.smith@example.com", PAN_Number = "FGHIJ5678K", JoiningDate = DateTime.Now.AddYears(-3) },
            // Add more employees as needed
        };
        // GET: EmployeeController
        public IActionResult Index()
        {
            return View(_employees);
        }
        // GET: EmployeeController/Details/5
        public IActionResult Details(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = _employees.Max(e => e.Id) + 1;
                _employees.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        // GET: EmployeeController/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                existingEmployee.Emp_Code = employee.Emp_Code;
                existingEmployee.EmployeeName = employee.EmployeeName;
                existingEmployee.DepartmentId = employee.DepartmentId;
                existingEmployee.Designation = employee.Designation;
                existingEmployee.Division = employee.Division;
                existingEmployee.Email = employee.Email;
                existingEmployee.PAN_Number = employee.PAN_Number;
                existingEmployee.JoiningDate = employee.JoiningDate;

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        // GET: EmployeeController/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // POST: EmployeeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _employees.Remove(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
