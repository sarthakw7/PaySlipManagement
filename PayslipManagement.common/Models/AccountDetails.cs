using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.Common.Models
{
    public class AccountDetails
    {
        public int? Id { get; set; }
        public String Emp_Code { get; set; }
        public String BankName { get; set; }
        [RegularExpression(@"^\d{9,18}$", ErrorMessage = "The bank account number must be between 9 and 18 digits long.")]
        public long BankAccountNumber { get; set; }
        [RegularExpression(@"^\d{12}$", ErrorMessage = "The UAN number must be 12 digits long.")]
        public long UANNumber { get; set; }
        [RegularExpression(@"^[A-Z]{2,6}\d{11,20}$", ErrorMessage = "The PF account number must be in the format XX-1234567-0000 (where X is an alphabet and 0 is a digit).")]
        public String PFAccountNumber { get; set; }

    }
}
