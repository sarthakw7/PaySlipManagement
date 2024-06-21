using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.Common.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Emp_Code { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public string Designation { get; set; }
        public String Division { get; set; }
        public String Email { get; set; }
        public string PAN_Number { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
