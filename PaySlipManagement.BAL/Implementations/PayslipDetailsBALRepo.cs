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
    }
}
