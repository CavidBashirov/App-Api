using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Employee;
using Service.Services.Interfaces;

namespace App.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _employeeService.CreateAsync(request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int? id)
        {
            return Ok(await _employeeService.DeleteAsync(id));
        }
    }
}
