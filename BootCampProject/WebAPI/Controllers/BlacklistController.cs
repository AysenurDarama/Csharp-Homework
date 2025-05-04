using Business.Abstract;
using Business.Dtos.Requests.Blacklist;
using Business.Dtos.Responses.Blacklist;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : ControllerBase
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlacklistRequest request)
        {
            CreatedBlacklistResponse response = await _blacklistService.AddAsync(request);
            return Created("", response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlacklistRequest request)
        {
            UpdatedBlacklistResponse response = await _blacklistService.UpdateAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedBlacklistResponse response = await _blacklistService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetBlacklistResponse response = await _blacklistService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _blacklistService.GetListAsync();
            return Ok(response);
        }
    }
}
