using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.BAL.Implementations;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayImageBALRepo _holidayImageBALRepo;
        private readonly IHolidayPdfBALRepo _holidayPdfBALRepo;
        public HolidayController(IHolidayImageBALRepo holidayImageBALRepo, IHolidayPdfBALRepo holidayPdfBALRepo)
        {
            _holidayImageBALRepo = holidayImageBALRepo;
            _holidayPdfBALRepo = holidayPdfBALRepo;
        }
        [HttpGet("GetHolidayImageByIdAsync")]
        public async Task<HolidayImage> GetByIdImageAsync()
        {
            HolidayImage r = new HolidayImage();
            r.Id = null;
            return await _holidayImageBALRepo.GetById(r);
        }
        [HttpPost("CreateHolidayImageAsync")]
        public async Task<bool> Create(HolidayImage roles)
        {
            return await _holidayImageBALRepo.Create(roles);
        }
        [HttpGet("GetHolidayPdfByIdAsync")]
        public async Task<HolidayPdf> GetByIdPdfAsync()
        {
            HolidayPdf r = new HolidayPdf();
            r.Id = null;
            return await _holidayPdfBALRepo.GetById(r);
        }
        [HttpPost("CreateHolidayPdfAsync")]
        public async Task<bool> Create(HolidayPdf pdf)
        {
            return await _holidayPdfBALRepo.Create(pdf);
        }
    }
}
