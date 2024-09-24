using PaySlipManagement.Common.Models;

namespace PaySlipManagement.BAL.Interfaces
{
    public interface IHolidayPdfBALRepo
    {
        Task<HolidayPdf> GetById(HolidayPdf pdf);
        Task<bool> Create(HolidayPdf pdf);
    }
}
