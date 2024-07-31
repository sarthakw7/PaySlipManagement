using PaySlipManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.BAL.Interfaces
{
    public interface IPayslipDetailsBALRepo
    {
        Task<bool> Create(List<PayslipDetails> payslipDetails);
        Task<List<PayslipDetails>> GetAll();
        Task<PayslipDetails> GetById(int? id);
        Task<bool> Update(PayslipDetails payslipDetails);
        Task<bool> Delete(int? id);
    }
}
