using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applicants = await _applicantService.GetAllAsync();
            return Ok(applicants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var applicant = await _applicantService.GetByIdAsync(id);
            return Ok(applicant);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Applicant applicant)
        {
            var addedApplicant = await _applicantService.AddAsync(applicant);
            return Ok(addedApplicant);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Applicant applicant)
        {
            var updatedApplicant = await _applicantService.UpdateAsync(applicant);
            return Ok(updatedApplicant);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Applicant applicant)
        {
            await _applicantService.DeleteAsync(applicant);
            return Ok();
        }
    }
}
