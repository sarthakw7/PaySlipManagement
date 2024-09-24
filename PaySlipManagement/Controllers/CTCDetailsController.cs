using Microsoft.AspNetCore.Mvc;
using PaySlipManagement.BAL.Interfaces;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTCDetailsController : Controller
    {
        private readonly ICTCDetailsBALRepo _ctcDetailsBALRepo;
        public CTCDetailsController(ICTCDetailsBALRepo _ctcBALRepo)
        {
            _ctcDetailsBALRepo = _ctcBALRepo;
        }
        [HttpGet("GetAllCTCDetails")]
        public async Task<IEnumerable<CTCDetails>> GetAllCTCDetailsAsync()
        {
            return await _ctcDetailsBALRepo.GetAllCTCDetailsAsync();
        }
        [HttpGet("GetCTCDetailsByid/{id}")]
        public async Task<CTCDetails> GetCTCDetailsByidAsync(int id)
        {
            CTCDetails ctc = new CTCDetails();
            ctc.Id = id;
            return await _ctcDetailsBALRepo.GetCTCDetailsByidAsync(ctc);
        }
        [HttpPost("CreateCTCDetails")]
        public async Task<bool> CreateCTCDetails(CTCDetails _details)
        {
            return await _ctcDetailsBALRepo.CreateCTCDetails(_details);

        }
        [HttpPut("UpdateCTCDetails")]
        public async Task<bool> UpdateCTCDetails(CTCDetails _details)
        {
            return await _ctcDetailsBALRepo.UpdateCTCDetails(_details);

        }
        [HttpGet("DeleteCTCDetails/{id}")]
        public async Task<bool> DeleteCTCDetails(int id)
        {
            CTCDetails ctc = new CTCDetails();
            ctc.Id = id;
            return await _ctcDetailsBALRepo.DeleteCTCDetails(ctc);
        }
    }
}
