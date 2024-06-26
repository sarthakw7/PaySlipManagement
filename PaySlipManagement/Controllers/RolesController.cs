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

        [HttpGet("GetAllAsyncRoles")]
        public async Task<IEnumerable<Roles>> GetAllAsyncRoles()
        {
            return await _roleBALRepo.GetAllAsync();
        }
        [HttpGet("GetByIdAsyncRoles/{Id}")]
        public async Task<Roles> GetByIdAsyncRoles(int id)
        {
            Roles r = new Roles();
            r.Id = id;
            return await _roleBALRepo.GetByIdAsync(r);
        }
        [HttpPost("CreateRoles")]
        public async Task<bool> CreateRoles(Roles roles)
        {
            return await _roleBALRepo.Create(roles);

        }
        [HttpPut("UpdateRoles")]
        public async Task<bool> UpdateRoles(Roles roles)
        {
            return await _roleBALRepo.Update(roles);

        }
        [HttpPost("DeleteRoles")]
        public async Task<bool> DeleteRoles(Roles roles)
        {
            return await _roleBALRepo.Delete(roles);
        }


    }
}
