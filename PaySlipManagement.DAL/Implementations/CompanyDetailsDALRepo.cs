using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.DapperServices.Implementations;
using PaySlipManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Implementations
{
    public class CompanyDetailsDALRepo: ICompanyDetailsDALRepo
    {
        DapperServices<CompanyDetails> companyDetailsRepository;
        public CompanyDetailsDALRepo()
        {
            companyDetailsRepository = new DapperServices<CompanyDetails>();
        }


        public async Task<IEnumerable<CompanyDetails>> GetAllCompanyDetailsAsync()
        {
            try
            {
                var result = await companyDetailsRepository.ReadAllAsync(new CompanyDetails() { Id = null });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<CompanyDetails> GetCompanyDetailsByidAsync(CompanyDetails _companyDetails)
        {
            try
            {
                return await companyDetailsRepository.ReadGetByIdAsync(_companyDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> CreateCompanyDetails(CompanyDetails _companyDetails)
        {
            try
            {

                if (_companyDetails != null)
                {
                    await companyDetailsRepository.CreateAsync(_companyDetails);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateCompanyDetails(CompanyDetails _companyDetails)
        {
            try
            {
                if (_companyDetails != null)
                {
                    await companyDetailsRepository.UpdateAsync(_companyDetails);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> DeleteCompanyDetails(CompanyDetails companyDetails)
        {
            try
            {
                if (companyDetails != null)
                {
                    await companyDetailsRepository.DeleteAsync(companyDetails);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
