using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class SalaryMetadataViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Employee Code")]
        public string? Emp_Code { get; set; }
        [Display(Name = "PaySlip For Month")]
        public string? PaySlipForMonth { get; set; }
        [Display(Name = "Paid Days")]
        public decimal DaysPaid { get; set; }
        [Display(Name = "Absent Days")]
        public decimal AbsentDays { get; set; }
        [Display(Name = "Earned Basic")]
        public decimal EarnedBasic
        {
            get
            {
                return MonthGrossPay * 40 / 100;
            }
        }
        public decimal HRA
        {
            get
            {
                return EarnedBasic * 40 / 100;
            }
        }
        [Display(Name = "Special Allowance")]
        public decimal SpecialAllowance
        {
            get
            {
                return MonthGrossPay - EarnedBasic - HRA;
            }
        }
        [Display(Name = "PF Employee Share")]
        public decimal PFEmployeeShare { get; } = 1800;
        [Display(Name = "Professional Tax")]
        public decimal ProfessionalTax { get; } = 200;
        public decimal TDS
        {
            get
            {
                if (AnnualCTC > 500000 && AnnualCTC < 1000000)
                {
                    return CTCMonth * 5 / 100;
                }
                else if (AnnualCTC > 1000000)
                {
                    return CTCMonth * 10 / 100;
                }
                else
                {
                    return 0;
                }
            }
        }
        [Display(Name = "Earning Total")]
        public decimal EarningTotal
        {
            get
            {
                    return MonthGrossPay;
            }
        }
        [Display(Name = "Total Deductions")]
        public decimal TotalDeductions
        {
            get
            {
                return PFEmployeeShare + ProfessionalTax + TDS+ LossOfPay+OtherDeductions;
            }
        }
        public decimal NetPay 
        {
            get
            {
                return MonthGrossPay + OtherAdditions- TotalDeductions;
            }
        }
        //public decimal NetPay
        //{
        //    get
        //    {
        //        if (AbsentDays >= 1)
        //        {
        //            return (NetPay - EarningTotal / DaysPaid) * AbsentDays;
        //        }
        //        else
        //        {
        //            return EarningTotal - TotalDeductions;
        //        }
        //    }
        //}     [Display(Name = "Leave Type")]
        [Display(Name = "Annual CTC")]
        public decimal AnnualCTC { get; set; }
        [Display(Name = "CTC Month")]
        public decimal CTCMonth
        {
            get
            {
                return AnnualCTC / 12;
            }
        }
        [Display(Name = "PF Employer Share")]
        public decimal PFEmployerShare { get; } = 1800;
        [Display(Name = "PF Employer Share Annual")]
        public decimal PFEmployerShareAnnual
        {
            get
            {
                return PFEmployerShare * 12;
            }
        }
        [Display(Name = "Annual GrossPay")]
        public decimal AnnualGrossPay
        {
            get
            {
                return AnnualCTC - PFEmployerShareAnnual;
            }
        }
        [Display(Name = "Month GrossPay")]
        public decimal MonthGrossPay
        {
            get
            {
                return CTCMonth - PFEmployerShare;
            }
        }
        [Display(Name = "Other Additions")]
        public decimal OtherAdditions { get; set; }
        [Display(Name = "Other Deductions")]
        public decimal OtherDeductions { get; set; }
        [Display(Name = "Loss of Pay")]
        public decimal LossOfPay
        {
            get
            {
                if (DaysPaid > 0)
                {
                    return CTCMonth / DaysPaid * AbsentDays;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}

