using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.Common.Models
{
    public class HolidayImage
    {
        public int? Id { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
    }
}
