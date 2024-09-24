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
    public class CTCDetailsDALRepo: ICTCDetailsDALRepo
    {
        DapperServices<CTCDetails> CTCDetailsRepository;
        public CTCDetailsDALRepo()
        {
            CTCDetailsRepository = new DapperServices<CTCDetails>();
        }


        public async Task<IEnumerable<CTCDetails>> GetAllCTCDetailsAsync()
        {
            try
            {
                var result = await CTCDetailsRepository.ReadAllAsync(new CTCDetails() { Id = null });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<CTCDetails> GetCTCDetailsByidAsync(CTCDetails _details)
        {
            try
            {
                return await CTCDetailsRepository.ReadGetByIdAsync(_details);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> CreateCTCDetails(CTCDetails _details)
        {
            try
            {

                if (_details != null)
                {
                    var employeeExists = await CTCDetailsRepository.CheckEmployeeExistsAsync(_details.Emp_Code);
                    if (!employeeExists)
                    {
                        return false; // Employee does not exist, creation cannot proceed
                    }
                    await CTCDetailsRepository.CreateAsync(_details);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateCTCDetails(CTCDetails _details)
        {
            try
            {
                if (_details != null)
                {
                    var employeeExists = await CTCDetailsRepository.CheckEmployeeExistsAsync(_details.Emp_Code);
                    if (!employeeExists)
                    {
                        return false; // Employee does not exist, creation cannot proceed
                    }
                    await CTCDetailsRepository.UpdateAsync(_details);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> DeleteCTCDetails(CTCDetails details)
        {
            try
            {
                if (details != null)
                {
                    await CTCDetailsRepository.DeleteAsync(details);
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
