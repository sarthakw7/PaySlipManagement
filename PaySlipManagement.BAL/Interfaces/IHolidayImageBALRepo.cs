using PaySlipManagement.Common.Models;

namespace PaySlipManagement.BAL.Interfaces
{
    public interface IHolidayImageBALRepo
    {
        Task<HolidayImage> GetById(HolidayImage user);
        Task<bool> Create(HolidayImage user);
    }
}
