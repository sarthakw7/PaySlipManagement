using PaySlipManagement.Common.Models;

namespace PaySlipManagement.DAL.Interfaces
{
    public interface IHolidayPdfDALRepo
    {
        Task<HolidayPdf> GetByIdAsync(HolidayPdf user);
        Task<bool> Create(HolidayPdf user);
    }
}
