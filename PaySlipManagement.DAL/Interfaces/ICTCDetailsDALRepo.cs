using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Interfaces
{
    public interface ICTCDetailsDALRepo
    {
        Task<IEnumerable<CTCDetails>> GetAllCTCDetailsAsync();

        Task<CTCDetails> GetCTCDetailsByidAsync(CTCDetails _details);
        Task<bool> CreateCTCDetails(CTCDetails _details);
        Task<bool> UpdateCTCDetails(CTCDetails _details);
        Task<bool> DeleteCTCDetails(CTCDetails details);
    }
}
