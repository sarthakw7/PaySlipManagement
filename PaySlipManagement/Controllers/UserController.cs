using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaySlipManagement.BAL.Implementations;
using PaySlipManagement.Common.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string SecretKey = "your_secret_key_here_1234567890_1234567890_1234567890_"; // 256-bit key
        private readonly SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));


        private readonly UserBALRepo _userBALRepo;
        public UserController()
        {
            _userBALRepo = new UserBALRepo();
        }

        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _userBALRepo.GetAllAsync();
        }

        [HttpGet("GetUserById/{Id}")]
        public async Task<Users> GetByIdUser(int Id)
        {
            Users u = new Users();
            u.Id = Id;
            return await _userBALRepo.GetByIdAsync(u);
        }

        [HttpPost("Register")]
        public async Task<bool> RegisterUser([FromBody] Users _user)
        {
            if (_user != null)
            {
                var data = await _userBALRepo.Create(_user);
                if (data)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        [HttpPut("UpdateUser")]
        public async Task<bool> UpdateUser(Users _user)
        {
            if (_user != null)
            {
                var existinguser = await _userBALRepo.GetByIdAsync(_user);

                if (existinguser != null)
                {
                    var updateUser = await _userBALRepo.Update(_user);

                    if (updateUser)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpGet("DeleteUser/{id}")]
        public async Task<bool> DeleteUser(int id)
        {

            Users u = new Users();
            u.Id = id;
            if (u.Id != null)
            {
                var data = await _userBALRepo.Delete(u);
                if (data)
                    return true;
                else
                    return false;
            }
            else
            {
                    return false;
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(Users _user)
        {
            if (_user != null)
            {
                Users u = new Users();
                u.Emp_Code = _user.Emp_Code;
                u.Password = _user.Password;
                var data = await _userBALRepo.UserValidateUserCredentials(u);
                if (data != null)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name,data.Email),
                    new Claim(ClaimTypes.Role, data.Role)
                    
                    };

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { User = new { Email = data.Email, EmpCode = data.Emp_Code }, Token = tokenString });
                }
                else
                {
                    return Ok("Make sure the credentials are correct");
                }
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }

    }
}

