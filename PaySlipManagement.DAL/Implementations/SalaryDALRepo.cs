using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.DapperServices.Implementations;
using Microsoft.Data.SqlClient;
using PaySlipManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;

namespace PaySlipManagement.DAL.Implementations
{
    public class SalaryDALRepo : ISalaryDALRepo
    {
        DapperServices<SalaryMetadata> salaryMetadataRepository;
        public SalaryDALRepo()
        {
            salaryMetadataRepository = new DapperServices<SalaryMetadata>();
        }


        public async Task<IEnumerable<SalaryMetadata>> GetAllSalaryMetadataAsync()
        {
            try
            {
                var result = await salaryMetadataRepository.ReadAllAsync(new SalaryMetadata() { Id = null });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<SalaryMetadata> GetSalaryMetadataByidAsync(SalaryMetadata _salaryMetadata)
        {
            try
            {
                return await salaryMetadataRepository.ReadGetByIdAsync(_salaryMetadata);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> CreateSalaryMetadata(SalaryMetadata _salaryMetadata)
        {
            try
            {

                if (_salaryMetadata != null)
                {
                    var employeeExists = await salaryMetadataRepository.CheckEmployeeExistsAsync(_salaryMetadata.Emp_Code);
                    if (!employeeExists)
                    {
                        return false; // Employee does not exist, creation cannot proceed
                    }
                    await salaryMetadataRepository.CreateAsync(_salaryMetadata);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateSalaryMetadata(SalaryMetadata _salaryMetadata)
        {
            try
            {
                if (_salaryMetadata != null)
                {
                    var employeeExists = await salaryMetadataRepository.CheckEmployeeExistsAsync(_salaryMetadata.Emp_Code);
                    if (!employeeExists)
                    {
                        return false; // Employee does not exist, creation cannot proceed
                    }
                    await salaryMetadataRepository.UpdateAsync(_salaryMetadata);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> DeleteSalaryMetadata(SalaryMetadata salaryMetadata)
        {
            try
            {
                if (salaryMetadata != null)
                {
                    await salaryMetadataRepository.DeleteAsync(salaryMetadata);
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
