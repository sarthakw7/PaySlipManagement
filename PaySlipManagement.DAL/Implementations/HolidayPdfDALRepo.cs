using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.DapperServices.Implementations;
using PaySlipManagement.DAL.Interfaces;

namespace PaySlipManagement.DAL.Implementations
{
    public class HolidayPdfDALRepo : IHolidayPdfDALRepo
    {
        DapperServices<HolidayPdf> _db;
        public HolidayPdfDALRepo()
        {
            _db = new DapperServices<HolidayPdf>();
        }
        public async Task<bool> Create(HolidayPdf pdf)
        {
            try
            {
                if (pdf != null)
                {
                    await _db.CreateAsync(pdf);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HolidayPdf> GetByIdAsync(HolidayPdf pdf)
        {

            try
            {
                return await _db.ReadGetByIdAsync(pdf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
