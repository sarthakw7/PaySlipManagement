using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.Common.Models
{
    public class PayslipDetails
    {
        public int? Id { get; set; }
        public string Emp_Code { get; set; }
        public string PaySlipForMonth { get; set; }
        public int DaysPaid { get; set; }
        public int AbsentDays { get; set; }
        public decimal EarnedBasic { get; set; }
        public decimal HRA { get; set; }
        public decimal SpecialAllowance { get; set; }
        public decimal PFEmployeeShare { get; set; }
        public decimal ProfessionalTax { get; set; }
        public decimal TDS { get; set; }
        public decimal EarningTotal { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetPay { get; set; }
    }
}
