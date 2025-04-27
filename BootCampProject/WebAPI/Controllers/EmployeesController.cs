using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var addedEmployee = await _employeeService.AddAsync(employee);
            return Ok(addedEmployee);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            var updatedEmployee = await _employeeService.UpdateAsync(employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Employee employee)
        {
            await _employeeService.DeleteAsync(employee);
            return Ok();
        }
    }
}
