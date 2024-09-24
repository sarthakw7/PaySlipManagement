
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.Implementations;
using PaySlipManagement.DAL.Interfaces;

namespace PaySlipManagement.BAL.Implementations
{
    public class HolidayPdfBALRepo : IHolidayPdfBALRepo
    {
        private HolidayPdfDALRepo _holidayDALRepo;

        public HolidayPdfBALRepo()
        {
            _holidayDALRepo = new HolidayPdfDALRepo();
        }
        public async Task<bool> Create(HolidayPdf pdf)
        {
            return await _holidayDALRepo.Create(pdf);
        }

        public async Task<HolidayPdf> GetById(HolidayPdf pdf)
        {
            return await _holidayDALRepo.GetByIdAsync(pdf);
        }
    }
}
