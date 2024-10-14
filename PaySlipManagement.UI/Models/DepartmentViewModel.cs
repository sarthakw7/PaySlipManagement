

using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        
    }
}
