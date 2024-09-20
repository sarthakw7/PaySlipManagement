namespace PaySlipManagement.UI.Models
{
    public class CTCDetailsViewModel
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
