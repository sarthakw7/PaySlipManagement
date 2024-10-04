using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class PayslipDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Employee Code")]
        public string? Emp_Code { get; set; }
        [Display(Name = "PaySlip For Month")]
        public string? PaySlipForMonth { get; set; }
        [Display(Name = "Days Paid")]
        public int DaysPaid { get; set; }
        [Display(Name = "Absent Days")]
        public int AbsentDays { get; set; }
        [Display(Name = "Earned Basic")]
        public decimal EarnedBasic { get; set; }
        public decimal HRA { get; set; }
        [Display(Name = "Special Allowance")]
        public decimal SpecialAllowance { get; set; }
        [Display(Name = "PF Employee Share")]
        public decimal PFEmployeeShare { get; set; }
        [Display(Name = "Professional Tax")]
        public decimal ProfessionalTax { get; set; }
        public decimal TDS { get; set; }
        [Display(Name = "Earning Total")]
        public decimal EarningTotal { get; set; }
        [Display(Name = "Total Deductions")]
        public decimal TotalDeductions { get; set; }
        public decimal NetPay { get; set; }
    }
}
