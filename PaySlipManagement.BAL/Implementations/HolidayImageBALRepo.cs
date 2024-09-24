
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.Implementations;
using PaySlipManagement.DAL.Interfaces;

namespace PaySlipManagement.BAL.Implementations
{
    public class HolidayImageBALRepo : IHolidayImageBALRepo
    {
        private HolidayImageDALRepo _holidayDALRepo;

        public HolidayImageBALRepo()
        {
            _holidayDALRepo = new HolidayImageDALRepo();
        }
        public async Task<bool> Create(HolidayImage img)
        {
            return await _holidayDALRepo.Create(img);
        }

        public async Task<HolidayImage> GetById(HolidayImage img)
        {
            return await _holidayDALRepo.GetByIdAsync(img);
        }
    }
}
