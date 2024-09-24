using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.DapperServices.Implementations;
using PaySlipManagement.DAL.Interfaces;

namespace PaySlipManagement.DAL.Implementations
{
    public class HolidayImageDALRepo : IHolidayImageDALRepo
    {
        DapperServices<HolidayImage> _db;
        public HolidayImageDALRepo()
        {
            _db = new DapperServices<HolidayImage>();
        }
        public async Task<bool> Create(HolidayImage img)
        {
            try
            {
                if (img != null)
                {
                    await _db.CreateAsync(img);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HolidayImage> GetByIdAsync(HolidayImage img)
        {

            try
            {
                return await _db.ReadGetByIdAsync(img);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
