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
    public class CompanyDetailsBALRepo: ICompanyDetailsBALRepo
    {
        public CompanyDetailsDALRepo _companyDetailsDALRepo = new CompanyDetailsDALRepo();
        

        public async Task<IEnumerable<CompanyDetails>> GetAllCompanyDetailsAsync()
        {
            return await _companyDetailsDALRepo.GetAllCompanyDetailsAsync();
        }

        public async Task<CompanyDetails> GetCompanyDetailsByidAsync(CompanyDetails _companyDetails)
        {
            return await _companyDetailsDALRepo.GetCompanyDetailsByidAsync(_companyDetails);
        }
        public async Task<bool> CreateCompanyDetails(CompanyDetails _companyDetails)
        {
            return await _companyDetailsDALRepo.CreateCompanyDetails(_companyDetails);

        }
        public async Task<bool> UpdateCompanyDetails(CompanyDetails _companyDetails)
        {
            return await _companyDetailsDALRepo.UpdateCompanyDetails(_companyDetails);

        }
        public async Task<bool> DeleteCompanyDetails(CompanyDetails companyDetails)
        {
            return await _companyDetailsDALRepo.DeleteCompanyDetails(companyDetails);

        }
    }
}
