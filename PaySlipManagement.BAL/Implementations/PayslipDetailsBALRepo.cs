using Microsoft.IdentityModel.Tokens;
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
    public class PayslipDetailsBALRepo : IPayslipDetailsBALRepo
    {
        private PayslipDetailsDALRepo _payslipDALRepo;

        public PayslipDetailsBALRepo()
        {
            _payslipDALRepo = new PayslipDetailsDALRepo();
        }
        public async Task<bool> Create(List<PayslipDetails> payslipDetails)
        {
            if (payslipDetails == null || payslipDetails.IsNullOrEmpty())
                return false;
            foreach (var item in payslipDetails)
            {
                await _payslipDALRepo.Create(item);
            }
            return true;
        }

        public async Task<List<PayslipDetails>> GetAll()
        {
            return await _payslipDALRepo.GetAll();
        }

        public async Task<PayslipDetails> GetById(int? id)
        {
            return await _payslipDALRepo.GetById(id);
        }

        public async Task<bool> Update(PayslipDetails payslipDetails)
        {
            if (payslipDetails == null)
                return false;

            var existingPayslip = await _payslipDALRepo.GetById(payslipDetails.Id);
            if (existingPayslip == null)
                return false;

            await _payslipDALRepo.Update(payslipDetails);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var existingPayslip = await _payslipDALRepo.GetById(id);
            if (existingPayslip == null)
                return false;

            await _payslipDALRepo.Delete(id);
            return true;
        }
    }
}
