using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class CompanyDetailsViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }
        [Display(Name = "Company Address")]
        public String CompanyAddress { get; set; }
        public String Division { get; set; }
    }
}
