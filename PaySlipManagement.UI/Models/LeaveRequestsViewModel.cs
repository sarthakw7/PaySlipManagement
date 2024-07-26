namespace PaySlipManagement.UI.Models
{
    public class LeaveRequestsViewModel
    {
        public int? Id { get; set; }
        public string Emp_Code { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public decimal LeavesCount { get; set; }
        public string ApprovalPerson { get; set; }
        public string Status { get; set; }
        public decimal LeaveBalance { get; set; }
    }
}
