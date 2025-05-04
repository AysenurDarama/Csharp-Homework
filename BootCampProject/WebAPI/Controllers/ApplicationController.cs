using Business.Abstract;
using Business.Dtos.Requests.Application;
using Business.Dtos.Responses.Application;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateApplicationRequest request)
        {
            CreatedApplicationResponse response = await _applicationService.AddAsync(request);
            return Created("", response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationRequest request)
        {
            UpdatedApplicationResponse response = await _applicationService.UpdateAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedApplicationResponse response = await _applicationService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetApplicationResponse response = await _applicationService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _applicationService.GetListAsync();
            return Ok(response);
        }
    }
}
