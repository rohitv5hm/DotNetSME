using Microsoft.AspNetCore.Mvc;
using ProjectX.Data.Entities;

namespace ProjectX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetAttendancesForEmployee(int employeeId)
        {
            var attendances = _attendanceRepository.GetAttendancesForEmployee(employeeId);
            return Ok(attendances);
        }

        [HttpPost]
        public IActionResult AddAttendance(Attendance attendance)
        {
            _attendanceRepository.AddAttendance(attendance);
            return CreatedAtAction(nameof(GetAttendancesForEmployee), new { employeeId = attendance.EmployeeId }, attendance);
        }

        // Other actions for updating, deleting, etc.
    }

}
