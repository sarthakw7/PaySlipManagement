﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.Common.Models
{
    public class Users
    {
        public int? Id { get; set; }
        public string? Emp_Code { get; set; }
        
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class User
    {
        public string? Emp_Code { get; set; }
        
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

    }
    public class ResetPassword
    {
       
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
