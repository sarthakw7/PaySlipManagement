using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.Common.Models
{
    public class CompanyDetails
    {
        public int? Id { get; set; }
        public String CompanyName { get; set; }
        public String CompanyAddress { get; set; }
        public String Division { get; set; }
    }
}
