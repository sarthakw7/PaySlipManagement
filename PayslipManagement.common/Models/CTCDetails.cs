using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.Common.Models
{
    public class CTCDetails
    {
        public int? Id { get; set; }
        public string Emp_Code { get; set; }
        public decimal EarnedBasic { get; set; }
        public decimal HRA { get; set; }
        public decimal SpecialAllowance { get; set; }
        public decimal PFEmployeeShare { get; set; }
        public decimal ProfessionalTax { get; set; }
        public decimal TDS { get; set; }
        public decimal AnnualCTC { get; set; }
        public decimal CTCMonth { get; set; }
        public decimal PFEmployerShare { get; set; }
        public decimal PFEmployerShareAnnual { get; set; }
        public decimal AnnualGrossPay { get; set; }
        public decimal MonthGrossPay { get; set; }
        public decimal OtherAdditions { get; set; }
        public decimal OtherDeductions { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetPay { get; set; }
    }
}
