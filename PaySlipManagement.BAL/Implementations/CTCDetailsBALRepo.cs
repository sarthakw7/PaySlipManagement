using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Implementations
{
    public class CTCDetailsBALRepo: ICTCDetailsBALRepo
    {
        public CTCDetailsDALRepo ctcDetailsDALRepo = new CTCDetailsDALRepo();
        public async Task<IEnumerable<CTCDetails>> GetAllCTCDetailsAsync()
        {
            return await ctcDetailsDALRepo.GetAllCTCDetailsAsync();
        }

        public async Task<CTCDetails> GetCTCDetailsByidAsync(CTCDetails _details)
        {
            return await ctcDetailsDALRepo.GetCTCDetailsByidAsync(_details);
        }
        public async Task<bool> CreateCTCDetails(CTCDetails _details)
        {
            return await ctcDetailsDALRepo.CreateCTCDetails(_details);

        }
        public async Task<bool> UpdateCTCDetails(CTCDetails _details)
        {
            return await ctcDetailsDALRepo.UpdateCTCDetails(_details);

        }
        public async Task<bool> DeleteCTCDetails(CTCDetails details)
        {
            return await ctcDetailsDALRepo.DeleteCTCDetails(details);

        }
    }
}
