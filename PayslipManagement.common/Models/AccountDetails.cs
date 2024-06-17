using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipManagement.Common.Models
{
    public class AccountDetails
    {
        public int Id { get; set; }
        public String Emp_Code { get; set; }
        public String BankName { get; set; }
        public long BankAccountNumber { get; set; }
        public long UANNumber { get; set; }
        public String PFAccountNumber { get; set; }

    }
}
