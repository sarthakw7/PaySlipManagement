namespace PaySlipManagement.UI.Models
{
    public class SalaryMetadataViewModel
    {
        public int? Id { get; set; }
        public string Emp_Code { get; set; }
        public string PaySlipForMonth { get; set; }
        public decimal DaysPaid { get; set; }
        public decimal AbsentDays { get; set; }
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
        public decimal SpecialAllowance
        {
            get
            {
                return MonthGrossPay - EarnedBasic - HRA;
            }
        }
        public decimal PFEmployeeShare { get; } = 1800;
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
        public decimal EarningTotal
        {
            get
            {
                    return MonthGrossPay;
            }
        }
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
//}
        public decimal AnnualCTC { get; set; }
        public decimal CTCMonth
        {
            get
            {
                return AnnualCTC / 12;
            }
        }
        public decimal PFEmployerShare { get; } = 1800;
        public decimal PFEmployerShareAnnual
        {
            get
            {
                return PFEmployerShare * 12;
            }
        }
        public decimal AnnualGrossPay
        {
            get
            {
                return AnnualCTC - PFEmployerShareAnnual;
            }
        }
        public decimal MonthGrossPay
        {
            get
            {
                return CTCMonth - PFEmployerShare;
            }
        }
        public decimal OtherAdditions { get; set; }
        public decimal OtherDeductions { get; set; }
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

