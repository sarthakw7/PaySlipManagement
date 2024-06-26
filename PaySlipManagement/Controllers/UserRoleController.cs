using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.BAL.Implementations;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleBALRepo _userRoleBALRepo;

        public UserRoleController (IUserRoleBALRepo userRoleBALRepo)
        {
            _userRoleBALRepo = userRoleBALRepo;
        }

        [HttpGet("GetAllAsyncUserRoles")]
        public async Task<IEnumerable<UserRoles>> GetAllAsyncUserRoles()
        {
            return await _userRoleBALRepo.GetAllAsync();
        }
        [HttpGet("GetByIdAsyncUserRoles/Id")]
        public async Task<UserRoles> GetByIdAsyncUserRoles(int Id)
        {
            UserRoles ur = new UserRoles();
            ur.Id = Id;
            return await _userRoleBALRepo.GetByIdAsync(ur);
        }
        [HttpPost("CreateUserRoles")]
        public async Task<bool> CreateUserRoles(UserRoles userRoles)
        {
            return await _userRoleBALRepo.Create(userRoles);

        }
        [HttpPut("UpdateUserRoles")]
        public async Task<bool> UpdateUserRoles(UserRoles userRoles)
        {
            return await _userRoleBALRepo.Update(userRoles);

        }
        [HttpPost("DeleteUserRoles")]
        public async Task<bool> DeleteUserRoles(UserRoles userRoles)
        {
            return await _userRoleBALRepo.Delete(userRoles);
        }
    }
}
