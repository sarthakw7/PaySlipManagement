using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Interfaces
{
    public interface ISalaryDALRepo
    {
        Task<IEnumerable<SalaryMetadata>> GetAllSalaryMetadataAsync();

        Task<SalaryMetadata> GetSalaryMetadataByidAsync(SalaryMetadata _salaryMetadata);
        Task<bool> CreateSalaryMetadata(SalaryMetadata _salaryMetadata);
        Task<bool> UpdateSalaryMetadata(SalaryMetadata _salaryMetadata);
        Task<bool> DeleteSalaryMetadata(SalaryMetadata salaryMetadata);
    }
}
