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
    }
}
