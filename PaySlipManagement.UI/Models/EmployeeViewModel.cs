﻿using PayslipManagement.Common.Models;
using System.ComponentModel.DataAnnotations;
using PaySlipManagement.UI.Utilities;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.UI.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Employee Code")]
        public string Emp_Code { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        [Display(Name = "Department Id")]
        public string Designation { get; set; }
        public String Division { get; set; }
        public String Email { get; set; }
        [Display(Name = "PAN Number")]
        public string PAN_Number { get; set; }
        public string MaskedPanNumber => StringHelpers.MaskPanNumber(PAN_Number);
        [Display(Name = "Joining Date")]
        public string JoiningDate { get; set; }
        
        [Display(Name = "Department Name")]
        public string? DepartmentName { get; set; }
        public string ManagerCode { get; set; }
    }
    public class EmployeePayPeriodsViewModel
    {
        public EmployeeDetails Employee { get; set; }

        public EmployeeViewModel employeeViewModel { get; set; }
        public List<string> PayPeriods { get; set; }
        public HolidayImagePDFViewModel Holiday {  get; set; }
        public LeavesViewModel Leaves { get; set; } = new LeavesViewModel();
    }
}
