using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaySlipManagement.UI.Controllers
{
    public class SalaryMetadataController : Controller
    {
        // GET: SalaryMetadataController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SalaryMetadataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalaryMetadataController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryMetadataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalaryMetadataController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalaryMetadataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalaryMetadataController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalaryMetadataController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
