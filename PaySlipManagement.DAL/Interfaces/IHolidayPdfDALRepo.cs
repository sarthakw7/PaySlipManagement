using PaySlipManagement.Common.Models;

namespace PaySlipManagement.DAL.Interfaces
{
    public interface IHolidayImageDALRepo
    {
        Task<HolidayImage> GetByIdAsync(HolidayImage user);
        Task<bool> Create(HolidayImage user);
    }
}
