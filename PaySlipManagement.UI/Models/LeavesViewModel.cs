namespace PaySlipManagement.UI.Models
{
    public class LeavesViewModel
    {
        public int? Id { get; set; }
        public string Emp_Code { get; set; }
        public int TypeId { get; set; }
        public decimal TotalLeaves { get; set; }
        public decimal LeavesAvailable { get; set; }
        public decimal LeavesUsed { get; set; }
    }
}
