using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.BAL.Implementations;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleBALRepo _roleBALRepo;

        public RolesController(IRoleBALRepo roleBALRepo)
        {
            _roleBALRepo = roleBALRepo;
        }

        [HttpGet("GetAllAsyncUserRoles")]
        public async Task<IEnumerable<Roles>> GetAllAsyncRoles()
        {
            return await _roleBALRepo.GetAllAsync();
        }
        [HttpPost("GetByIdAsyncUserRoles")]
        public async Task<Roles> GetByIdAsyncRoles(Roles roles)
        {
            return await _roleBALRepo.GetByIdAsync(roles);
        }
        [HttpPost("CreateUserRoles")]
        public async Task<bool> CreateRoles(Roles roles)
        {
            return await _roleBALRepo.Create(roles);

        }
        [HttpPut("UpdateUserRoles")]
        public async Task<bool> UpdateRoles(Roles roles)
        {
            return await _roleBALRepo.Update(roles);

        }
        [HttpPost("DeleteUserRoles")]
        public async Task<bool> DeleteRoles(Roles roles)
        {
            return await _roleBALRepo.Delete(roles);
        }


    }
}
