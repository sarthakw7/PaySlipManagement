using PaySlipManagement.Common.Models;
using PaySlipManagement.DAL.DapperServices.Implementations;
using PaySlipManagement.DAL.DapperServices.Interfaces;
using PaySlipManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.Implementations
{
    public class PayslipDetailsDALRepo : IPayslipDetailsDALRepo
    {
        DapperServices<PayslipDetails> _payslipDALRepo;
        public PayslipDetailsDALRepo()
        {
            _payslipDALRepo = new DapperServices<PayslipDetails>();
        }
        public async Task<bool> Create(PayslipDetails payslipDetails)
        {
            if (payslipDetails != null)
            {
                await _payslipDALRepo.CreateAsync(payslipDetails);
                return true;
            }
            return false;
        }


        public async Task<bool> Delete(int? id)
        {
            var payslipDetails = new PayslipDetails { Id = id };
            await _payslipDALRepo.DeleteAsync(payslipDetails);
            return true;
        }

        public async Task<List<PayslipDetails>> GetAll()
        {
            var payslipDetails = await _payslipDALRepo.ReadAllAsync(new PayslipDetails() { Id = null});
            return payslipDetails as List<PayslipDetails>;
        }

        public async Task<PayslipDetails> GetById(int? id)
        {
            var payslipDetails = await _payslipDALRepo.ReadGetByIdAsync(new PayslipDetails { Id = id });
            return payslipDetails;
        }

        public async Task<bool> Update(PayslipDetails payslipDetails)
        {
            if (payslipDetails != null)
            {
                await _payslipDALRepo.UpdateAsync(payslipDetails);
                return true;
            }
            return false;
        }
    }
}
