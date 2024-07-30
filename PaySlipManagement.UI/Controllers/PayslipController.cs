using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NPOI.POIFS.Crypt.Dsig;
using OfficeOpenXml;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;

namespace PaySlipManagement.UI.Controllers
{
    public class PayslipController : Controller
    {
        private APIServices _apiServices;
        private readonly ApiSettings _apiSettings;

        public PayslipController(APIServices apiService, IOptions<ApiSettings> apiSettings)
        {
            this._apiServices = apiService;
            _apiSettings = apiSettings.Value;
        }
        [HttpGet]
        public IActionResult UploadPayslip()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPayslip(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Json(new { success = false, message = "File is empty" });
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            var payslipDetailsList = new List<PayslipDetailsViewModel>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 3; row <= rowCount; row++)
                    {
                        decimal.TryParse(worksheet.Cells[row, 15].Value?.ToString(), out var netPay);
                        decimal earnedBasic = netPay * 0.4m;
                        decimal hra = earnedBasic * 0.4m;
                        decimal specialAllowance = netPay - earnedBasic - hra;
                        int.TryParse(worksheet.Cells[row, 8].Value?.ToString(), out var daysPaid);
                        int.TryParse(worksheet.Cells[row, 6].Value?.ToString(), out var absentDays);
                        decimal lossofpay = Math.Round((netPay / daysPaid) * absentDays, 2);

                        PayslipDetailsViewModel rowData = new PayslipDetailsViewModel
                        {
                            Emp_Code = worksheet.Cells[row, 3].Value?.ToString(),
                            PaySlipForMonth = DateTime.Now.ToString("yyyy-MMMM"),
                            DaysPaid = daysPaid,
                            AbsentDays = absentDays,
                            EarnedBasic = earnedBasic,
                            HRA = hra,
                            SpecialAllowance = specialAllowance,
                            PFEmployeeShare = decimal.TryParse(worksheet.Cells[row, 12].Value?.ToString(), out var pfEmployeeShare) ? pfEmployeeShare : 0,
                            ProfessionalTax = decimal.TryParse(worksheet.Cells[row, 10].Value?.ToString(), out var professionalTax) ? professionalTax : 0,
                            TDS = decimal.TryParse(worksheet.Cells[row, 11].Value?.ToString(), out var tds) ? tds : 0,
                            EarningTotal = netPay,
                            TotalDeductions = pfEmployeeShare + professionalTax + tds,
                            NetPay = netPay - lossofpay
                        };
                        payslipDetailsList.Add(rowData);
                    }
                }
            }

            // Make a POST request to the Web API /api/PayslipDetails/CreatePayslipDetails
            var response = await _apiServices.PostAsync($"{_apiSettings.PayslipDetailsEndpoint}/CreatePayslipDetails", payslipDetailsList);

            if (!string.IsNullOrEmpty(response) && response == "Imported Successfully" || response == "true")
            {
                return RedirectToAction("UploadPayslip");
            }
            else
            {
                if (response != null)
                {
                    ModelState.AddModelError(string.Empty, response);
                }
                ModelState.AddModelError(string.Empty, "API request failed or Create was unsuccessful");
            }
            return View("UploadPayslip");
        }
    }
}
