using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var instructors = await _instructorService.GetAllAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            return Ok(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Instructor instructor)
        {
            var addedInstructor = await _instructorService.AddAsync(instructor);
            return Ok(addedInstructor);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Instructor instructor)
        {
            var updatedInstructor = await _instructorService.UpdateAsync(instructor);
            return Ok(updatedInstructor);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Instructor instructor)
        {
            await _instructorService.DeleteAsync(instructor);
            return Ok();
        }
    }
}
