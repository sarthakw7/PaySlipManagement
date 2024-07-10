using PaySlipManagement.Common.Models;

namespace PaySlipManagement.UI.Models.DTO
{
    public class ApiResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string EmpCode { get; set; }
    }
}
