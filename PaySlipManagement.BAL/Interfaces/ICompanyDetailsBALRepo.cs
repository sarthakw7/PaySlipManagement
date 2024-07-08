using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Interfaces
{
    public interface ICompanyDetailsBALRepo
    {
        Task<IEnumerable<CompanyDetails>> GetAllCompanyDetailsAsync();

        Task<CompanyDetails> GetCompanyDetailsByidAsync(CompanyDetails _companyDetails);
        Task<bool> CreateCompanyDetails(CompanyDetails _companyDetails);
        Task<bool> UpdateCompanyDetails(CompanyDetails _companyDetails);
        Task<bool> DeleteCompanyDetails(CompanyDetails companyDetails);
    }
}
