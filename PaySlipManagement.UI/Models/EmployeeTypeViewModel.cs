using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class EmployeeTypeViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Employee Type")]
        public string? EmpType { get; set; }
        [Display(Name ="Leave Allocation")]
        public decimal LeaveAllocation { get; set; }
    }
}
