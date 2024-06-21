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
    public class SalaryBALRepo:ISalaryBALRepo
    {
        public SalaryDALRepo salarydalrepo = new SalaryDALRepo();
        public async Task<IEnumerable<SalaryMetadata>> GetAllSalaryMetadataAsync()
        {
            return await salarydalrepo.GetAllSalaryMetadataAsync();
        }

        public async Task<SalaryMetadata> GetSalaryMetadataByidAsync(SalaryMetadata _salaryMetadata)
        {
            return await salarydalrepo.GetSalaryMetadataByidAsync(_salaryMetadata);
        }
        public async Task<bool> CreateSalaryMetadata(SalaryMetadata _salaryMetadata)
        {
            return await salarydalrepo.CreateSalaryMetadata(_salaryMetadata);

        }
        public async Task<bool> UpdateSalaryMetadata(SalaryMetadata _salaryMetadata)
        {
            return await salarydalrepo.UpdateSalaryMetadata(_salaryMetadata);

        }
        public async Task<bool> DeleteSalaryMetadata(SalaryMetadata salaryMetadata)
        {
            return await salarydalrepo.DeleteSalaryMetadata(salaryMetadata);

        }
    }
}
