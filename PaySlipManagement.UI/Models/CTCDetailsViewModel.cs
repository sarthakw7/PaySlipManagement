using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class CTCDetailsViewModel
    {
        public int? Id { get; set; }
        public string Emp_Code { get; set; }
        [Display(Name = "Earned-Basic")]
        public decimal EarnedBasic { get; set; }
        public decimal HRA { get; set; }
        [Display(Name = "Special Allowance")]
        public decimal SpecialAllowance { get; set; }
        [Display(Name = "PF Employee Share")]
        public decimal PFEmployeeShare { get; set; }
        [Display(Name = "Professional Tax")]
        public decimal ProfessionalTax { get; set; }
        public decimal TDS { get; set; }
        [Display(Name = "Annual CTC")]
        public decimal AnnualCTC { get; set; }
        [Display(Name = "CTC Month")]
        public decimal CTCMonth { get; set; }
        [Display(Name = "PF Employer Share")]
        public decimal PFEmployerShare { get; set; }
        [Display(Name = "PF Employer Share Annual")]
        public decimal PFEmployerShareAnnual { get; set; }
        [Display(Name = "Annual Gross-Pay")]
        public decimal AnnualGrossPay { get; set; }
        [Display(Name = "Month Gross-Pay")]
        public decimal MonthGrossPay { get; set; }
        [Display(Name = "Other Additions")]
        public decimal OtherAdditions { get; set; }
        [Display(Name = "Other Deductons")]
        public decimal OtherDeductions { get; set; }
        [Display(Name = "Total Deductions")]
        public decimal TotalDeductions { get; set; }
        public decimal NetPay { get; set; }
    }
}
