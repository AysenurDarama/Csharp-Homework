using Business.Abstract;
using Business.Dtos.Requests.Bootcamp;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBootcampRequest request)
        {
            var response = await _bootcampService.AddAsync(request);
            return Created("", response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBootcampRequest request)
        {
            var response = await _bootcampService.UpdateAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bootcampService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _bootcampService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bootcampService.GetListAsync();
            return Ok(response);
        }
    }
}
