using Microsoft.AspNetCore.Mvc;
using ProjectX.Data.Entities;

namespace ProjectX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryController(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetSalariesForEmployee(int employeeId)
        {
            var salaries = _salaryRepository.GetSalariesForEmployee(employeeId);
            return Ok(salaries);
        }

        [HttpPost]
        public IActionResult AddSalary(Salary salary)
        {
            _salaryRepository.AddSalary(salary);
            return CreatedAtAction(nameof(GetSalariesForEmployee), new { employeeId = salary.EmployeeId }, salary);
        }

        // Other actions for updating, deleting, etc.
    }

}
