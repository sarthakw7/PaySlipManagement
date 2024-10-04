using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class LeavesViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Employee Code")]
        public string? Emp_Code { get; set; }
        [Display(Name = "Type Id")]
        public int TypeId { get; set; }
        [Display(Name = "Total Leaves")]
        public decimal TotalLeaves { get; set; }
        [Display(Name = "Leaves Available")]
        public decimal LeavesAvailable { get; set; }
        [Display(Name = "Leaves Used")]
        public decimal LeavesUsed { get; set; }
    }
}
