

using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class UsersViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Employee Code")]
        public string? Emp_Code { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        //public string Role { get; set; }
    }
}
