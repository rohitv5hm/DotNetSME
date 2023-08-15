using Microsoft.AspNetCore.Mvc;
using ProjectX.Data.Entities;

namespace ProjectX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var departments = _departmentRepository.GetDepartmentById(id);
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult AddDepartments(AddDepartmentDTO addDepartment)
        {
            var departments = _departmentRepository.AddDepartment(addDepartment);
            return CreatedAtAction(nameof(GetDepartment), new {id = departments.Id}, departments);




        }

        // Other actions for getting, adding, updating, deleting departments, etc.
    }

}
